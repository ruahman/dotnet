using CSharpLib.Generics;

namespace UnitTests;

public class GenericsTests
{
    // test
    [Theory]
    [InlineData(2, 3, 5.0)]
    [InlineData(2.2, 3.3, 5.5)]
    [InlineData("2", "3", 5.0)]
    public void TestGenricFunction<T>(T a, T b, double c)
    {
        var res = Generics.GetSum(a, b);
        Assert.Equal(c, res);
    }

    [Theory]
    [InlineData(2, 3, 6.0)]
    [InlineData(2.2, 3.3, 7.26)]
    [InlineData("2", "3", 6.0)]
    public void TestGenericClass<T>(T a, T b, double c)
    {
        var rec = new Rectangle<T>(a, b);
        Assert.Equal(c, rec.GetArea());
    }
}