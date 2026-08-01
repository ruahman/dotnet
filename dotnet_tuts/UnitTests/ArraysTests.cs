using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class ArraysTests
{
    private readonly ITestOutputHelper _output;

    public ArraysTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void ArraysOfInter()
    {
        var (elements, element) = Arrays.ArrayOfIntegers();
        Assert.Equal(new[] { 1, 2, 3, 5, 8, 13 }, elements);
        Assert.Equal(6, elements.Length);
        Assert.Equal(5, element);
    }

    [Fact]
    public void ArraysOfString()
    {
        var res = Arrays.ArrayOfString();
        Assert.Equal(6, res.Length);
        Assert.Equal("Diego", res[0]);
        Assert.Equal("Vila", res[1]);
    }

    [Fact]
    public void Arrays2d()
    {
        var res = Arrays.Arrays2D();
        Assert.Equal(new[,]
        {
            { 1, 2 },
            { 2, 3 },
            { 3, 4 },
            { 4, 5 }
        }, res);
    }

    [Fact]
    public void JaggedArray()
    {
        var res = Arrays.JaggedArrays();
        Assert.Equal(3, res.Length);
        Assert.Equal(2, res[1].Length);
    }
}