using CSharpLib.Classes;
using Xunit.Abstractions;

namespace UnitTests;

public class ClassesTests
{
    private readonly ITestOutputHelper _output;

    public ClassesTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void CreateBook()
    {
        var book = new Book("Dune", "Diego Vila", 300);
        _output.WriteLine(book.ToString());
        Assert.Equal("Dune", book.title);
    }

    [Fact]
    public void HasHonors()
    {
        var student = new Student("Diego", "computer science", 3.5);
        _output.WriteLine(student.ToString());
        var res = student.HasHonors();
        Assert.True(res);
    }

    [Fact]
    public void GetMovie()
    {
        var movie = new Movie("Dune", "Tim burton", "PG");
        _output.WriteLine(movie.ToString());
        Assert.Equal("PG", movie.Rating);
    }

    [Fact]
    public void GetItalianChef()
    {
        var chef = new ItalianChef();
        _output.WriteLine(chef.ToString());
        Assert.Equal("I cook bacon the italian way", chef.CookBacon());
        Assert.Equal("I can do some other things", chef.CookPizza());
    }
}