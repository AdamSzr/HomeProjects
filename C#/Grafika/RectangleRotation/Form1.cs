using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace RectangleRotationProgram
{
    public partial class Form1 : Form
    {

        private Point leftUpperCorner;
        private Size r1Size = new Size(40, 40);
        private Rectangle r1;
        private double scale;

        Graphics g;
        public Form1()
        {
            InitializeComponent();

            this.scale = (this.Width * 1.0 / this.trackBar1.Maximum * 1.0)  ;

            // calc the left upper corner of rectangle.
            this.leftUpperCorner.X = Convert.ToInt32( trackBar1.Value*scale);
            this.leftUpperCorner.Y = this.Height / 2 - r1Size.Height / 2;

            // set rectangle.
            r1 = new Rectangle(leftUpperCorner, r1Size);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            int trackvalue = (sender as TrackBar).Value;
            RotateRectangle(this.g, r1, trackBar1.Value, Pens.Black, trackvalue);
            this.Text = trackvalue.ToString();
        }

        private void RotateRectangle(Graphics g, Rectangle r, float angle, Pen pen,int newXPosition)
        {
            g = this.CreateGraphics();
            g.Clear(SystemColors.Control);

            r.X = Convert.ToInt32( newXPosition * scale);

            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, new PointF(r.Left + (r.Width / 2), r.Top + (r.Height / 2)));
                g.Transform = m;
                g.DrawRectangle(pen, r);
                g.ResetTransform();
            }
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.g = e.Graphics;
        }
    }
}
