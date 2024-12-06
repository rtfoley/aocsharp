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

    public static bool HasXMas(int x, int y, string[] input)
    {
        int rows = input.Length;
        int columns = input[0].Length;
        
        if (x + 1 >= columns
            || x - 1 < 0
            || y + 1 >= rows
            || y - 1 < 0)
        {
            return false;
        }

        string northeast = new String(new char[]{input[y - 1][x - 1], input[y + 1][x + 1]});
        string southeast = new String(new char[]{input[y + 1][x - 1], input[y - 1][x + 1]});

        return (northeast == "MS" || northeast == "SM") 
               && (southeast == "MS" || southeast == "SM");
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
    
    public static int GetXCount(string[] input)
    {
        int count = 0;
        int rows = input.Length;
        int columns = input[0].Length;
        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < columns; x++)
            {
                if (input[y][x] != 'A')
                {
                    continue;
                }

                if (HasXMas(x, y, input))
                {
                    count++;
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
        int xCount = GetXCount(lines);
        Console.WriteLine(xCount);
    }
}