using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class TuplesTests
{
    private readonly ITestOutputHelper _output;

    public TuplesTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void TestTuples_ShouldExecuteWithoutExceptions()
    {
        var exception = Record.Exception(() => Tuples.TestTuples());

        Assert.Null(exception);
    }

    [Fact]
    public void ValueTupleTest_ShouldExecuteWithoutExceptions()
    {
        var exception = Record.Exception(() => Tuples.ValueTupleTest());

        Assert.Null(exception);
    }

    [Fact]
    public void Tuple_CreateAndAccessItems_ShouldProvideExpectedValues()
    {
        var person = Tuple.Create(1, "Steve", "Jobs");

        Assert.Equal(1, person.Item1);
        Assert.Equal("Steve", person.Item2);
        Assert.Equal("Jobs", person.Item3);
    }

    [Fact]
    public void ValueTuple_NamedElementsAndDeconstruction_ShouldProvideExpectedValues()
    {
        (int Id, string FirstName, string LastName) person = (1, "Bill", "Gates");

        Assert.Equal(1, person.Id);
        Assert.Equal("Bill", person.FirstName);
        Assert.Equal("Gates", person.LastName);

        var (id, firstName, lastName) = person;

        Assert.Equal(1, id);
        Assert.Equal("Bill", firstName);
        Assert.Equal("Gates", lastName);
    }
}
