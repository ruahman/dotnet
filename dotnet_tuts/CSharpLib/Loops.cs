namespace CSharpLib;

public class Loops
{
    public static int WhileLoop()
    {
        var index = 1;
        while (index <= 5)
        {
            index++;
            Console.WriteLine("WhileLoop: {0}", index);
        }

        return index;
    }

    public static int ForLoop()
    {
        var res = 0;
        for (var i = 1; i <= 5; i++) res = i;
        Console.WriteLine("ForLoop: {0}", res);
        return res;
    }

    public static int ForEachLoop()
    {
        var res = 0;
        var items = new List<int> { 1, 2, 3, 5, 8, 13 };
        foreach (var i in items) res += i;
        return res;
    }
}