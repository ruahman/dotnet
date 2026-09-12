using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class StructTests
{
    private readonly ITestOutputHelper _output;

    public StructTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void Coordinate_DefaultConstructor_ShouldHaveZeroValues()
    {
        var point = new Coordinate();

        Assert.Equal(0, point.x);
        Assert.Equal(0, point.y);
    }

    [Fact]
    public void Coordinate_ParameterizedConstructor_ShouldSetFieldValues()
    {
        var point = new Coordinate(10, 20);

        Assert.Equal(10, point.x);
        Assert.Equal(20, point.y);
    }

    [Fact]
    public void Coordinate_ValueTypeSemantics_ShouldCopyByValue()
    {
        var point1 = new Coordinate(5, 15);
        var point2 = point1;
        point2.x = 99;

        Assert.Equal(5, point1.x);
        Assert.Equal(99, point2.x);
    }

    [Fact]
    public void Coordinates_ShouldReturnExpectedTuple()
    {
        var (p1, p2, p3) = Struct.Coordinates();

        Assert.Equal(0, p1.x);
        Assert.Equal(0, p1.y);

        Assert.Equal(10, p2.x);
        Assert.Equal(20, p2.y);

        Assert.Equal(10, p3.x);
        Assert.Equal(20, p3.y);
    }
}
