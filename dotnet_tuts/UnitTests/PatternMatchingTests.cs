using CSharpTut;
using Xunit.Abstractions;

namespace UnitTests
{
    public class PatternMatchingTests
    {

        private readonly ITestOutputHelper output;

        public PatternMatchingTests(ITestOutputHelper output)
        {
            this.output = output;

            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("CSharp", "PatternMatching")]
        public void TestPatternMatching()
        {
            var res = CSharpTut.PatternMatching.PatternMatching.Demo();
            Assert.Equal("this is a small circle: CSharpTut.PatternMatching.Circle", res);
        }
    }
}
