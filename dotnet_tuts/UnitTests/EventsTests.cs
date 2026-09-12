using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class EventsTests
{
    public EventsTests(ITestOutputHelper output)
    {
        // console now outputs to xUnit
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void TestEvents()
    {
        Events.Test();
    }

    [Fact]
    public void TestEvents2()
    {
        Events.Test2();
    }
}