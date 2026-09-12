using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class StringsTests
{
    private readonly ITestOutputHelper _output;

    public StringsTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void TestStrings_ShouldExecuteWithoutExceptions()
    {
        var exception = Record.Exception(() => Strings.TestStrings());

        Assert.Null(exception);
    }

    [Fact]
    public void StringConstructedFromCharArray_ShouldMatchLiteral()
    {
        var literal = "Hello, World!";
        char[] chars = { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!' };
        var fromChars = new string(chars);

        Assert.Equal(literal, fromChars);
    }

    [Fact]
    public void StringInterpolation_ShouldFormatCorrectly()
    {
        var s = "Hello, World!";
        var message = $"string interpolation {s}";

        Assert.Equal("string interpolation Hello, World!", message);
    }
}
