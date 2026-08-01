using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class ConversionTests
{
    private readonly ITestOutputHelper _output;

    public ConversionTests(ITestOutputHelper output)
    {
        _output = output;

        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void Implicit()
    {
        Conversion.Implicit();
    }

    [Fact]
    public void Explicit()
    {
        Conversion.Explicit();
    }
}