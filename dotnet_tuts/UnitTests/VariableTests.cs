using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class VariableTests
{
    private readonly ITestOutputHelper _output;

    public VariableTests(ITestOutputHelper output)
    {
        _output = output;

        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void Strings()
    {
        var (first, second, length, upper, contains, myChar, idx, literal) = Variables.Strings();
        Assert.Equal("Diego", first);
        Assert.Equal("my name is Diego", second);
        Assert.Equal(16, length);
        Assert.Equal("DIEGO", upper);
        Assert.True(contains);
        Assert.Equal('D', myChar);
        Assert.Equal(11, idx);
        Assert.Equal(@"G:\My Drive\Documents\denote", literal);
        _output.WriteLine(second);
    }

    [Fact]
    public void Chars()
    {
        Variables.Chars();
    }

    [Fact]
    public void Integers()
    {
        Variables.Integers();
    }

    [Fact]
    public void Floats()
    {
        Variables.Floats();
    }

    [Fact]
    public void Booleans()
    {
        Variables.Booleans();
    }

    [Fact]
    public void Nullable()
    {
        Variables.Nullable();
    }

    [Fact]
    public void Casts()
    {
        Variables.Casting();
    }

    [Fact]
    public void Conversion()
    {
        Variables.Conversion();
    }


    [Fact]
    public void TryParse()
    {
        Variables.TryParse();
    }

    [Fact]
    public void OutVariables()
    {
        Variables.OutVariables();
    }
}