using CSharpTut;

namespace UnitTests
{
    public class CollectionsTests
    {
        [Fact]
        [Trait("Category", "Collections")]
        public void Lists()
        {
            var res = Collections.Lists();
            Assert.True(res.Item1.SequenceEqual(new List<int>() { 5, 4, 3, 2, 1 }));
            Assert.True(res.Item2.SequenceEqual(new List<int>() { 1,2,3,5,8,13 }));
            Assert.True(res.Item3);
        }
    }
}
