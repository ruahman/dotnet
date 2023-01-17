using CSharpTut;

namespace UnitTests
{
    public class MethodsTests
    {
        [Fact]
        [Trait("CSharp","Methods")]
        public void Cube()
        {
            var res = Methods.Cube(3);
            Assert.Equal(27, res);
        }

        [Fact]
        [Trait("CSharp", "Methods")]
        public void NamedArgument()
        {
            var res = Methods.NamedArgments();
            Assert.Equal("Liam, Liam, John", res);
        }
    }
}
