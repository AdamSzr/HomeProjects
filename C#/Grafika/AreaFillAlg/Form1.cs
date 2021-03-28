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
using System.Drawing.Drawing2D;

namespace Wypelnianie_obszaru
{
    public partial class Form1 : Form
    {
        List<Point> tranglePoints;
        int fontSize = 50;
        int clickCounter;
        Bitmap bitmap;
        Color newColor = Color.Transparent;
        Color popularColor;
        Point LetterPoint = new Point(0, 0);

        public Action On3Clicks;

        public Form1()
        {
            InitializeComponent();
            this.tranglePoints = new List<Point>();
            tranglePoints.Capacity = 3;
            this.clickCounter = 0;
            this.bitmap = new Bitmap(this.panel1.Width, this.panel1.Height);
            this.FillBitmap(this.bitmap);
            this.panel1.Image = bitmap;

            this.On3Clicks = () =>
            {
                using (var g = Graphics.FromImage(this.bitmap))
                {
                    g.DrawPolygon(Pens.Black, this.tranglePoints.ToArray());
                }
                this.tranglePoints.Clear();
                Update();
            };

        }


        private void Update()
        {
            this.panel1.Image = this.bitmap;
        }

        private void btn_r1_Click(object sender, EventArgs e)
        {
            //MetodaParzystosci(this.bitmap);
            Lab_4_class.ScanLineFill(this.bitmap, this.newColor);

            Update();
        }



        public void ClickInc()
        {
            clickCounter++;

            if (this.clickCounter % 3 ==0)
            {
                On3Clicks();
            }
        }


        public void FillBitmap(Bitmap bitmap)
        {
            for (int line = 0; line < bitmap.Height; line++)
            {
                for (int row = 0; row < bitmap.Width; row++)
                {
                    bitmap.SetPixel(row, line, SystemColors.GrayText);
                }
            }
        }


        public void MetodaParzystosci(Bitmap bitmap) // awaryjny kod.
        {
            int zmiana_koloru = 0;

            var lastColor = bitmap.GetPixel(0, 0);

            for (int line = 0; line < bitmap.Height; line++)
            {
                List<int> changingIndexes = new List<int>();

                for (int row = 0; row < bitmap.Width; row++)
                {
                    var pixelColor = bitmap.GetPixel(row, line);

                    if (pixelColor != lastColor)
                    {
                        changingIndexes.Add(row);
                        //   changingIndexes.Append(row);
                        zmiana_koloru++;
                        lastColor = pixelColor;
                    }

                }

                if (changingIndexes.Count > 2)
                {
                    changingIndexes.RemoveAt(changingIndexes.Count - 1);
                    changingIndexes.RemoveAt(0);

                    using (var g = Graphics.FromImage(this.bitmap))
                    {
                        g.DrawLine(Pens.Black, new Point(changingIndexes[0], line), new Point(changingIndexes[1], line));
                    }

                }

                zmiana_koloru = 0;
            }
            this.Update();
        }

        public void MetodaSpojnosci(Point startPoint)
        {
            if (bitmap.GetPixel(startPoint.X, startPoint.Y) != popularColor && bitmap.GetPixel(startPoint.X, startPoint.Y) != newColor)
            {
                this.bitmap.SetPixel(startPoint.X, startPoint.Y, this.newColor);
                var p = this.GetAllPoints(startPoint);
                foreach (var point in p)
                {
                    if (bitmap.GetPixel(point.X, point.Y) != popularColor && bitmap.GetPixel(point.X, point.Y) != newColor)
                    {
                        MetodaSpojnosci(point);
                    }

                }
            }



        }



        private bool IsValidPoint(Point point) => (point.X >= 0 && point.Y >= 0) && (point.X < this.bitmap.Width && point.Y < bitmap.Height);


        /// <summary>
        /// This function returns all 4 points (1 up, 1 down, 1 left, 1 right) 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        IEnumerable<Point> GetAllPoints(Point point)
        {
            List<Point> points = new List<Point>();
            var p1 = new Point(point.X - 1, point.Y);
            var p2 = new Point(point.X + 1, point.Y);
            var p3 = new Point(point.X, point.Y - 1);
            var p4 = new Point(point.X, point.Y + 1);

            if (IsValidPoint(p1))
                points.Add(p1);

            if (IsValidPoint(p2))
                points.Add(p2);

            if (IsValidPoint(p3))
                points.Add(p3);

            if (IsValidPoint(p4))
                points.Add(p4);

            return points;
        }



        private void btn_r2_Click(object sender, EventArgs e)
        {
            // var graphis = this.panel1.CreateGraphics();
            using (var g = Graphics.FromImage(this.bitmap))
            {
                var font = new Font(FontFamily.GenericSerif, this.fontSize);
                g.DrawString("T", font, Brushes.Azure, this.LetterPoint);
            }
            this.Update();
            


            var lab4 = new Lab_4_class();
            var brzeg = lab4.FindMostPopularColor(this.bitmap);
            var wypelnij = Color.Brown;
            var startpoint = FinStartPoint();

             RepaintLetter();
            //Lab_4_class.MetodaSpojnosci(this.bitmap, startpoint, brzeg, wypelnij);
            

        }

        public Point FinStartPoint()
        {
            var lab4 = new Lab_4_class();
            var popularColor = lab4.FindMostPopularColor(this.bitmap);
            for (int line = 0; line < bitmap.Height; line++)
            {
                for (int row = 0; row < bitmap.Width; row++)
                {
                    if (bitmap.GetPixel(row, line) != popularColor)
                    {
                        return new Point(row, line);
                    }
                }
            }
            throw new Exception("Nie znaleziono  pkt start.");
        }

        public void RepaintLetter()
        {
            Lab_4_class c4 = new Lab_4_class();

            var popularColor = c4.FindMostPopularColor(this.bitmap);
            for (int line = 0; line < bitmap.Height; line++)
            {
                for (int row = 0; row < bitmap.Width; row++)
                {
                    if (bitmap.GetPixel(row, line) != popularColor)
                    {
                        bitmap.SetPixel(row, line, Color.Coral);
                    }
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            FillBitmap(this.bitmap);
            this.clickCounter = 0;
            this.tranglePoints.Clear();
            this.Update();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs e2 = (MouseEventArgs)e;
            this.tranglePoints.Add(e2.Location);
            this.ClickInc();
        }
    }

}
