using System;
using System.IO;
using System.Text;


public static class Program
{
    public static void Main()
    {
    

        string persona;
        FileStream file = new FileStream("400ppl.db", FileMode.Create);

        Random random = new Random();

        for (int i = 1; i < 200; i++)
        {
            persona = (
                i + ";" +
                name[random.Next(name.Length)] + ";" +
               random.Next(1, 100) + ";" +
                random.Next(1, 1000) + ";" + '\n');
            System.Threading.Thread.Sleep(30);
            Console.Write(persona);
            file.Write(Encoding.ASCII.GetBytes(persona), 0, persona.Length);

        }
        for (int i = 1; i < 200; i++)
        {
            persona = (
                i + ";" +
                surnames[random.Next(surnames.Length)] + ";" +
               random.Next(1, 100) + ";" +
                random.Next(1, 1000) + ";" + '\n');
            System.Threading.Thread.Sleep(30);
            Console.Write(persona);
            file.Write(Encoding.ASCII.GetBytes(persona), 0, persona.Length);

        }
        file.Close();

        Console.Write("done");
        Console.ReadKey();




    }
}

