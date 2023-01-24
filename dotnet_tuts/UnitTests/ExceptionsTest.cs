using CSharpTut;

namespace UnitTests
{
    public class ExceptionsTest
    {
        [Theory]
        [InlineData(1,2,true)]
        [InlineData(1, 3, true)]
        [InlineData(1, 0, false)]
        [Trait("Category","Exception")]
        public void DivideByZeroException(int a, int b, bool res)
        {
            var result = Exceptions.DivideByZeroException(a,b);
            Assert.Equal(res,result);
        }
    }
}
