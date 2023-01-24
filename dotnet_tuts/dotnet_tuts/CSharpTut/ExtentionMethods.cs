using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut.ExtentionMethods
{
    // Extension methods allow you to inject additional methods without modifying, deriving or recompiling the original class,
    // struct or interface.

    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }

    public class ExtentionMethods
    {
        

        public static void Test()
        {
            int i = 10;

            bool result = i.IsGreaterThan(100);

            Console.WriteLine(result);
        }
    }
}
