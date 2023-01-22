using CSharpTut.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Student
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
    }

    public class AnonymousTypes
    {
        public static void TestAnonymousTypes()
        {
            // it is a class without a name, has public read only properties,
            // it can not have Propeties or methods,
            // they are read only
            var student = new { Id = 1, FirstName = "James", LastName = "Bond" };
            Console.WriteLine(student.Id); //output: 1
            Console.WriteLine(student.FirstName); //output: James
            Console.WriteLine(student.LastName); //output: Bond

            // Mostly, anonymous types are created using the Select clause of a LINQ queries
            // to return a subset of the properties from each object in the collection.

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 },
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20  },
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

            var students = from s in studentList
                           select new { Id = s.StudentID, Name = s.StudentName };

            foreach (var stud in students)
                Console.WriteLine(stud.Id + "-" + stud.Name);

            // Internally, all the anonymous types are directly derived from the System.Object class.
            // The compiler generates a class with some auto-generated name and applies the appropriate type to each property
            // based on the value expression. Use GetType() method to see the name. 
            Console.WriteLine(student.GetType().ToString());
        }
    }
}
