namespace CSharpLib;

public static class ConditionStatements
{
    public static bool IsMale()
    {
        var isMale = true;
        var isTall = true;
        Console.WriteLine("IsMale: {0}", isMale);
        Console.WriteLine("isTall: {0}", isTall);

        bool result;
        if (isMale && isTall)
            result = true;
        else if (isMale && !isTall)
            result = true;
        else
            result = false;


        return result;
    }

    public static void Switch(string day)
    {
        switch (day)
        {
            case "Monday":
                Console.WriteLine("It's Monday");
                break;
            default:
                Console.WriteLine("It's not Monday");
                break;
        }
    }

    public static void GetMax(int a, int b)
    {
        if (a > b)
            Console.WriteLine("a is greater than b");
        else
            Console.WriteLine("b is greater than a");
    }

    public static int TernaryOperator(bool condition)
    {
        var res = condition ? 11 : 77;
        Console.WriteLine("TernaryOperator: {0}", res);
        return res;
    }
}