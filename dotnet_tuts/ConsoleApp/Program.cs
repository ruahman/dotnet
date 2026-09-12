using CSharpLib;

namespace ConsoleApp;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        // show arguments
        Console.WriteLine(args);
        Console.WriteLine("hello from ConsoleApp");
        Console.WriteLine(HelloWorld.Hello());
        var res = Console.ReadLine();
        Console.WriteLine($"string interpolation {res}");
    }
}