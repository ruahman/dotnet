using CSharpLib;

namespace UnitTests;

public class InterfacesTests
{
    [Fact]
    public static void SingleInheretance()
    {
        var res = Interface.SingleIhertance();
        Assert.IsAssignableFrom<ITalk>(res);
    }

    [Fact]
    public static void MultipleInheretance()
    {
        var res = Interface.MultipleInheritance();
        Assert.IsAssignableFrom<IFirstInterface>(res);
        Assert.IsAssignableFrom<ISecondInterface>(res);
    }
}