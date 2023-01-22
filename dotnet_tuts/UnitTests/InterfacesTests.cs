using CSharpTut;

namespace UnitTests
{
    public class InterfacesTests
    {
        [Fact]
        [Trait("CSharp", "Interface")]
        public static void SingleInheretance()
        {
            var res = Interface.SingleIhertance();
            Assert.IsAssignableFrom<ITalk>(res);
        }

        [Fact]
        [Trait("CSharp", "Interface")]
        public static void MultipleInheretance()
        {
            var res = Interface.MultipleInheritance();
            Assert.IsAssignableFrom<IFirstInterface>(res);
            Assert.IsAssignableFrom<ISecondInterface>(res);
        }
    }
}
