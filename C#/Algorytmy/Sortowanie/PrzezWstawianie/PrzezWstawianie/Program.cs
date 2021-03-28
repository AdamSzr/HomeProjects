using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortowanie
{
    class Program
    {

        static void Sortowanie(ref int[] tab, int w)
        {

            int x, k;

            for (int i = 1; i < w; i++)
            {

                x = tab[i];
                for (k = i - 1; k >= 0; k--)
                {
                    if (x < tab[k]) 
                    {
                        tab[k + 1] = tab[k];  
                    }
                    else
                    {
                        break;
                    }

                }
                tab[k + 1] = x; 
            }
        }

        public static void WyswietlTAb(int[] tablica)
        {
            for (int a = 0; a < tablica.Length; a++)
            {
                Console.Write(tablica[a] + " ");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Podaj ile liczb będzie wpisanych");
            int lengthOfT = int.Parse(Console.ReadLine());
            int[] tab = new int[lengthOfT];

            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine("Wpisz " + (i+1) + " Liczbę");
                tab[i] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("----------------------------------------");
            Console.Write("Wpisana Tablica: "); Program.WyswietlTAb(tab);
            Program.Sortowanie(ref tab, tab.Length);
            Console.Write("Posortowana Tablica: "); Program.WyswietlTAb(tab);
            Console.ReadKey();


        }
    }
}
