using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialCSharp
{
    public abstract class User
    {

        public User(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }


        string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName.ToUpper();
            }

            set
            {
                _firstName = value;
            }

        }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string OutPut(int times)
        {
            var message = "";
            for (int idx = 0; idx < times; idx++)
            {
                message += $"{FirstName} {LastName}";
            }

            return message;

        }

        public static void PrintUser()
        {
            Console.WriteLine("this is a static method");
        }

        public override string ToString()
        {
            return FullName;
        }

        virtual public void HelloToConsole()
        {
            Console.WriteLine($"Hi my name is {FullName}");
        }

        abstract public void youNeedToOverRideMe();
    }
}
