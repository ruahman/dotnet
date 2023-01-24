using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class Enum
    {
        public void TestEnum()
        {
            Console.WriteLine(WeekDays.Monday); // Monday
            Console.WriteLine(WeekDays.Tuesday); // Tuesday
            Console.WriteLine(WeekDays.Wednesday); // Wednesday
            Console.WriteLine(WeekDays.Thursday); // Thursday
            Console.WriteLine(WeekDays.Friday); // Friday
            Console.WriteLine(WeekDays.Saturday); // Saturday
            Console.WriteLine(WeekDays.Sunday); // Sunday
        }
    }
}
