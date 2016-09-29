using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        private bool whiteOnLeft = true;
        private Graphics grfx;
        private SolidBrush brush;
        private Rectangle rect; 
        public Form1()
        {
            InitializeComponent();
            Text = "C4560:  Assignment 2, Exercise 1 (Manish Mallavarapu Set 4D/2016)";
            BackColor = Color.Black;
            ResizeRedraw = true;
            // enable double-buffering to avoid flicker
            // copied from http://www.publicjoe.f9.co.uk/csharp/card09.html
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            
        }
        protected override void OnPaint(PaintEventArgs pea)
        {
            grfx = pea.Graphics;
            grfx.SmoothingMode = SmoothingMode.HighQuality;
            grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int cx = ClientSize.Width;
            int cy = ClientSize.Height;

            //here is where all of your drawing code would go.  For example, the following
            // hand corner of the bounding box of the circle being at x = 100, y = 200.
            rect = new Rectangle(0, 0, Width / 2, Height);
            if(BackColor == Color.Black)
            {
                brush = new SolidBrush(Color.White);
            }
            else
            {
                brush = new SolidBrush(Color.Black);
            }
            grfx.FillRectangle(brush, rect);
            drawSquares(40,40);
        }
        private void drawSquares(int s, int g)
        {   
            int border = (2*s) + g;
            int ulwx = Width / 2 - s;
            int ulbx = Width / 2;
            int uly = (2 * s) + g; 
            while(uly +s < (Height - border))
            {
                while(ulwx > border)
                {
                    rectangle(ulwx, uly, s);
                    rectangle(ulbx, uly, s);
                    ulwx -= (g + s);
                    ulbx += (g + s);
                }
                ulwx = Width / 2 - s;
                ulbx = Width / 2;
                uly += (s + g); 
            }
        }
        private void rectangle(int ulx, int uly,int s)
        {
            SolidBrush myBrush = new SolidBrush(Color.Chartreuse);         
            grfx.FillRectangle(myBrush, new Rectangle(ulx, uly, s, s));
        }
        private void switchBackGroundColors(object sender,EventArgs e)
        {
            if (whiteOnLeft)
            {
                whiteOnLeft = false;
                BackColor = Color.White;         
            }
            else
            {
                whiteOnLeft = true;
                BackColor = Color.Black; 
            }
        }
    }
}
