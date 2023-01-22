using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class PartialClasses
    {
        // In C#, you can split the implementation of a class, a struct, a method, or an interface
        // in multiple .cs files using the partial keyword. The compiler will combine all the implementation
        // from multiple .cs files when the program is compiled. 
        public partial class Employee
        {
            public int EmpId { get; set; }
            public string? Name { get; set; }
        }

        public partial class Employee
        {
            //constructor
            public Employee(int id, string name)
            {
                this.EmpId = id;
                this.Name = name;
            }

            public void DisplayEmpInfo()
            {
                Console.WriteLine(this.EmpId + " " + this.Name);
            }
        }

        // if you want to reference a method in the other partial class then you
        // need to make a partial method
        public partial class Employee2
        {
            public Employee2()
            {
                GenerateEmployeeId();
            }
            public int EmpId { get; set; }
            public string? Name { get; set; }

            partial void GenerateEmployeeId();

        }

        public partial class Employee2
        {
            partial void GenerateEmployeeId()
            {
                this.EmpId = 312;
            }
        }


        public static void TestPartialClasses()
        {

        }
    }
}
