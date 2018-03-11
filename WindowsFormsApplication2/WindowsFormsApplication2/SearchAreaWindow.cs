using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class SearchAreaWindow : Form
    {
        private Color color;
        private int leftPosition, rightPosition, topPosition, bottomPosition;

        public SearchAreaWindow()
        {
            InitializeComponent();
       
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.Text = null;
        }

        public SearchAreaWindow(int left, int right, int top, int bottom, Color color)
        {
            // TODO: Complete member initialization
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            if (left > 100)
                this.leftPosition = left - 100;
            else
                this.leftPosition = 0;
            if (right < screenWidth - 100)
                this.rightPosition = right + 100;
            else
                right = screenWidth;
            if (top > 100)
                this.topPosition = top - 100;
            else
                this.topPosition = 0;
            if (bottom < screenHeight - 100)
                this.bottomPosition = bottom + 100;
            else
                this.bottomPosition = screenHeight;
            this.color = color;
            Load += new EventHandler(FloatingLoad);
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }

        private void FloatingLoad(object sender, System.EventArgs e)
        {
            this.MaximumSize = new Size(this.rightPosition - this.leftPosition, this.bottomPosition - this.topPosition);
            this.MinimumSize = new Size(this.rightPosition - this.leftPosition, this.bottomPosition - this.topPosition);
            this.SetDesktopLocation(this.leftPosition, this.topPosition );
        }

        private void paint(object sender, PaintEventArgs e)
        {
            GraphicsPath wantedshape = new GraphicsPath();
            //wantedshape.AddRectangle(new Rectangle(0, 0, this.Width, this.Height));
            wantedshape.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(wantedshape);
        }

        private void load(object sender, EventArgs e)
        {
            //this.BackColor = 
        }
    }
}
