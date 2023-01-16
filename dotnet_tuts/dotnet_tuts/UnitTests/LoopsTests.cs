using CSharpTut;

namespace UnitTests
{
    public class LoopsTests
    {
        [Fact]
        [Trait("Category", "Loops")]
        public void WhileLoops()
        {
            var res = Loops.WhileLoop();
            Assert.Equal(6, res);
        }

        [Fact]
        [Trait("Category", "Loops")]
        public void ForLoops()
        {
            var res = Loops.ForLoop();
            Assert.Equal(5, res);
        }

        [Fact]
        [Trait("Category", "Loops")]
        public void ForEachLoops()
        {
            var res = Loops.ForEachLoop();
            Assert.Equal(32, res);
        }
    }
}
