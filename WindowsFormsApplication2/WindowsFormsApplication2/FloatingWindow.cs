using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{

    public partial class FloatingWindow : Form
    {
        private int desiredStartLocationX;
        private int desiredStartLocationY;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
       
        public FloatingWindow(int x, int y)
        {
            InitializeComponent();
            this.desiredStartLocationX = x;
            this.desiredStartLocationY = y;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Load += new EventHandler(FloatingLoad);
            Timer MyTimer = new Timer();
            MyTimer.Interval = (100); // 45 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
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

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            int windowTop = this.Top;
            int windowLeft = this.Left + 70;
            this.BackColor = GetColorAt(new Point(windowLeft, windowTop));
            Label label = Controls.Find("colorText", true).FirstOrDefault() as Label;
            if (label == null)
                return;
            label.Text = "(" + this.BackColor.R + ", " + this.BackColor.G + ", " + this.BackColor.B + " )";
            Label position = Controls.Find("position", true).FirstOrDefault() as Label;
            position.Text = "( " + windowLeft + ", " + windowTop + " )";
        }

        private void FloatingLoad(object sender, System.EventArgs e) {
            this.SetDesktopLocation(desiredStartLocationX - 70, desiredStartLocationY);
        }
        private void myDrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath wantedshape = new GraphicsPath();
            wantedshape.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(wantedshape);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FloatingWindow_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void FloatingWindow_MouseUp(object sender, MouseEventArgs e)
        {

        }

    }
}
