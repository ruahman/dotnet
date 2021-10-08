using Xunit;
using DataStructuresAndAlgorithms;
using Xunit.Abstractions;

namespace UnitTests
{
    public class SortTests
    {
        private readonly ITestOutputHelper _testOut;

        public SortTests(ITestOutputHelper testOut)
        {
            _testOut = testOut;
        }

        [Fact]
        public void SelectionSortTest()
        {
            var res = SelectionSort.Sort(new[] { 4, 11, 2, -1, 20 });

            Assert.Equal(new[] { -1, 2, 4, 11, 20 }, res);
        }

        [Fact]
        public void InsertionSortTest()
        {
            var res = InsertionSort.Sort(new int[] { 4, 1, 11, -1, -2 });

            Assert.Equal(new int[] { -2, -1, 1, 4, 11 }, res);
        }
    }
}
