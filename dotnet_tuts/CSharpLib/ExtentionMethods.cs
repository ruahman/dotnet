namespace CSharpLib;
// Extension methods allow you to inject additional methods without modifying, deriving or recompiling the original class,
// struct or interface.

// this extends int
public static class IntExtensions
{
    public static bool IsGreaterThan(this int i, int value)
    {
        return i > value;
    }
}

public abstract class ExtentionMethods
{
    public static void Test()
    {
        var i = 10;

        // run extention for int
        var result = i.IsGreaterThan(100);

        Console.WriteLine(result);
    }
}