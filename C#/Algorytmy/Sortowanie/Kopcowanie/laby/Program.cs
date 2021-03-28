using System;

namespace HeapSortAdamSzreiber
{
    class Program
    {
        static void przywroc(int[] T, int k, int n)
        {
            int i, j;
            i = T[k - 1];
            while (k <= n / 2)
            {
                j = 2 * k;
                if (j < n && T[j - 1] < T[j])
                {
                    j++;
                }
                if (i >= T[j - 1])
                {
                    break;
                }
                T[k - 1] = T[j - 1];
                k = j;
            }
            T[k - 1] = i;
        }
        static void heapsort(int[] T, int n)
        {
            int k, swap;
            for (k = n / 2; k > 0; k--)
            {
                przywroc(T, k, n);
            }

            do
            {
                swap = T[0];
                T[0] = T[n - 1];
                T[n - 1] = swap;
                n = n - 1;
                przywroc(T, 1, n);
            } while (n > 1);

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
            int[] tab = new int[lengthOfT];

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
            heapsort(tab, tab.Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Posortowana Tablica:");
            Console.ResetColor();
            WypiszTab(tab);


            Console.ReadKey();
        }
    }
}
