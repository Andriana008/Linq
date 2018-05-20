using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Linq
{
    public partial class Program
    {
        static StreamWriter writer = new StreamWriter("/Users/Andriana/Desktop/C#/practice/Linq/Linq/res.txt");

        public static void LinqBegin16()
        {
            string[] arr = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task16-18.txt");
            IEnumerable<string> res = from number in arr where Int32.Parse(number) > 0 select number;
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }

            writer.WriteLine("Task 16");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
            writer.WriteLine();
        }
        public static void LinqBegin17()
        {
            string[] arr = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task16-18.txt");
            IEnumerable<string> res = (from number in arr where Convert.ToInt32(number) % 2 == 1 select number).Distinct();
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }

            writer.WriteLine("Task 17");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
            writer.WriteLine();

        }
        public static void LinqBegin18()
        {
            string[] arr = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task16-18.txt");
            IEnumerable<string> res = from number in arr where (Convert.ToInt32(number) > 0) && (Convert.ToInt32(number) - 10 > 0) && (Convert.ToInt32(number) - 100 < 0) select number;
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }

            writer.WriteLine("Task 18");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
            writer.WriteLine();

        }
        public static void LinqBegin19()
        {
            string[] arr = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task19.txt");
            IEnumerable<string> res= arr.OrderBy(i => i.Length).ThenBy(i => i);
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }
            writer.WriteLine("Task 19");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }        
        }
        public static void LinqBegin20()
        {
            string[] arr = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task16-18.txt");
            int d = 57;
            IEnumerable<string> res = arr.SkipWhile(num => Convert.ToInt32(num) < d).Where(num => Convert.ToInt32(num) % 2 != 0 && Convert.ToInt32(num) > 0).Reverse();
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }

            writer.WriteLine("Task 20");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
            writer.WriteLine();

        }
        public static void LinqBegin44()
        {
            string[] arr1 = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task16-18.txt");
            string[] arr2 = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task44.txt");
            int k1 = 36;
            int k2 = 67;
            IEnumerable<string> res = (from i in arr1 where Convert.ToInt32(i) > k1 select i).Union(from i in arr2 where Convert.ToInt32(i) < k2 select i).OrderBy(i => i);
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }
            writer.WriteLine("Task 44");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
            writer.WriteLine();
        }
        public static void LinqBegin45()
        {
            string[] arr1 = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task19.txt");
            string[] arr2 = File.ReadAllLines("/Users/Andriana/Desktop/C#/practice/Linq/Linq/task45.txt");
            int l1 = 3;
            int l2 = 4;
            IEnumerable<string> res = (from i in arr1 where i.Length == l1 select i).Union(from i in arr2 where i.Length == l2 select i).OrderBy(i => i);
            foreach (string i in res)
            {
                Console.WriteLine(i);
            }
            writer.WriteLine("Task 45");
            foreach (var item in res)
            {
                writer.Write($"{item} ");
            }
        }
        static void Main(string[] args)
        {
            LinqBegin16();
            LinqBegin17();
            LinqBegin18();
            LinqBegin19();
            LinqBegin20();
            LinqBegin44();
            LinqBegin45();
            List<Client> c = ReadClassFromFile();
            Tasks(c);
            writer.Close();
            wr.Close();
        }
    }
}
