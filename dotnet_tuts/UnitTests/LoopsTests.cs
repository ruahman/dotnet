using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class LoopsTests
{
    private readonly ITestOutputHelper _output;

    public LoopsTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void WhileLoops()
    {
        var res = Loops.WhileLoop();
        Assert.Equal(6, res);
    }

    [Fact]
    public void ForLoops()
    {
        var res = Loops.ForLoop();
        Assert.Equal(5, res);
    }

    [Fact]
    public void ForEachLoops()
    {
        var res = Loops.ForEachLoop();
        Assert.Equal(32, res);
    }
}