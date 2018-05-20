using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Linq
{
    public partial class Program
    {
        static StreamWriter wr = new StreamWriter("/Users/Andriana/Desktop/C#/practice/Linq/Linq/ClassRes.txt");

        public class Client
        {
            private string id;
            private string year;
            private string mounth;
            private string occupation;

            public Client(string d = " ", string y = " ", string m = " ", string o = " ")
            {
                this.id = d;
                this.year = y;
                this.mounth = m;
                this.occupation = o;
            }

            public string Id { get => id; set => id = value; }
            public string Year { get => year; set => year = value; }
            public string Mounth { get => mounth; set => mounth = value; }
            public string Occupation { get => occupation; set => occupation = value; }

        }
        public static Client ReadFromFile(StreamReader streamReader)
        {
            Client c = new Client
            {
                Id = streamReader.ReadLine(),
                Year = streamReader.ReadLine(),
                Mounth = streamReader.ReadLine(),
                Occupation = streamReader.ReadLine()
            };
            return c;
        }
        public static List<Client> ReadClassFromFile()
        {
            List<Client> clients = new List<Client>();
            StreamReader streamReader = new StreamReader("/Users/Andriana/Desktop/C#/practice/Linq/Linq/Class.txt");
            int ab = Convert.ToInt32(streamReader.ReadLine());
            for (int i = 0; i < ab; i++)
            {
                clients.Add(ReadFromFile(streamReader));
            }
            return clients;
        }
        public static void Tasks(List<Client> clients)
        {
            var min_ocup = clients.Min(i => i.Occupation);
            wr.WriteLine("Minimal occupation in hours:");
            wr.WriteLine(min_ocup);
            var max_ocup = clients.Max(i => i.Occupation);
            wr.WriteLine("Maximal occupation in hours:");
            wr.WriteLine(max_ocup);
            wr.WriteLine("Maximal occupation year:");
            IEnumerable<IGrouping<string, Client>> groupedByYears = clients.GroupBy(x => x.Year);
            IEnumerable<IGrouping<string, Client>> sorted = groupedByYears.OrderByDescending(group => group.Sum(i => Convert.ToInt32(i.Occupation))).ThenBy(x => x.Min(y => y.Year));
            wr.WriteLine(sorted.First().Key);
            wr.WriteLine("Sum of occupations for all years:");
            IEnumerable<IGrouping<string, Client>> groupedByCode = clients.GroupBy(x => x.Id);
            SortedDictionary<string, string> durations = new SortedDictionary<string, string>();
            foreach (IGrouping<string, Client> group in groupedByCode)
            {
                int sum = group.Sum(x => Convert.ToInt32(x.Occupation));
                durations.Add(Convert.ToString(sum), group.Key);
            }
            foreach (KeyValuePair<string, string> group in durations)
            {
                wr.WriteLine("Occpation : {0} ,Id: {1}", group.Key, group.Value);
            }
            wr.WriteLine("Count of mount");
            IEnumerable<IGrouping<string, Client>> groupedByCode2 = clients.GroupBy(x => x.Id);
            SortedDictionary<int, int> months = new SortedDictionary<int, int>();
            foreach (IGrouping<string, Client> group in groupedByCode2)
            {
                int count = group.Count();
                months.Add(Convert.ToInt32(group.Key), count);
            }
            foreach (KeyValuePair<int, int> group in months)
            {
                wr.WriteLine("Id : {0} ,Occpation: {1}", group.Key, group.Value);
            }
        }
    }
}
