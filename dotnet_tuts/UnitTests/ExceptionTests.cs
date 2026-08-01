using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class ExceptionTests
{
    private readonly ITestOutputHelper _output;

    public ExceptionTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Theory]
    [InlineData(1, 2, true)]
    [InlineData(1, 3, true)]
    [InlineData(1, 0, false)]
    [Trait("Category", "Exception")]
    public void DivideByZeroException(int a, int b, bool res)
    {
        var result = Exceptions.DivideByZeroException(a, b);
        Assert.Equal(res, result);
    }
}