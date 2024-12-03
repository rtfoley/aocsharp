using System.Buffers;

namespace AoCSharp;

public class Day2
{
    public static int[] ExtractValues(string report)
    {
        string[] values = report.Split(' ');
        return Array.ConvertAll(values, int.Parse);
    }
    
    public static bool IsReportSafeWithDampener(int[] values)
    {
        if (IsReportSafe(values))
        {
            return true;
        }
        
        for (int i = 0; i < values.Length; i++)
        {
            List<int> copy = values.Select(v => v).ToList();
            copy.RemoveAt(i);
            if (IsReportSafe(copy.ToArray()))
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsReportSafe(int[] numbers)
    {
        bool isGoingUp = numbers[numbers.Length - 1] > numbers[0];
        for (int i = 0; i < numbers.Count()-1; i++)
        {
            int difference = numbers[i+1] - numbers[i];
            
            if (Math.Abs(difference) < 1 
                || Math.Abs(difference) > 3
                || (difference > 0 != isGoingUp))
            {
                return false;
            }
        }

        return true;
    }

    public static void Process()
    {
        using (var reader = new StreamReader("Inputs/day2.txt"))
        {
            int safeReports = 0;
            int safeReportsWithDampener = 0;
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                int[] values = ExtractValues(line);
                if (IsReportSafe(values))
                {
                    safeReports++;
                }

                if (IsReportSafeWithDampener(values))
                {
                    safeReportsWithDampener++;
                }
            }
            
            Console.WriteLine(safeReports);
            Console.WriteLine(safeReportsWithDampener);
        }
    }
}