using CSharpTut.Generics;

namespace UnitTests
{
    public class GenericsTests
    {
        [Theory]
        [InlineData(2,3,5.0)]
        [InlineData(2.2, 3.3, 5.5)]
        [InlineData("2","3",5.0)]
        [Trait("CSharp","Generics")]
        public void GetSum<T>(T a, T b, double c)
        {
            var res = Generics.GetSum(a, b);
            Assert.Equal(c, res);
        }

        [Theory]
        [InlineData(2, 3, 6.0)]
        [InlineData(2.2, 3.3, 7.26)]
        [InlineData("2", "3", 6.0)]
        [Trait("CSharp", "Generics")]
        public void GetArea<T>(T a, T b, double c)
        {
            var rec = new Rectangle<T>(a, b);
            Assert.Equal(c, rec.GetArea());
        }
    }
}
