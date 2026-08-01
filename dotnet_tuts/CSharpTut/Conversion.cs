namespace CSharpTut;

public static class Conversion
{
    public static void Implicit()
    {
        Console.WriteLine("Implicit conversion");
        const byte b = 10;
        const int i = b;
        Console.WriteLine("{0}", i);
        const float f = i;
        Console.WriteLine("{0:f}", f);
    }

    public static void Explicit()
    {
        Console.WriteLine("Explicit conversion");
        var i = 1;
        var b = (byte)i;
        Console.WriteLine("{0}", b);
        const float f = 1.0f;
        const int iii = (int)f;
        Console.WriteLine("{0:f}", iii);
        var s = "1";
        var iInt = Convert.ToInt32(s);
        var jInt = int.Parse(s);
        Console.WriteLine("{0}", iInt);
        Console.WriteLine("{0}", jInt);
    }
}