using CSharpTut;


namespace UnitTests
{
    public class IfStatmentsTests
    {
        [Fact]
        [Trait("CSharp","IfStatements")]
        public void IsMale()
        {
            var res = IfStatements.IsMale();
            Assert.True(res);
        }

        [Fact]
        [Trait("CSharp", "IfStatements")]
        public void IsMax()
        {
            var res = IfStatements.GetMax(2, 3);
            Assert.Equal(3, res);
        }

        [Theory]
        [InlineData(true,11)]
        [InlineData(false, 77)]
        [Trait("CSharp", "IfStatements")]
        public void Ternery(bool condition, int res)
        {
            var result = IfStatements.TernaryOperator(condition);
            Assert.Equal(res, result);
        }
    }
}
