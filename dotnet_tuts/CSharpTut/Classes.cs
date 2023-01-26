
namespace CSharpTut.Classes
{
    public class Book
    {
        public string? title;
        public string? author;
        public int? pages;

        public Book(string title, string author, int pages)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
        }
    }

    public class Student
    {
        public string name;
        public string major;
        public double gpa;

        public Student(string name, string major, double gpa)
        {
            this.name = name;
            this.major = major;
            this.gpa = gpa;
        }

        public bool HasHonors()
        {
            if (gpa >= 3.5)
            {
                return true;
            }

            return false;
        }
    }

    public class Movie
    {
        private readonly string title;
        private string rating;
        private readonly string director;

        public Movie(string title, string director, string rating)
        {
            this.title = title;
            Rating = rating;
            this.director = director;
        }

        public string Rating
        {
            get { return rating; }
            set
            {
                if (value == "G" || value == "PG" || value == "R")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }
    }

    public class Chef
    {
        public virtual string CookBacon()
        {
            string msg = "I'm cooking bacon";
            return msg;
        }
    }

    public class ItalianChef : Chef
    {
        public override string CookBacon()
        {
            string msg = "I cook bacon the italian way";
            return msg;
        }

        public string CookPizza()
        {
            string msg = "I can do some other things";
            return msg;
        }
    }

    public class Person
    {
        string _middleName = "Ramon";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + LastName;
            }
        }

        public string GetFullName()
        {
            return FirstName + LastName;
        }

    }

    public class Car
    {
        public string? Make { get; set; }
        public string? Modle { get; set; }
        public string? Year { get; set; }
    }

    // If you don't want other classes to inherit from a class, don't know why you would do that
    sealed class Vehicle
    {
        public string? Model { get; set; }
    }

    // this can never happen
    //class Car : Vehicle
    //{

    //}

    // abstract class is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
    abstract class Animal
    {
        // Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
        public abstract void animalSound();
        public void sleep()
        {
            Console.WriteLine("Zzz");
        }
    }




    public static class Classes
    {
        public static Book CreateBook()
        {
            var book1 = new Book("Dune", "Diego Vila", 300);



            return book1;
        }

        public static bool HasHonors()
        {
            var student = new Student("Diego", "computer science", 3.5);
            var res = student.HasHonors();
            return res;
        }

        public static Movie GetMovie()
        {
            var movie = new Movie("Dune", "Tim burton", "PG");
            return movie;
        }

        public static Chef GetItalianChef()
        {
            var chef = new ItalianChef();
            return chef;
        }

        public static Person GetPerson()
        {
            var person = new Person();
            person.FirstName = "Diego";
            person.LastName = "Vila";

            return person;
        }
    }
}
