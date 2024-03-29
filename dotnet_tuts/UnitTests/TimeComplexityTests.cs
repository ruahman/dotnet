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
            // this is O(n)
            var res = TimeComplexity.Fun1(10);
            Assert.Equal(10, res);
        }

        [Fact]
        [Trait("DataStructsAndAlgorithms", "TimeComplexity")]
        public void Fun2Test()
        {
            // this is O(n^2)
            var res = TimeComplexity.Fun2(10);
            Assert.Equal(100, res);
        }

        [Fact]
        [Trait("DataStructsAndAlgorithms", "TimeComplexity")]
        public void Fun3Test()
        {
            // this is O(n^3)
            var res = TimeComplexity.Fun3(10);
            Assert.Equal(1000, res);
        }

        [Fact]
        [Trait("DataStructsAndAlgorithms", "TimeComplexity")]
        public void Fun4Test()
        {
            // this is O(log(n))
            var res = TimeComplexity.Fun4(16);
            Assert.Equal(4, res);
        }
    }
}
