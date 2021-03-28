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
        public Color FindMostPopularColor(Bitmap bitmap)
        {
            List<KeyValuePair<int, int>> lista = new List<KeyValuePair<int, int>>();

            var color = SystemColors.ActiveBorder;

            for (int line = 0; line < bitmap.Height; line++)
            {
                for (int row = 0; row < bitmap.Width; row++)
                {
                    var colorInt = bitmap.GetPixel(row, line).ToArgb();

                    if (lista.Any(arg => arg.Key == colorInt))
                    {
                        var item = lista.Find((item) => item.Key == colorInt);
                        lista.Remove(item);
                        lista.Add(new KeyValuePair<int, int>(item.Key, item.Value + 1));
                    }
                    else
                    {
                        lista.Add(new KeyValuePair<int, int>(colorInt, 1)); // 1 raz znalazł ten item.
                    }
                }
            }

            var ordered = lista.OrderBy((element) => element.Value).ToList();
            return Color.FromArgb(ordered.Last().Key);
        }

        public static void ScanLineFillBetter(Bitmap bitmap, Color color)
        {

            Lab_4_class lab = new Lab_4_class();
            var lastColor = lab.FindMostPopularColor(bitmap);

            var newColor = color;

            for (int line = 0; line < bitmap.Height; line++)
            {
                List<int> changingIndexes = new List<int>();
                // lista zbiera wszystkie pkt w których zmienia się kolor.(wartość - wskazuje  1-szy pixel nowego koloru.)
                // każdy przebieg generyje 4 punkty. potrzeba tylko 2 skrajnych.
                int counter = 0;
                for (int row = 0; row < bitmap.Width; row++)
                {
                    var pixelColor = bitmap.GetPixel(row, line);
                    if (pixelColor != lastColor) // znajduje zmiany kolorów.
                    {
                        counter++;
                        if (counter == 2 || counter == 3) // 1 i 4 gdy nie chcemy border. 2/3 gdy chcemy czarny border
                        {
                            changingIndexes.Add(row);
                        }
                        lastColor = pixelColor;
                    }
                }
                for (int i = 0; i < changingIndexes.Count; i += 2)
                {
                    lab.fillLine(line, changingIndexes[i], changingIndexes[i + 1], bitmap, newColor);
                }
                
            }
        }
        public static void ScanLineFill(Bitmap bitmap, Color color)
        {

            Lab_4_class lab = new Lab_4_class();
            var lastColor = lab.FindMostPopularColor(bitmap);
            var newColor = color;

            for (int line = 0; line < bitmap.Height; line++)
            {
                List<int> changingIndexes = new List<int>();
                // wszystkie pkt w których zmienia się kolor .( wskazywany jest 1 pixel nowego koloru.)
                for (int row = 0; row < bitmap.Width; row++)
                {
                    var pixelColor = bitmap.GetPixel(row, line);

                    if (pixelColor != lastColor) // znajduje zmiany kolorów.
                    {
                        changingIndexes.Add(row);
                        lastColor = pixelColor;
                    }
                }
                if (changingIndexes.Count > 2)
                {
                    try
                    {

                        for (int i = 1; i < changingIndexes.Count; i += 4)
                        {
                            var pstart = changingIndexes[i];
                            var pend = changingIndexes[i + 1];
                            lab.fillLine(line, pstart, pend, bitmap, newColor);
                        }
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
        public void fillLine(int lineIDX, int start, int end, Bitmap bitmap, Color color)
        {
            for (int i = start; i < end; i++)
            {
                bitmap.SetPixel(i, lineIDX, color);
            }
        }

    }
}
