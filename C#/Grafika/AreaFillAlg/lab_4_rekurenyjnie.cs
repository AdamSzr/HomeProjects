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
    partial class Lab_4_class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="start"></param>
        /// <param name="color_border">barwa brzegu</param>
        /// <param name="color_fill">barwa wypelnienia</param>
        public static void MetodaSpojnosci(Bitmap bitmap, Point start,Color color_border,Color color_fill) // color that shuld be w
        {
            var x = start.X; 
            var y = start.Y; 

            bitmap.SetPixel(x, y, color_fill);
           

            var y1c = bitmap.GetPixel(x, y + 1); // w doł.
            if (y1c != color_border && y1c != color_fill)
            {
                MetodaSpojnosci(bitmap, new Point(x, y + 1), color_border, color_fill);
            }

            var x1c = bitmap.GetPixel(x + 1, y); // w prawo
            if (x1c != color_border && x1c != color_fill)
            {
                MetodaSpojnosci(bitmap, new Point(x + 1, y), color_border, color_fill);
            }

            var gora = bitmap.GetPixel(x, y-1); // w gore
            if (gora != color_border && gora != color_fill)
            {
                MetodaSpojnosci(bitmap, new Point(x, y - 1 ), color_border, color_fill);
            }
            var lewo = bitmap.GetPixel(x-1, y); // w lewo
            if (lewo != color_border && lewo != color_fill)
            {
                MetodaSpojnosci(bitmap, new Point(x-1, y ), color_border, color_fill);
            }

        }


    }
}
