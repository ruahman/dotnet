using System;
using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;
using Xunit;
using Xunit.Abstractions;

namespace TestCSharp
{
    public class CollectionsTests
    {

        private readonly ITestOutputHelper _output;

        public CollectionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Lists()
        {
            List<int> list = new() { 1, 2, 3, 4, 55 };

            Assert.Equal(1, list.First());
            Assert.Equal(55, list.Last());

            Assert.Equal(5, list.Count);

            list.RemoveAt(0);
            Assert.Equal(4, list.Count);

            list.RemoveAt(list.Count - 1);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Dictionarys()
        {
            Dictionary<int, bool> dict = new()
            {
                { 1, false },
                { 2, false },
                { 3, false },
                { 44, false },
                { 55, false }
            };


            Assert.False(dict[44]);

            dict[44] = true;

            Assert.True(dict[44]);

            foreach (KeyValuePair<int, bool> x in dict)
            {
                _output.WriteLine($"{x.Key} : {x.Value}");
            }

            foreach (var x in dict)
            {
                _output.WriteLine($"{x.Key} : {x.Value}");
            }

            foreach (var x in dict.Keys)
            {
                _output.WriteLine($"{x}");
            }

            foreach (var x in dict.Values)
            {
                _output.WriteLine($"{x}");
            }



            foreach (var x in dict.OrderByDescending(x => x.Key))
            {
                _output.WriteLine($"{x.Key}");
            }

            foreach (var x in dict.Where(x => x.Value))
            {
                _output.WriteLine($"{x.Key}");
            }
        }

        [Fact]
        void RangeTest()
        {


            foreach (var x in Range(1, 10))
            {
                _output.WriteLine($"{x}");
            }

            foreach (var x in Range(1, 10).Reverse())
            {
                _output.WriteLine($"{x}");
            }

            foreach (var x in Range(1, 10).Select(x => x * x))
            {
                _output.WriteLine($"{x}");
            }
        }

        public int Fib(int x, Dictionary<int, int> memo)
        {
            if (x == 0)
            {
                memo[x] = 0;
                return 0;
            }
            if (x <= 1)
            {
                memo[x] = 1;
                return 1;
            }
            else
            {
                var res = Fib(x - 1, memo) + Fib(x - 2, memo);
                memo[x] = res;
                return res;
            }


        }

        [Fact]
        void fibTest()
        {
            var memo = new Dictionary<int, int>();
            //int res = Fib(0, memo);
            //Assert.Equal(1, res);

            //res = Fib(1, memo);
            //Assert.Equal(1, res);

            //res = Fib(2, memo);
            //Assert.Equal(2, res);

            //res = Fib(3, memo);
            //Assert.Equal(3, res);

            //res = Fib(4, memo);
            //Assert.Equal(5, res);

            //res = Fib(5, memo);
            //Assert.Equal(8, res);

            var res = Fib(10, memo);
            //Assert.Equal(13, res);
            //Assert.Equal(13, res);

            var list = memo.OrderBy(item => item.Key).Select(item => item.Value).ToList();
            list.Insert(0, 0);

            foreach (var item in list)
            {
                _output.WriteLine($"{item}");
            }


        }
    }
}
