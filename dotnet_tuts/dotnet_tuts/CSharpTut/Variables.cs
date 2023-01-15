using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Variables
    {
        public static (string, string, int, string, bool, char, int) Strings()
        {
            string myName = "Diego";

            string interpolation = $"my name is {myName}";

            return (
                myName,
                interpolation,
                interpolation.Length,
                myName.ToUpper(),
                interpolation.Contains("Diego"),
                myName[0],
                interpolation.IndexOf("Diego")
            );
        }

        public static char Chars()
        {
            char mychar = 'A';

            return mychar;
        }

        public static (int, int) Integers()
        {
            int myAge = 42;
            int abs = Math.Abs(-7);
            

            return (myAge, abs);
        }

        public static (float, double, decimal, double) Floats()
        {
            float x = 3.12f; // least accurate
            double y = 3.33333; // default
            decimal z = 4.566666666m;  // most acurate
            var pow = Math.Pow(3, 3);

            return (x, y, z, pow);
        }

        public static bool Boolean()
        {
            bool x = true;
            return x;
        }
    }
}
