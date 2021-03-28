using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tab_2_d
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace sortowanie
    {
        class Program
        {


            static void Main(string[] args)
            {
                int x, y; // rozmiar tab;

                Console.WriteLine("Podaj ilosc wierszy");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj ilosc kolumn");
                y = int.Parse(Console.ReadLine());
                int[,] tab = new int[x, y];

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.WriteLine("Wpisz Wartość do elementu nr [" + (i+1) + "," + (j+1) + "]");
                        tab[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nieposortowana tablica:");
                Console.ResetColor();
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write("| {0,7} ", tab[i, j]);

                    }Console.Write("|");
                    Console.Write("\r\n");
                }
                
                    
                for (int z = 0; z < x; z++)
                {

                    int d, k;

                    for (int i = 1; i < y; i++)
                    {

                        d = tab[z,i];
                        for (k = i - 1; k >= 0; k--)
                        {
                            if (d < tab[z,k])
                            {
                                tab[z,k + 1] = tab[z,k];
                            }
                            else
                            {
                                break;
                            }

                        }
                        tab[z,k + 1] = d;
                    }

                    
                }


                Console.WriteLine(" "+new String('-',y*10));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Posortowana tablica:");
                Console.ResetColor();
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        
                        Console.Write("| {0,7} ", tab[i, j]);
                    }
                    Console.Write("|");
                    Console.Write("\r\n");
                }
                
                

                Console.ReadKey();
            }
        }

    }
}