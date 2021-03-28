using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wybieranie
{
    class Program
    {
        public static void Sortowanie(ref int[] tab)
        {
            for (int j = 1; j <= tab.Length-1; j++)
            {
                int min = tab[j];
                int ad = j;
                for (int k = j + 1; k <= tab.Length-1; k++)
                {
                    if (tab[k] < min)
                    {
                        min = tab[k];
                        ad = k;
                    }
                }
                int pomoc = tab[j];
                tab[j] = min;
                tab[ad] = pomoc;
            }

        }
        public static void WyswietlTAb(int[] tablica)
        {
            for (int a = 1; a < tablica.Length; a++)
            {
                Console.Write(tablica[a] + " ");
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj ile liczb będzie wpisanych");
            int lengthOfT = int.Parse(Console.ReadLine());
            int[] tab = new int[lengthOfT+1];

            for (int i = 1; i < tab.Length; i++)
            {
                Console.WriteLine("Wpisz " + (i) + " Liczbę");
                tab[i] = int.Parse(Console.ReadLine());

            }

            Console.Clear();
            Console.Write("Wpisana Tablica: "); Program.WyswietlTAb(tab);
            Program.Sortowanie(ref tab);
            Console.Write("Posortowana Tablica: "); Program.WyswietlTAb(tab);
            Console.ReadKey();

        }
    }
}
