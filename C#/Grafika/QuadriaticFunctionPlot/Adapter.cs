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



    class Adapter
    {
        public readonly Point middlePoint;
        private int ObjWidth;
        private int Objheight;

        public void Set(int objw, int objh)
        {
            this.Objheight = objh;
            this.ObjWidth = objw;
        }

        public Adapter(Point middlePoint)
        {
            this.middlePoint = middlePoint;
        }


        /// <summary>
        /// Returns new point, where middlepoint from ctor is a (0,0) point in centner of "Grid"
        /// </summary>
        /// <param name="p"></param>
        /// <returns>new point with center at middle of the grid</returns>
        public Point TranslatePoint(Point p)
        {
            var potential_ret = new Point(this.middlePoint.X + p.X, this.middlePoint.Y + p.Y);

            return potential_ret;

        }
        public Point TranslateBothCoord(Point p)
        {
            var potential_ret = new Point(this.middlePoint.X + p.X, this.middlePoint.X + p.Y);

            return potential_ret;

        }
        public bool test(Point p)
        {
            if (p.X < this.ObjWidth && p.Y < this.Objheight && // mieszcza sie w ramach 
                 p.X > 0 && p.Y > 0) // pixele nigdy nie sa minusowe. 
            {
                return true;
            }
            return false;
        }

    }
}
