using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
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
            if(gpa >= 3.5)
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
            set { 
                if(value == "G" || value == "PG" || value == "R")
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
        public string? LastName { get; set;}    

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

    public class Classes
    {
        public static Book CreateBook()
        {
            var book1 = new Book("Dune","Diego Vila", 300);

            

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
