using DataStructsAndAlgorithms.TimeComplexity;
using Xunit.Abstractions;

namespace UnitTests
{
    public class TimeComplexityTests
    {

        private readonly ITestOutputHelper _output;

        public TimeComplexityTests(ITestOutputHelper output)
        {
            _output = output;

            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("DataStructsAndAlgorithms", "TimeComplexity")]
        public void Fun1Test()
        {
            var res = TimeComplexity.Fun1(8);
            Assert.Equal(8, res);
        }
    }
}
