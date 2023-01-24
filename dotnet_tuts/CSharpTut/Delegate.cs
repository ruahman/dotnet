using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut.Delegate
{
    public delegate double Arithmetic(double num1, double num2);

    public delegate double doubleIt(double val);

    

    public class MyDelegate
    {
        private static Arithmetic add, sub, addSub;
        public static double Add(double num1, double num2)
        {
            Console.WriteLine($"Add {num1} {num2}");
            return num1 + num2;
        }

        public static double Sub(double num1, double num2)
        {
            Console.WriteLine($"Sub {num1} {num2}");
            return num1 - num2;
        }

        public static (double,double,double) Arithmetic(double a, double b)
        {
            add = new Arithmetic(Add);
            sub = new Arithmetic(Sub);
            addSub += new Arithmetic(Add);
            addSub += new Arithmetic(Sub);

            return (MyDelegate.add(a,b), MyDelegate.sub(a,b), MyDelegate.addSub(a,b));

        }

        public static double Lambda(double a)
        {
            doubleIt dblIt = x => x * 2;

            return dblIt(a);
        }

        static int Sum(int x, int y)
        {
            return x + y;
        }

        public static void TestFuncDelegate()
        {
            // has return type
            Func<int, int, int> add = Sum;

            int result = add(10, 10);

            Console.WriteLine(result);

            Func<int, int, int> Sum2 = (x, y) => x + y;

            int result2 = Sum2(2, 3);

            Console.WriteLine(result2);
        }

        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }

        public static void TestActionDelegate()
        {
            // no return type
            Action<int> printActionDel = ConsolePrint;
        }
    }
}
