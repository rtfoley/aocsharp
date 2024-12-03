using System.Text.RegularExpressions;

namespace AoCSharp;

public class Day3
{
    public static int GetTotal(string input)
    {
        int total = 0;
        string commandPattern = @"mul\(\d{1,3},\d{1,3}\)";
        string valuePattern = @"\d{1,3}";
        foreach (Match match in Regex.Matches(input, commandPattern))
        {
            var numberMatches = Regex.Matches(match.Value, valuePattern);
            total += int.Parse(numberMatches[0].Value) * int.Parse(numberMatches[1].Value);
        }

        return total;
    }

    public static void Process()
    {
        var input = File.ReadAllText("Inputs/day3.txt");
        int total = GetTotal(input);
        Console.WriteLine(total);
    }
}