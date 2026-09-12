using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class ExtentionMethodTests
{
    private ITestOutputHelper _output;

    public ExtentionMethodTests(ITestOutputHelper output)
    {
        _output = output;
        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void Test()
    {
        ExtentionMethods.Test();
    }
}