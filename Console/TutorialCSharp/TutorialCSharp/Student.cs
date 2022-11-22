using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCSharp
{
    public class Student : User, ITalk
    {
        public Student(string first, string last) : base(first, last) { }

        public override void HelloToConsole()
        {
            Console.WriteLine("this was overriden");
        }

        public void ITalk()
        {
            Console.WriteLine("I am talking here");
        }

        public override void youNeedToOverRideMe()
        {
            Console.WriteLine("you need to override me");
        }

    }
}
