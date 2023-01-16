using System;

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
    }
}
