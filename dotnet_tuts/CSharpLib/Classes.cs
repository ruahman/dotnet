namespace CSharpLib.Classes;

public class Book
{
    public string? author;
    public int? pages;
    public string? title;

    public Book(string title, string author, int pages)
    {
        this.title = title;
        this.author = author;
        this.pages = pages;
    }
}

public class Student
{
    public double gpa;
    public string major;
    public string name;

    public Student(string name, string major, double gpa)
    {
        this.name = name;
        this.major = major;
        this.gpa = gpa;
    }

    public bool HasHonors()
    {
        if (gpa >= 3.5) return true;

        return false;
    }
}

public class Movie
{
    private readonly string director;
    private readonly string title;
    private string rating;

    public Movie(string title, string director, string rating)
    {
        this.title = title;
        Rating = rating;
        this.director = director;
    }

    public string Rating
    {
        get => rating;
        set
        {
            if (value == "G" || value == "PG" || value == "R")
                rating = value;
            else
                rating = "NR";
        }
    }
}

public class Chef
{
    public virtual string CookBacon()
    {
        var msg = "I'm cooking bacon";
        return msg;
    }
}

public class ItalianChef : Chef
{
    public override string CookBacon()
    {
        var msg = "I cook bacon the italian way";
        return msg;
    }

    public string CookPizza()
    {
        var msg = "I can do some other things";
        return msg;
    }
}

public class Person
{
    private string _middleName = "Ramon";
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string FullName => FirstName + LastName;

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
internal sealed class Vehicle
{
    public string? Model { get; set; }
}

// this can never happen
//class Car : Vehicle
//{

//}

// abstract class is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
internal abstract class Animal
{
    // Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
    public abstract void animalSound();

    public void sleep()
    {
        Console.WriteLine("Zzz");
    }
}