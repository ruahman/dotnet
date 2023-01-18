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

        // and out parameter must be assigned a value
        static bool outparameter(out string msg)
        {
            msg = "Diego";
            return true;
        }

        public static string OutParameter(string msg)
        {
            _ = outparameter(out msg);
            return msg;
        }

        // a ref parameter can be modified
        public static void RefParameters(ref int a, ref int b)
        {
            int swap = a;
            a = b;
            b = swap;
        }

        // in parameters can not be changed
        public static void InParameters(in int a)
        {
            //a = 7;
           
        }
    }
}
