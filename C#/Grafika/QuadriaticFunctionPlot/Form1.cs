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

namespace Lab_6
{
    public partial class Form1 : Form
    {
        private readonly double a = 1.0 / 50.0;
        private readonly int b = 1;
        private readonly int c = -120;

        private readonly Adapter adapter;

        public Form1()
        {
            InitializeComponent();
            adapter = new Adapter(new Point(panel1.Width / 2, panel1.Height / 2));
            adapter.Set(this.panel1.Width, this.panel1.Height);

            this.button1.Click += Button1_Click;
        }

        private void DrawQuardiatic()
        {
            var ctx = this.panel1.CreateGraphics();
            
            // ustalić zakresy min x oraz max x, ( od srodka panelu )
            int x_min = -this.panel1.Width / 2 - 1; // from -640 .. 0 .. 640   to 1280/2 // rezerwowe -1
            int x_max = this.panel1.Width / 2 - 1; // rezerwowe -1 .


            // przelecieć od - x do x +
            // wrzucic do fununkci te x
            // zebrać wszystekie wzrocone punkty (x,y) 
            List<Point> fullPanelRange = new List<Point>();
            for (int x = x_min; x < x_max; x++)
            {
                fullPanelRange.Add(kwadratowa(x));
            }

            // adapter convert(). aby przenieść wszystkie ptk na środek, ( bo 0,0 w komputerach to lewy górny, a nie srodek).
            List<Point> fullPanelRangeConvertedToMiddle = new List<Point>();
            foreach (var obj in fullPanelRange)
            {
                fullPanelRangeConvertedToMiddle.Add(adapter.TranslatePoint(obj));
            }

            // przefiltrować aby pkt znajdowały się na układzie wsp.
            List<Point> filteredFullPanel = fullPanelRangeConvertedToMiddle.FindAll((point) => adapter.test(point));

            int g = 0;


            // inversja pkt względem osi x. tzn  lustrzane odbicie wertykalnie 
            // http://smurf.mimuw.edu.pl/uczesie/sites/default/files/Odbite2yy.jpg
            List<Point> invertedList = Invert(filteredFullPanel);


            // polaczyć przefiltrowane ptk w wykres.
            //  DrawCurve(Pen, Point[])
            //   var panelg = panel1.CreateGraphics();
            ctx.DrawCurve(Pens.Red, invertedList.ToArray());

            PutAxes();
            PutCompartments();
            //PutMZ_OnXAxes();
            //PutMZ_OnYAxes();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="XAxesDistance"> jaka szerokość zaprezentować na img co ile px ma byc podziałka. </param>
        /// <param name="YAxesDistance"></param>
        private void PutCompartments(int XAxesDistance = 10, int YAxesDistance = 10)
        {
            var ctx = this.panel1.CreateGraphics();


            int ponadOsiX = this.adapter.middlePoint.Y - 5; // 5 px ponad os.
            int ponizejOsiX = this.adapter.middlePoint.Y + 5; // 5 px ponad os.

            for (int i = adapter.middlePoint.X - XAxesDistance; i > 0; i -= XAxesDistance) //y sie niezmienia, natomiast x tak., rysuj od srodka do początku oś x,
            {
                ctx.DrawLine(Pens.Black, new Point(i, ponadOsiX), new Point(i, ponizejOsiX));
            }

            for (int i = adapter.middlePoint.X + XAxesDistance; i < this.panel1.Width; i += XAxesDistance) //y sie niezmienia, natomiast x tak., rysuj od srodka do początku oś x,
            {
                ctx.DrawLine(Pens.Black, new Point(i, ponadOsiX), new Point(i, ponizejOsiX));
            }

            // ------------------------------------------------------------------------------------------------------

            int poLewoOsiY = this.adapter.middlePoint.X - 5; // 5 px po lewej od Y-Axes
            int poPrawoOsiY = this.adapter.middlePoint.X + 5; //  5 px po prawo od Y-Axes

            for (int i = adapter.middlePoint.Y - YAxesDistance; i > 0; i -= YAxesDistance) //y sie niezmienia, natomiast x tak., rysuj od srodka do początku oś x,
            {
                ctx.DrawLine(Pens.Black, new Point(poLewoOsiY, i), new Point(poPrawoOsiY, i));
            }

            for (int i = adapter.middlePoint.Y + YAxesDistance; i < this.panel1.Height; i += YAxesDistance) //y sie niezmienia, natomiast x tak., rysuj od srodka do początku oś x,
            {
                ctx.DrawLine(Pens.Black, new Point(poLewoOsiY, i), new Point(poPrawoOsiY, i));
            }

            // ------------------------------------------------------------------------------------------------------
        }


        private Point? MZ() // TODO: tutaj jest cos źle.
        {
            var delta = b * b - 4 * a * c;
            if (delta < 0)
                return null;

            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

            return new Point(Convert.ToInt32(x1), Convert.ToInt32(x2));
            // returns 2 x witdh of label pos.
        }

        private void PutMZ_OnYAxes() // działa ok
        {
            var normalPos = kwadratowa(0);

            var height = normalPos.Y;

            Point p0 = new Point(0 + 5, height); // +5 aby nie wchodziło na Osie.
            p0 = adapter.TranslatePoint(p0);

            var exact_pos = this.Invert(p0);

            Label l = new Label();
            l.Location = exact_pos;
            l.AutoSize = true;
            l.Text = PointToString(normalPos);

            this.panel1.Controls.Add(l);

        }

        private void PutMZ_OnXAxes()
        {
            var normalMZ = MZ();

            if (normalMZ.HasValue)
            {

                var funcMz = this.adapter.TranslateBothCoord(normalMZ.Value); // naniesienie na 0.0 srodek panelu.

                //if (funcMz.Value.X == funcMz.Value.Y)
                //{// jest 1 miejce 0

                //    Point mz = new Point(funcMz.Value.X, adapter.middlePoint.Y);
                //    Label l = new Label();
                //    l.Location = mz;
                //    l.AutoSize = true;
                //    l.Text = PointToString(new Point(funcMz.v);

                //    this.panel1.Controls.Add(l);
                //}
                //else
                //{ // sa 2 miejsca 0
                Point x1 = new Point(funcMz.X, adapter.middlePoint.Y + 5); // +5 aby nie wchodził na plot.
                Point x2 = new Point(funcMz.Y, adapter.middlePoint.Y + 5);

                Label l = new Label();
                l.Location = x1;
                l.AutoSize = true;
                l.Text = PointToString(new Point(normalMZ.Value.X, 0));
                l.Font = new Font(FontFamily.GenericSansSerif, 10);

                this.panel1.Controls.Add(l);

                Label l2 = new Label();
                l2.Location = x2;
                l2.AutoSize = true;
                l2.Text = PointToString(new Point(normalMZ.Value.Y, 0));
                l2.Font = new Font(FontFamily.GenericSansSerif, 10);

                this.panel1.Controls.Add(l2);
                //}
            }
        }

        private void PutAxes()
        {
            var ctx = this.panel1.CreateGraphics();

            var horiz = new Point[] { new Point(0, adapter.middlePoint.Y), new Point(panel1.Width, adapter.middlePoint.Y) };
            var verti = new Point[] { new Point(adapter.middlePoint.X, 0), new Point(adapter.middlePoint.X, panel1.Height) };

            ctx.DrawLine(Pens.Black, horiz[0], horiz[1]);

            ctx.DrawLine(Pens.Black, verti[0], verti[1]);


        }
        private string PointToString(System.Drawing.Point p)
        {
            return $"({p.X}:{p.Y})";
        }


        private bool IsBottom(Point p)
        {
            return p.Y > adapter.middlePoint.Y;
        }

        private int CalcDistanceFromMiddlePoint(Point p)
        {
            return Math.Abs(adapter.middlePoint.Y - p.Y);
        }
        private Point Invert(Point point)
        {
            if (IsBottom(point))
            {
                return new Point(point.X, point.Y - 2 * CalcDistanceFromMiddlePoint(point));
            }
            else // to znaczy ze pkt jest ponad osia.
            {
                return new Point(point.X, point.Y + 2 * CalcDistanceFromMiddlePoint(point));
            }
        }

        private List<Point> Invert(List<Point> p)
        {
            List<Point> newList = new List<Point>();
            foreach (Point point in p)
            {
                if (IsBottom(point))
                {
                    Point toAdd = new Point(point.X, point.Y - 2 * CalcDistanceFromMiddlePoint(point));
                    newList.Add(toAdd);
                }
                else // to znaczy ze pkt jest ponad osia.
                {
                    Point invertedPoint = new Point(point.X, point.Y + 2 * CalcDistanceFromMiddlePoint(point));
                    newList.Add(invertedPoint);
                }
            }

            return newList;
        }



        private Point kwadratowa(int argX)
        {
            // y = (x^2)/170+x-160
            // wsp x^2, rozpiętość im mniejsza liczba tym bardziej rozpięte.
            // wsp x, jak ostra funkcja ma byc, wiekraz liczba bradziej ostro.
            // wsp , jak głęboko ma siegac mniejsza liczba == glębiej sięga.

            var ret = Convert.ToInt32((argX * argX) * a) + b * argX + c;
            return new Point(argX, ret);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            DrawQuardiatic();
        }

    }
}
