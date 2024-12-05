namespace AoCSharp;

public class Day4
{
    private static readonly (int x, int y)[] directions = {
        ( 1, 0 ), // E
        ( 1, -1 ), // SE
        ( 0, -1 ), // S
        ( -1, -1 ), // SW
        ( -1, 0 ), // W
        ( -1, 1 ), // NW
        ( 0, 1 ), // N
        ( 1, 1 ), // NE
    };

    public static bool HasWordAt(int x, int y, string[] input, int xDirection, int yDirection)
    {
        int rows = input.Length;
        int columns = input[0].Length;
        
        // Check that there is even room for the word
        // add 1 to address, to account for 0-based indexing
        if (x + (xDirection * 4) > columns
            || x + 1 + (xDirection * 4) < 0
            || y + (yDirection * 4) > rows
            || y + 1 + (yDirection * 4) < 0)
        {
            return false;
        }

        return input[y + yDirection][x + xDirection] == 'M'
               && input[y + (yDirection * 2)][x + (xDirection * 2)] == 'A'
               && input[y + (yDirection * 3)][x + (xDirection * 3)] == 'S';
    }
    
    public static int GetWordCount(string[] input)
    {
        int count = 0;
        int rows = input.Length;
        int columns = input[0].Length;
        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < columns; x++)
            {
                if (input[y][x] != 'X')
                {
                    continue;
                }
                
                foreach (var direction in directions)
                {
                    if (HasWordAt(x: x, y: y, input, direction.x, direction.y))
                    {
                        count++;
                    }
                }
            }
        }
        
        return count;
    }

    public static void Process()
    {
        string[] lines = File.ReadAllLines("Inputs/day4.txt");
        int count = GetWordCount(lines);
        Console.WriteLine(count);
    }
}