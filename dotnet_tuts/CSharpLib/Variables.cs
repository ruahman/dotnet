namespace CSharpLib;

public abstract class Variables
{
    public static (string, string, int, string, bool, char, int, string) Strings()
    {
        const string myName = "Diego";

        const string interpolation = $"my name is {myName}";

        const string literal = @"G:\My Drive\Documents\denote";

        // this was mapped in UnitTester
        Console.WriteLine("dont need output!!!!");

        return (
            myName,
            interpolation,
            interpolation.Length,
            myName.ToUpper(),
            interpolation.Contains("Diego"),
            myName[0],
            interpolation.IndexOf("Diego", StringComparison.Ordinal),
            literal
        );
    }

    public static void Chars()
    {
        const char myChar = 'A';

        Console.WriteLine("{0:c}", myChar);
    }

    public static void Integers()
    {
        const int myAge = 42;
        var abs = Math.Abs(-7);

        Console.WriteLine("{0}", myAge);
        Console.WriteLine("{0}", abs);

        // if you need to use a keyword as a variable name, you can use the @ symbol
        const int @int = 43;

        Console.WriteLine(@int);
    }

    public static void Floats()
    {
        const float f = 3.12f; // least accurate
        const double d = 3.33333;
        const decimal dec = 4.566666666m; // most acurate
        var pow = Math.Pow(3, 3);

        Console.WriteLine("{0:f}", f);
        Console.WriteLine("{0:f}", d);
        Console.WriteLine("{0:f}", dec);
        Console.WriteLine("{0:f}", pow);
    }

    public static void Booleans()
    {
        var x = true;
        Console.WriteLine("{0}", x);
    }

    public static void Nullable()
    {
        int? x = null;
        Console.WriteLine("null: {0}", x.HasValue ? x : "null");
    }

    public static void Casting()
    {
        const double myDouble = 9.78;
        const int myInt = (int)myDouble; // Manual casting: double to int

        Console.WriteLine("{0}", myDouble); // Outputs 9.78
        Console.WriteLine("{0}", myInt); // Outputs 9
    }

    public static void Conversion()
    {
        var myInt = 10;
        var myDouble = 5.25;
        var myBool = true;

        var res1 = Convert.ToString(myInt); // convert int to string
        var res2 = Convert.ToDouble(myInt); // convert int to double
        var res3 = Convert.ToInt32(myDouble); // convert double to int
        var res4 = Convert.ToString(myBool); // convert bool to string

        Console.WriteLine("{0}", res1);
        Console.WriteLine("{0}", res2);
        Console.WriteLine("{0}", res3);
        Console.WriteLine("{0}", res4);
    }

    public static void TryParse()
    {
        var number = "128";

        var success = int.TryParse(number, out var parseValue);

        Console.WriteLine("{0}", success);
    }

    // you can use out to return more than on variable from a function
    public static void OutVariables()
    {
        DateTime dt;
        DateTime.TryParse("2/22/2023", out dt);
        DateTime.TryParse("2/22/2024", out var dt2);

        Console.WriteLine("{0}", dt);
        Console.WriteLine("{0}", dt2);
    }
}