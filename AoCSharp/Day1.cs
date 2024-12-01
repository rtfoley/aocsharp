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

    public static int GetSimilarityScore(List<int> list1, List<int> list2)
    {
        int score = 0;
        foreach (int value in list1)
        {
            int count = list2.Count(x => x == value);
            score += value * count;
        }

        return score;
    }

    public static void Process()
    {   
        using (var reader = new StreamReader("Inputs/day1.txt"))
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (int.TryParse(values[0], out int x) && int.TryParse(values[1], out int y))
                {
                    list1.Add(x);
                    list2.Add(y);
                }
            }
            
            int distance = GetDistance(list1, list2);
            Console.WriteLine($"Distance is {distance}");
            
            int similarity = GetSimilarityScore(list1, list2);
            Console.WriteLine($"Similarity is {similarity}");
        }
    }
}