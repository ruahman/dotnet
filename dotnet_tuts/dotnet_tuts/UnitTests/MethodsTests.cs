using CSharpTut;

namespace UnitTests
{
    public class MethodsTests
    {
        [Fact]
        [Trait("Category","Methods")]
        public void Cube()
        {
            var res = Methods.Cube(3);
            Assert.Equal(27, res);
        }
    }
}
