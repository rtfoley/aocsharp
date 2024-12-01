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
}