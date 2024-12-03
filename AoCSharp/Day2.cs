namespace AoCSharp;

public class Day2
{
    public static bool IsReportSafe(string report, bool useDampener = false)
    {
        string[] values = report.Split(' ');
        int[] numbers = Array.ConvertAll(values, int.Parse);

        bool isGoingUp = true;
        bool hasUsedDampener = false;
        int lastNumber = numbers[0];
        for (int i = 1; i < numbers.Count(); i++)
        {
            int difference = numbers[i] - lastNumber;
            
            // TODO returns false negative if only first level is bad
            if (i == 1)
            {
                isGoingUp = difference > 0;
            }
            
            if (Math.Abs(difference) < 1 
                || Math.Abs(difference) > 3
                || (i > 1 && difference > 0 != isGoingUp))
            {
                if (!useDampener || hasUsedDampener)
                {
                    return false;
                }
                
                hasUsedDampener = true;
                continue;
            }
            
            lastNumber = numbers[i];
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

                if (IsReportSafe(line, true))
                {
                    safeReportsWithDampener++;
                }
            }
            
            Console.WriteLine(safeReports);
            Console.WriteLine(safeReportsWithDampener);
        }
    }
}