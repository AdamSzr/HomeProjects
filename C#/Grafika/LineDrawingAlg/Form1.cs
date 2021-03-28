using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bresenham_Przyrostowa
{
    public partial class Form_Lab_2 : System.Windows.Forms.Form
    {
        Dictionary<int, Point> indexPointDict;
        Bitmap img;
        Point startPoint;
        Point endPoint;


        public Form_Lab_2()
        {
            InitializeComponent();
            this.indexPointDict = new Dictionary<int, Point>();
            this.Init();
        }

        private void Init()
        {

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.img = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point p = PointToClient(Control.MousePosition);
            this.indexPointDict.Add(this.dataGridView1.Rows.Count, p); // index'y w dict i datagridview sa od 0 zatem OK:)
            this.dataGridView1.Rows.Add(this.dataGridView1.Rows.Count + 1, $"{p.X},{p.Y}");
        }
        private void SetPoints() // mam 2 wybrane rows, wiece idx 0 to strart. a 1 to end
        {
            this.startPoint = indexPointDict[this.dataGridView1.SelectedRows[0].Index];
            this.endPoint = indexPointDict[this.dataGridView1.SelectedRows[1].Index];
            ValidatePoints();
        }
        private void SwapPoints()
        {
            Point helper = this.startPoint;
            this.startPoint = this.endPoint;
            this.endPoint = helper;
        }
        private void ValidatePoints()
        {
            if (!(this.startPoint.X < this.endPoint.X))
                SwapPoints();
        }



        private void btn_Draw_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (this.dataGridView1.SelectedRows.Count == 2 && this.listBox_obiekt.SelectedItem != null && this.listBox_metoda.SelectedItem != null) // nie interesuje mnie gdy sa wiecej niz 2 pkt.
            {
                SetPoints();
                string objekt = this.listBox_obiekt.SelectedItem.ToString();
                string metoda = this.listBox_metoda.SelectedItem.ToString();


                switch (objekt)
                {
                    case "Linia":
                        drawLine(metoda);
                        break;
                    case "Okrag":
                        drawCircle(metoda);
                        break;
                }
                watch.Stop();
                MessageBox.Show($"Czas rysowania: {watch.ElapsedTicks *100} ns.");

            }

        }
        public static Point pointParse(string point)
        {
            string[] numbers = point.Split(',');
            int xpos = int.Parse(numbers[0]);
            int ypos = int.Parse(numbers[1]);
            return new Point(xpos, ypos);
        }

        private void drawLine(string metoda)
        {
            if (metoda == "Bresenhama")
            {
                img.LineBresenham(this.startPoint, this.endPoint);
            }
            else if (metoda == "Przyrostowa")
            {
                img.LinePrzyrostowa(this.startPoint, this.endPoint);
            }
            this.updateImgBox();
        }

        private void updateImgBox()
        {
            this.pictureBox1.Image = this.img;
        }

        private void drawCircle(string metoda)
        {
            if (metoda == "Bresenhama")
            {
                this.img.OkragBrensenham(startPoint, endPoint);
            }
            else if (metoda == "Przyrostowa")
            {
                this.img.OkragPrzyrostowa(startPoint, endPoint);
            }
            this.updateImgBox();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            var count = this.dataGridView1.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dataGridView1.Rows.RemoveAt(0);
            }

            this.indexPointDict.Clear();
        }
    }


    public static class DrawingExtension
    {
        public static void Clear(this Bitmap bitmap)
        {
           for(int y=0;y<bitmap.Height;y++)
            {
                for(int x =0; x< bitmap.Width;x++)
                {
                    bitmap.SetPixel(x, y, System.Drawing.SystemColors.ActiveBorder);
                }
            }

        }

        public static void LineBresenham(this Bitmap bitmap, Point start, Point end)
        {
            int dx, dy, p, x, y;
            int x0, x1, y0, y1;
            x0 = start.X;
            y0 = start.Y;
            x1 = end.X;
            y1 = end.Y;


            dx = x1 - x0;
            dy = y1 - y0;
            x = x0;
            y = y0;
            p = 2 * dy - dx;
            while (x < x1)
            {
                if (p >= 0)
                {
                    bitmap.SetPixel(x, y);
                    y = y + 1;
                    p = p + 2 * dy - 2 * dx;
                }
                else
                {
                    bitmap.SetPixel(x, y);
                    p = p + 2 * dy;
                }
                x = x + 1;
            }

        }


        public static void LinePrzyrostowa(this Bitmap bitmap, Point start, Point end)
        {

            // Zakłada się, ze -1 < m < 1
            // x zmienia się od x0 do x1 z przyrostem jednostkowym
            int x;
            float dy, dx, y, m;
            dy = end.Y - start.Y;
            dx = end.X - start.X;
            m = dy / dx;
            y = start.Y;
            for (x = start.X; x <= end.X; x++)
            {
                bitmap.SetPixel(x, (int)Math.Floor(y + 0.5), Color.Black);
                y += m;
            }
        }

        public static void Sym8(this Bitmap bitmap, int x, int y, int x0, int y0)
        {
            bitmap.SetPixel(x + x0, y + y0);
            bitmap.SetPixel(y + x0, x + y0);
            bitmap.SetPixel(y + x0, -x + y0);
            bitmap.SetPixel(x + x0, -y + y0);
            bitmap.SetPixel(-x + x0, -y + y0);
            bitmap.SetPixel(-y + x0, -x + y0);
            bitmap.SetPixel(-y + x0, x + y0);
            bitmap.SetPixel(-x + x0, y + y0);
        }

        public static int DistanceBeetwenPoint(this Point p, Point point)
        {
            int ret = 0;
            int xpos = Math.Abs(p.X - point.X);
            int ypos = Math.Abs(p.Y - point.Y);

            ret = (int)Math.Sqrt(Math.Pow(xpos, 2) + Math.Pow(ypos, 2));

            return ret;
        }
        public static void OkragBrensenham(this Bitmap bitmap, Point start, Point end) // Midpoint_circle_algorithm
        {
            int radius = start.DistanceBeetwenPoint(end);
            int d = (5 - radius * 4) / 4;
            int x = 0;
            int y = radius;

            do
            {
                if (start.X + x >= 0 && start.X + x <= bitmap.Width - 1 && start.Y + y >= 0 && start.Y + y <= bitmap.Height - 1) bitmap.SetPixel(start.X + x, start.Y + y); // double check . 
                if (start.X + x >= 0 && start.X + x <= bitmap.Width - 1 && start.Y - y >= 0 && start.Y - y <= bitmap.Height - 1) bitmap.SetPixel(start.X + x, start.Y - y);
                if (start.X - x >= 0 && start.X - x <= bitmap.Width - 1 && start.Y + y >= 0 && start.Y + y <= bitmap.Height - 1) bitmap.SetPixel(start.X - x, start.Y + y);
                if (start.X - x >= 0 && start.X - x <= bitmap.Width - 1 && start.Y - y >= 0 && start.Y - y <= bitmap.Height - 1) bitmap.SetPixel(start.X - x, start.Y - y);
                if (start.X + y >= 0 && start.X + y <= bitmap.Width - 1 && start.Y + x >= 0 && start.Y + x <= bitmap.Height - 1) bitmap.SetPixel(start.X + y, start.Y + x);
                if (start.X + y >= 0 && start.X + y <= bitmap.Width - 1 && start.Y - x >= 0 && start.Y - x <= bitmap.Height - 1) bitmap.SetPixel(start.X + y, start.Y - x);
                if (start.X - y >= 0 && start.X - y <= bitmap.Width - 1 && start.Y + x >= 0 && start.Y + x <= bitmap.Height - 1) bitmap.SetPixel(start.X - y, start.Y + x);
                if (start.X - y >= 0 && start.X - y <= bitmap.Width - 1 && start.Y - x >= 0 && start.Y - x <= bitmap.Height - 1) bitmap.SetPixel(start.X - y, start.Y - x);


                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;
            } while (x <= y);

        }
        public static void OkragPrzyrostowa(this Bitmap bitmap, Point start, Point end)
        {

            int radius = start.DistanceBeetwenPoint(end);

            int x, y, d, deltaE, deltaSE;
            x = 0;
            y = radius;
            d = 1 - radius;
            deltaE = 3;
            deltaSE = 5 - radius * 2;
            bitmap.Sym8(x, y, start.X, start.Y);
            //  bitmap.Sym8(new Point(x + start.X, y + start.Y)); // musze przesunac pkt o x+srodek.x
            while (y > x)
            {
                if (d < 0)
                { //wybrać E
                    d += deltaE;
                    deltaE += 2;
                    deltaSE += 2;
                    x++;
                }
                else
                { //wybrać SE
                    d += deltaSE;
                    deltaE += 2;
                    deltaSE += 4;
                    x++;
                    y--;
                }
                bitmap.Sym8(x, y, start.X, start.Y);
            }
        }

        public static void SetPixel(this Bitmap bitmap, int x, int y)
        {
            if (!(x < 0 || y < 0 || x >= bitmap.Width || y >= bitmap.Height)) // jesli spelnia te warunki to rysuj
                bitmap.SetPixel(x, y, Color.Black);
        }


    }


}
