using CSharpTut.Events;
using Xunit.Abstractions;

namespace UnitTests
{
    public class EventsTests
    {
        public EventsTests(ITestOutputHelper output)
        {
            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("CSharp","Events")]
        public void TestEvents()
        {
            Events.Test();
        }
    }
}
