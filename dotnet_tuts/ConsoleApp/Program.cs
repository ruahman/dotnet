using CSharpLib;

namespace ConsoleApp;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("hello from ConsoleApp");
        Console.WriteLine(HelloWorld.Hello());
        var res = Console.ReadLine();
        Console.WriteLine(res);
    }
}