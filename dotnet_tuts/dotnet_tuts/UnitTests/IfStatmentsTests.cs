using CSharpTut;


namespace UnitTests
{
    public class IfStatmentsTests
    {
        [Fact]
        [Trait("Category","IfStatements")]
        public void IsMale()
        {
            var res = IfStatements.IsMale();
            Assert.True(res);
        }

        [Fact]
        [Trait("Category", "IfStatements")]
        public void IsMax()
        {
            var res = IfStatements.GetMax(2, 3);
            Assert.Equal(3, res);
        }
    }
}
