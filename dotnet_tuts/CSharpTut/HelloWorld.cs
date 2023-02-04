namespace CSharpTut
{
    public class HelloWorld
    {
        public static String Hello()
        {
            String msg = "Hello World";
            System.Console.WriteLine(msg);
            return msg;
        }

        public static String Goodbye()
        {
            String msg = "Goodbye";
            return msg;
        }

        public static String ReadLine()
        {
            string? name = Console.ReadLine();
            string msg = $"my name is {name}";
            System.Console.WriteLine(msg);
            return msg;
        }
    }
}
