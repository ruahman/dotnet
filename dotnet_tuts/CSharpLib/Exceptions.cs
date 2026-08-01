namespace CSharpLib;

public class Exceptions
{
    public static bool DivideByZeroException(int a, int b)
    {
        var res = false;
        var result = false;
        try
        {
            var num = a / b;
            res = true;
        }
        catch (DivideByZeroException e)
        {
            res = false;
        }
        finally
        {
            result = res;
        }

        Console.WriteLine($"Result: {result}");

        return result;
    }
}