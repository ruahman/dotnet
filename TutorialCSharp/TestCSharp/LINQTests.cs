using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace TestCSharp
{
    public class LINQTests
    {
        [Fact]
        public void Find()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res = list.Find(x => x == 7);

            Assert.Equal(7, res);

            res = list.Find(x => x == 77);
            Assert.Equal(0, res);

            List<string> list2 = new() { "cat", "dog", "bird" };

            var res2 = list2.Find(x => x == "man");

            Assert.Null(res2);

            res2 = list2.Find(x => x == "cat");

            Assert.Equal("cat", res2);


            List<int?> list3 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res3 = list3.Find(x => x == 77);

            Assert.Null(res3);

            res3 = list3.Find(x => x == 7);

            Assert.Equal(7, res3);
        }

        [Fact]
        public void Where()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res = list.Where(x => x < 5);

            Assert.Equal(4, res.Count());
        }

        [Fact]
        public void OrderBy()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var res = list.OrderByDescending(x => x);

            Assert.Equal(new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, res);
        }

        [Fact]
        public void Select()
        {
            List<int> list = new() { 1, 2, 3 };

            var res = list.Select(x => x * x);

            Assert.Equal(new List<int>() { 1, 4, 9 }, res);
        }

        [Fact]
        public void Aggregate()
        {
            List<int> list = new() { 1, 2, 3, 4 };

            var res = list.Aggregate((agg, elem) => agg + elem);

            Assert.Equal(10, res);
        }
    }
}
