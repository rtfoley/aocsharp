namespace AoCSharp;

public class Day2
{
    public static bool IsReportSafe(string report)
    {
        string[] values = report.Split(' ');
        int[] numbers = Array.ConvertAll(values, int.Parse);

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
                if (IsReportSafe(line))
                {
                    safeReports++;
                }
            }
            
            Console.WriteLine(safeReports);
            Console.WriteLine(safeReportsWithDampener);
        }
    }
}