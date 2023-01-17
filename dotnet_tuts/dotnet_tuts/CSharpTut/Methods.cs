using System;
using System.Reflection.Metadata.Ecma335;

namespace CSharpTut
{
    public class Methods
    {
        public static void SayHi(string name, int age)
        {
            Console.WriteLine($"Hello user {name}, you are {age} years old");
        }

        public static int Cube(int num)
        {
            double result = Math.Pow(num, 3);
            return Convert.ToInt32(result);
        }

        static string namedArguments(string child1, string child2, string child3)
        {
            string msg = $"{child1}, {child2}, {child3}";
            return msg;
        }

        public static string NamedArgments()
        {
            return namedArguments(child3: "John", child1: "Liam", child2: "Liam");
        }
    }
}
