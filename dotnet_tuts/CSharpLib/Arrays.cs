namespace CSharpLib;

public class Arrays
{
    public static (int[], int) ArrayOfIntegers()
    {
        int[] numbers = { 1, 2, 3, 5, 8, 13 };
        Console.WriteLine("numbers: {0}", numbers);
        return (numbers, numbers[3]);
    }

    public static string[] ArrayOfString()
    {
        var strings = new string[6];
        strings[0] = "Diego";
        strings[1] = "Vila";

        return strings;
    }

    public static int[,] Arrays2D()
    {
        // test
        int[,] numbers =
        {
            { 1, 2 },
            { 2, 3 },
            { 3, 4 },
            { 4, 5 }
        };

        return numbers;
    }

    public static int[][] JaggedArrays()
    {
        int[][] jagged =
        {
            new[] { 1, 2, 3 },
            new[] { 1, 2 },
            new[] { 1, 2, 3, 4 }
        };

        return jagged;
    }
}