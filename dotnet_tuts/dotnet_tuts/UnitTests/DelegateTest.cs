using CSharpTut.Delegate;
using Xunit.Abstractions;

namespace UnitTests
{
    public class DelegateTest
    {
        public DelegateTest(ITestOutputHelper output)
        {
            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Theory]
        [InlineData(3.0,3.0, 6.0, 0.0, 0.0)]
        [InlineData(5.0, 5.0, 10.0, 0.0, 0.0)]
        [InlineData(6.0, 6.0, 12.0, 0.0, 0.0)]
        [Trait("CSharp","Delegate")]
        public void TestDelegate(double a, double b, double c, double d, double e)
        {
            var res = MyDelegate.Arithmetic(a, b);
            Assert.Equal(res.Item1, c);
            Assert.Equal(res.Item2, d);

            // get the result of last one
            Assert.Equal(res.Item3, e);

            Console.WriteLine(res.Item3);
        }

        [Theory]
        [InlineData(3.0, 6.0)]
        [InlineData(4.0, 8.0)]
        [InlineData(5.0, 10.0)]
        [Trait("CSharp", "Delegate")]
        public void TestLambda(double a, double b)
        {
            var res = MyDelegate.Lambda(a);
            Assert.Equal(res, b);
        }
    }
}
