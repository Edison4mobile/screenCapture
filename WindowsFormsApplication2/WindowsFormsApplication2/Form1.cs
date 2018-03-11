using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Gma.System.MouseKeyHook;
using DevExpress.XtraEditors;
namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private IKeyboardMouseEvents m_GlobalHook;

        private List<Color> colors;

        private Color selectedColor;

        private int curXpos = 0;
        private int curYpos = 0;
        const int step = 10;

        private FloatingWindow searchWindow;
        private SearchAreaWindow searchAreaWindow;

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
         {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
             if (e.KeyChar == (Char)Keys.A) {
                 Point cursor = new Point();
                 GetCursorPos(ref cursor);

                 var c = GetColorAt(cursor);
                 for (int i = 0; i < colors.Count; i++)
                 {
                     Color color = colors[i];
                     if (Math.Abs(c.R - color.R) < 20
                         && Math.Abs(c.G - color.G) < 20
                         && Math.Abs(c.B - color.B) < 20) {
                             MessageBox.Show("This color is excluded by you");
                             return;
                     }
                 }
                 FloatingWindow floatingWindow = new FloatingWindow(cursor.X, cursor.Y);
                 floatingWindow.BackColor = c;
                 Label label = floatingWindow.Controls.Find("colorText", true).FirstOrDefault() as Label;
                 Label position = floatingWindow.Controls.Find("position", true).FirstOrDefault() as Label;
                 position.Text = "( " + cursor.X + ", " + cursor.Y + " )";
                 label.Text = "(" + c.R + ", " + c.G + ", " + c.B + " )";
                 floatingWindow.Show();
                 Application.OpenForms["FloatingWindow"].BringToFront();
            }
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);
            // uncommenting the following line will suppress the middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }

        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }

        public Form1()
        {
            InitializeComponent();
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private void homeLoad(object sender, EventArgs e)
        {
            Subscribe();
            this.colorListView = Controls.Find("colorListView", true).FirstOrDefault() as ListView;
            this.currentColorBox = Controls.Find("currentColorBox", true).FirstOrDefault() as PictureBox;
            this.colorPickEditText = Controls.Find("colorPickEditText", true).FirstOrDefault() as ColorPickEdit;
            this.searchColor = Controls.Find("searchColor", true).FirstOrDefault() as ColorPickEdit;
            this.leftEdtText = Controls.Find("leftEdtText", true).FirstOrDefault() as TextEdit;
            this.rightEditText = Controls.Find("rightEditText", true).FirstOrDefault() as TextEdit;
            this.topEditText = Controls.Find("topEditText", true).FirstOrDefault() as TextEdit;
            this.bottomEditText = Controls.Find("bottomEditText", true).FirstOrDefault() as TextEdit;
            this.currentColorBox = Controls.Find("colorPictureBox", true).FirstOrDefault() as PictureBox;
            this.xPosLabel = Controls.Find("xPosLabel", true).FirstOrDefault() as Label;
            this.yPosLabel = Controls.Find("yPosLabel", true).FirstOrDefault() as Label;
            this.screenResolution = Controls.Find("screenResolution", true).FirstOrDefault() as Label;
            this.colorListView.Columns.Add("R");
            this.colorListView.Columns.Add("G");
            this.colorListView.Columns.Add("B");
            this.colorListView.View = View.Details;
            this.colorListView.GridLines = true;
            this.colorListView.FullRowSelect = true;
            this.colors = new List<Color>();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.screenResolution.Text = "Screen Resolution" + screenWidth + " x " + screenHeight;

        }
        private void addColorButton_Click(object sender, EventArgs e)
        {
            Color color = this.colorPickEditText.Color;
            this.colors.Add(color);
            string[] arr = new string[4];
            arr[0] = "" + color.R;
            arr[1] = "" + color.G;
            arr[2] = "" + color.B;
            ListViewItem itm;
            itm = new ListViewItem(arr);
            this.colorListView.Items.Add(itm);
        }

        private void colorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            String red, green, blue;
            if (this.colorListView.SelectedItems.Count == 0)
                return;
            red = this.colorListView.SelectedItems[0].SubItems[0].Text;
            green = this.colorListView.SelectedItems[0].SubItems[1].Text;
            blue = this.colorListView.SelectedItems[0].SubItems[2].Text;
            this.selectedColor = FromRgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));
            this.currentColorBox.BackColor = this.selectedColor;
        }

        private Color FromRgb(int p1, int p2, int p3)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(p1, p2, p3);
            return myRgbColor;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                Color color = colors[i];
                if ( ( this.selectedColor.R == color.R ) &&
                   ( this.selectedColor.G == color.G ) &&
                   ( this.selectedColor.B == color.B ) )
                {
                    this.colorListView.Items.RemoveAt(i);
                    this.colors.RemoveAt(i);
                    this.currentColorBox.BackColor = FromRgb(255, 255, 255);
                    return;
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                MessageBox.Show("input left value");
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                MessageBox.Show("input top value");
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                MessageBox.Show("input right value");
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                MessageBox.Show("input bottom value");
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right >= screenHeight || bottom >= screenWidth || left < 0 || top < 0)
            {
                MessageBox.Show("Invalid region");
                return;
            }
            Color color = this.searchColor.Color;
            if (curXpos <= left || curYpos <= top)
            {
                return;
            }
            moveSearchWindow(left, right, top, bottom);
            if (searchWindow != null)
            {
                searchWindow.Hide();
            }
            if (curXpos > right)
                curXpos = right;
            if (curYpos > bottom)
                curYpos = bottom;
            for (int i = curXpos - step; i > left + step; i -= step)
            {
                if (isSameWithColor(i, curYpos, color))
                {
                    if (isSameWithColor(i, curYpos, color))
                    {
                        moveWindow(i, curYpos, color);
                        curXpos = i;
                        this.xPosLabel.Text = "x : " + i;
                        this.yPosLabel.Text = "y : " + curYpos;
                        return;
                    }
                    curXpos = i;

                    this.xPosLabel.Text = "x : " + i;
                    this.yPosLabel.Text = "y : " + curYpos;
                }
            }
            curYpos -= step;
            for (int i = right; i > left + step; i -= step)
            {
                for (int j = curYpos; j > top + step; j -= step)
                {
                    if (isSameWithColor(i, j, color))
                    {
                        moveWindow(i, j, color);
                        curXpos = i;
                        curYpos = j;
                        this.xPosLabel.Text = "x : " + i;
                        this.yPosLabel.Text = "y : " + j;
                        return;
                    }
                    curXpos = i;
                    curYpos = j;
                    this.xPosLabel.Text = "x : " + i;
                    this.yPosLabel.Text = "y : " + j;
                }
            }
            this.xPosLabel.Text = "x : " + left;
            this.yPosLabel.Text = "y : " + top;
            MessageBox.Show("Color doesn't exist. Please try to click next");
        }

        private void moveWindow(int xPos, int yPos, Color color)
        {
            searchWindow = new FloatingWindow(xPos, yPos);
            searchWindow.BackColor = color;
            Label label = searchWindow.Controls.Find("colorText", true).FirstOrDefault() as Label;
            Label position = searchWindow.Controls.Find("position", true).FirstOrDefault() as Label;
            position.Text = "( " + xPos + ", " + yPos + " )";
            label.Text = "(" + color.R + ", " + color.G + ", " + color.B + " )";
            searchWindow.Show();
            Application.OpenForms["FloatingWindow"].BringToFront();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                MessageBox.Show("input left value");
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                MessageBox.Show("input top value");
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                MessageBox.Show("input right value");
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                MessageBox.Show("input bottom value");
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right >= screenHeight || bottom >= screenWidth || left < 0 || top < 0)
            {
                MessageBox.Show("Invalid region");
                return;
            }
            Color color = this.searchColor.Color;
            if (curXpos >= right || curYpos >= bottom)
            {
                return;
            }
            if (searchWindow != null)
            {
                searchWindow.Hide();
            }
            moveSearchWindow(left, right, top, bottom);
            if (curXpos < left)
                curXpos = left;
            if (curYpos < top)
                curYpos = top;
            for (int i = curXpos + step; i < right - step; i += step) {
                if (isSameWithColor(i, curYpos, color)) {
                    if (isSameWithColor(i, curYpos, color))
                    {
                        moveWindow(i, curYpos, color);
                        curXpos = i;
                        this.xPosLabel.Text = "x : " + i;
                        this.yPosLabel.Text = "y : " + curYpos;
                        return;
                    }
                    curXpos = i;
                    
                    this.xPosLabel.Text = "x : " + i;
                    this.yPosLabel.Text = "y : " + curYpos;
                }
            }
            curYpos += step;
            for (int i = left; i < right - step; i += step) {
                for (int j = curYpos; j < bottom - step; j += step) {
                    if (isSameWithColor(i, j, color))
                    {
                        moveWindow(i, j, color);
                        curXpos = i;
                        curYpos = j;
                        this.xPosLabel.Text = "x : " + i;
                        this.yPosLabel.Text = "y : " + j;
                        return;
                    }
                    curXpos = i;
                    curYpos = j;
                    this.xPosLabel.Text = "x : " + i;
                    this.yPosLabel.Text = "y : " + j;
                }
            }
            this.xPosLabel.Text = "x : " + right;
            this.yPosLabel.Text = "y : " + bottom;
            MessageBox.Show("Color doesn't exist. Please try to click back.");
        }

        private Boolean isSameWithColor(int x, int y, Color color) {
            Color screenColor = GetColorAt(new Point(x, y));
            if ((Math.Abs(screenColor.R - color.R) < 20) &&
                (Math.Abs(screenColor.G - color.G) < 20) &&
                (Math.Abs(screenColor.B - color.B) < 20)) {
                    return true;
                }
            return false;
        }

        private void leftEdtText_EditValueChanged(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right > screenWidth || bottom > screenHeight || left < 0 || top < 0) 
            {
                return;
            }
           
        }

        private void moveSearchWindow(int left, int right, int top, int bottom)
        {
            if (searchAreaWindow != null)
            {
                searchAreaWindow.Close();
            }
            Color color = this.searchColor.Color;
            searchAreaWindow = new SearchAreaWindow(left, right, top, bottom, color);
            searchAreaWindow.Show();
        }

        private void rightEditText_EditValueChanged(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right > screenWidth || bottom > screenHeight || left < 0 || top < 0)
            {
                return;
            }
          
        }

        private void topEditText_EditValueChanged(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right > screenWidth || bottom > screenHeight || left < 0 || top < 0)
            {
                return;
            }
            
        }

        private void bottomEditText_EditValueChanged(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (this.leftEdtText.Text.Trim() == "")
            {
                return;
            }
            if (this.topEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.rightEditText.Text.Trim() == "")
            {
                return;
            }
            if (this.bottomEditText.Text.Trim() == "")
            {
                return;
            }
            int left = Int32.Parse(this.leftEdtText.Text);
            int top = Int32.Parse(this.topEditText.Text);
            int right = Int32.Parse(this.rightEditText.Text);
            int bottom = Int32.Parse(this.bottomEditText.Text);
            if (left > right || top > bottom || right > screenWidth || bottom > screenHeight || left < 0 || top < 0)
            {
                return;
            }
            
        }

    }
}
