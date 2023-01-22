using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Nullable
    {
        public static void TestNullable()
        {
            // allow you to assign a null to a value type
            Nullable<int> i = null;

            if (i.HasValue)
                Console.WriteLine(i.Value); // or Console.WriteLine(i)
            else
                Console.WriteLine("Null");

            Console.WriteLine(i.GetValueOrDefault());

            // shorthand syntax
            int? x = null;
            double? D = null;

            // Use the '??' operator to assign a nullable type to a non-nullable type.
            // So to mitigate the risk of an exception,
            // we have used the '??' operator to specify that if i is null then assign 0 to j.
            int j = x ?? 0;

            Console.WriteLine($"{D}, {j}");
        }
    }
}
