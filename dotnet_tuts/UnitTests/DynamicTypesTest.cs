using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class DynamicTypesTest
{
    public DynamicTypesTest(ITestOutputHelper output)
    {
        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    private void TestDynamicTypes()
    {
        DynamicTypes.TestDynamicTypes();
    }
}