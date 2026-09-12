namespace CSharpLib;

public class Strings
{
    public static void TestStrings()
    {
        var s = "Hello, World!";
        char[] chars = { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!' };
        var s2 = new string(chars);
        Console.WriteLine(s);
        Console.WriteLine(s2);

        var message = $"string interpolation {s}";
        Console.WriteLine(message);

        // get length
        Console.WriteLine(s.Length);

        // split
        var words = s.Split(' ');
        Console.WriteLine(words[1]);

        // raw
        var raw = @"raw \t\t\t\t string";
        Console.WriteLine(raw);
    }
}