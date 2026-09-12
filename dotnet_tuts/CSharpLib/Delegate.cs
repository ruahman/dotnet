namespace CSharpLib.Delegate;

// delegate type is like a function pointer
public delegate double Arithmetic(double num1, double num2);

public delegate double doubleIt(double val);

public class MyDelegate
{
    // these are delegates
    private static Arithmetic add, sub, addSub;

    public static double Add(double num1, double num2)
    {
        Console.WriteLine($"Add {num1} {num2}");
        return num1 + num2;
    }

    public static double Sub(double num1, double num2)
    {
        Console.WriteLine($"Sub {num1} {num2}");
        return num1 - num2;
    }

    public static (double, double, double) Arithmetic(double a, double b)
    {
        // set delegates
        add = Add;
        sub = Sub;

        // this runs both
        addSub += Add;
        addSub += Sub;

        return (add(a, b), sub(a, b), addSub(a, b));
    }

    public static double Lambda(double a)
    {
        doubleIt dblIt = x => x * 2;

        return dblIt(a);
    }

    private static int Sum(int x, int y)
    {
        return x + y;
    }

    public static void TestFuncDelegate()
    {
        // has return type
        var add = Sum;

        var result = add(10, 10);

        Console.WriteLine(result);

        Func<int, int, int> Sum2 = (x, y) => x + y;

        var result2 = Sum2(2, 3);

        Console.WriteLine(result2);
    }

    private static void ConsolePrint(int i)
    {
        Console.WriteLine(i);
    }

    public static void TestActionDelegate()
    {
        // no return type
        var printActionDel = ConsolePrint;
    }
}