using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut.GenericConstraints
{
    // give constains to what you can put in generic

    // a generic class with a constraint to reference types when instantiating the generic class.
    class DataStore<T> where T : class
    {
        public T? Data { get; set; }
    }

    // the struct constraint that restricts type argument to be non-nullable value type only.
    class DataStore2<T> where T : struct
    {
        public T Data { get; set; }
    }

    // the base class constraint that restricts type argument to be a derived class of the specified class, abstract class,
    // or an interface.
    class DataStore3<T> where T : IEnumerable
    {
        public T? Data { get; set; }
    }

    public class GenericConstaints
    {
        public static void TestGenericConstains()
        {

        }
    }
}
