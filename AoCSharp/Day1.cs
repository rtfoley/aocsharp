using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace AoCSharp;

public class Day1
{
    public static int GetDistance(List<int> list1, List<int> list2)
    {
        list1.Sort();
        list2.Sort();
        int distance = 0;
        for (int i = 0; i < list1.Count; i++)
        {
            distance += Math.Abs(list1[i] - list2[i]);
        }
        
        return distance;
    }

    public static void Process()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = " ",
            TrimOptions = TrimOptions.Trim
        };
        
        using (var reader = new StreamReader("Inputs/day1.txt"))
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (int.TryParse(values[0], out int x))
                {
                    list1.Add(x);
                }

                if (int.TryParse(values[1], out int y))
                {
                    list2.Add(y);
                }
            }
            
            int distance = GetDistance(list1, list2);
            Console.WriteLine($"Distance is {distance}");
        }
    }

    public class Day1Record
    {
        [Index(0)]
        public string Value1 { get; set; }
        
        [Index(1)]
        public string Value2 { get; set; }
    }
}