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
    }
}
