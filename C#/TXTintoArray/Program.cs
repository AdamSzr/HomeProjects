using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;


Console.WriteLine("12341234");
string dataDir = createPath("data");
const string inputFileName = "names.txt";
var inputFiles = Directory.GetFiles(dataDir).ToList();
inputFiles.Add(inputFileName);

const string outputFileName = "MultiLangNames.cs";

HashSet<string> cities = new();

foreach (string path in inputFiles)
{
    WriteLine("Input: " + createPath(path));
    using (var file = File.OpenText(createPath(path)))
    {
        while (!file.EndOfStream)
        {
            cities.Add(file.ReadLine());
        }
    }
}

Console.WriteLine("Output: " + createPath(outputFileName));
using (var sw = File.CreateText(createPath(outputFileName)))
{
    sw.Write(getArray(cities));
}


        static string formatLine(string line, Func<string, string> formatter)
{
    return "\t\"" + formatter(line) + "\",\r\n";
}
static string clearLine(string line) => line.Split(',')[0];
static string createPath(string path) => "../../../" + path;
static string getArray(HashSet<string> arg)
{
    System.Text.StringBuilder builder = new();
    builder.Append("var PolishCities = new string[]{\r\n");
    foreach (string item in arg)
    {
        builder.Append(formatLine(item, clearLine));
    }

    builder.Append("};\r\n");
    return builder.ToString();
}

















//namespace TXTintoArray
//{
//    class Program
//    {

//        public static void Main(string[] args)
//        {
//            Console.WriteLine("12341234");
//            string dataDir = createPath("data");
//            const string inputFileName = "names.txt";
//            var inputFiles = Directory.GetFiles(dataDir).ToList();
//            inputFiles.Add(inputFileName);

//            const string outputFileName = "MultiLangNames.cs";

//            HashSet<string> cities = new();

//            foreach (string path in inputFiles)
//            {
//                Console.WriteLine("Input: " + createPath(path));
//                using (var file = File.OpenText(createPath(path)))
//                {
//                    while (!file.EndOfStream)
//                    {
//                        cities.Add(file.ReadLine());
//                    }
//                }
//            }

//            Console.WriteLine("Output: " + createPath(outputFileName));
//            using (var sw = File.CreateText(createPath(outputFileName)))
//            {
//                sw.Write(getArray(cities));
//            }

//        }
//        static string formatLine(string line, Func<string, string> formatter)
//        {
//            return "\t\"" + formatter(line) + "\",\r\n";
//        }
//        static string clearLine(string line) => line.Split(',')[0];
//        static string createPath(string path) => "../../../" + path;
//        static string getArray(HashSet<string> arg)
//        {
//            System.Text.StringBuilder builder = new();
//            builder.Append("var PolishCities = new string[]{\r\n");
//            foreach (string item in arg)
//            {
//                builder.Append(formatLine(item, clearLine));
//            }

//            builder.Append("};\r\n");
//            return builder.ToString();
//        }
//    }
//}
