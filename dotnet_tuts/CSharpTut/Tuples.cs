using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Tuples
    {
        public static void TestTuples()
        {
            Tuple<int, string, string> person = new Tuple<int, string, string>(1, "Steve", "Jobs");
            Console.WriteLine(person.Item1); // returns 1
            Console.WriteLine(person.Item2); // returns "Steve"
            Console.WriteLine(person.Item3); // returns "Jobs"

            var person2 = Tuple.Create(1, "Steve", "Jobs");


        }

        public static void ValueTupleTest()
        {
            var person = (1, "Bill", "Gates");
            ValueTuple<int, string, string> person2 = (1, "Bill", "Gates");
            (int, string, string) person3 = (1, "James", "Bond");

            (int Id, string FirstName, string LastName) person4 = (1, "Bill", "Gates");
            Console.WriteLine(person4.Id);   // returns 1
            Console.WriteLine(person4.FirstName);  // returns "Bill"
            Console.WriteLine(person4.LastName); // returns "Gates"

            // deconstuct
            (int x, string name, string last) = person4;
            Console.WriteLine($"{x} {name} {last}");
        }
    }
}
