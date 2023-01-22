using CSharpTut.LinqTut;
using Xunit.Abstractions;

namespace UnitTests
{
    public class LinqTests
    {
        private readonly ITestOutputHelper output;

        public LinqTests(ITestOutputHelper output)
        {
            this.output = output;

            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("CSharp","Linq")]
        public void GetCars()
        {
            var res = LinqTut.SelectCars();

            Assert.Equal(4, res.Item1.Count());
            Assert.Equal(3, res.Item2.Count());
        }
    }
}
