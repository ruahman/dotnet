using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class EnumTests
{
    public EnumTests(ITestOutputHelper output)
    {
        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    private void TestEnums()
    {
        Enums.TestEnum();
    }
}