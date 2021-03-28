using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    class Program
    {
       static int[] tab;

        static void merge(int pocz, int sr, int kon)
        {



           

            int[] t =new int[tab.Length];
            int i, j, q;
            for (i = pocz; i <= kon; i++) t[i] = tab[i]; 
            i = pocz; j = sr + 1; q = pocz;                 
            while (i <= sr && j <= kon)
            {		 
                if (t[i] < t[j])
                    tab[q++] = t[i++];
                else
                    tab[q++] = t[j++];
            }
            while (i <= sr) 
            tab[q++] = t[i++];	
         /*
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(tab[pocz] + " " + tab[sr] + " " + tab[kon]);
            Console.ResetColor();  
          */
        }

       
        static void mergesort(int pocz, int kon,string side)
        {
            
            int sr;





            if (pocz < kon)
            {
                sr = (pocz + kon) / 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[");
                for (int z = pocz; z < sr; z++)
                {
                    Console.Write(tab[z] + " ");
                }                Console.Write("] ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(tab[sr]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                 Console.Write(   " [");
                for (int z = sr + 1; z <= kon; z++)
                {
                    Console.Write(tab[z] + " ");
                }
                Console.WriteLine("]");
                Console.ResetColor();
                mergesort(pocz, sr,"Lewa: ");       // Dzielenie lewej części
                mergesort(sr + 1, kon,"Prawa: ");   // Dzielenie prawej części
                merge(pocz, sr, kon);               // Łączenie części lewej i prawej
            }
        }

        public static void WypiszTab(int[] t)
        {
            foreach (int x in t)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
 
            Console.WriteLine("Podaj ile liczb będzie wpisanych");
            int lengthOfT = int.Parse(Console.ReadLine());
            tab = new int[lengthOfT];

            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine("Wpisz " + (i + 1) + " Liczbę");
                tab[i] = int.Parse(Console.ReadLine());

            }
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("NIE-posortowana Tablica:");
            Console.ResetColor();
            WypiszTab(tab);
            Console.WriteLine(new String('-', 60));
            mergesort(0,tab.Length-1,"Pelna: ");
            Console.WriteLine(new String('-', 60));
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Posortowana Tablica:");
            Console.ResetColor();
            WypiszTab(tab);


            Console.ReadKey();

        }
    }
}
