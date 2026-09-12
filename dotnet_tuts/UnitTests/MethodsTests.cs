using CSharpLib;

namespace UnitTests;

public class MethodsTests
{
    [Fact]
    public void Cube()
    {
        var res = Methods.Cube(3);
        Assert.Equal(27, res);
    }

    [Fact]
    public void NamedArgument()
    {
        var res = Methods.NamedArgments();
        Assert.Equal("Liam, Liam, John", res);
    }

    [Fact]
    public void OutParameters()
    {
        var msg = "test me";
        var res = Methods.OutParameter(msg);
        Assert.Equal("Diego", res);
    }

    [Fact]
    public void Refparameters()
    {
        int a = 4, b = 7;
        Methods.RefParameters(ref a, ref b);
        Assert.Equal(7, a);
        Assert.Equal(4, b);
    }
}