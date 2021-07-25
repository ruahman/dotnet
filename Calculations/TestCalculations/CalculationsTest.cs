using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculations;

namespace TestCalculations
{
    public class CalculationsTest
    {
        [Fact]
        [Trait("Category", "Fibo")]
        public void FibDoesNotIncZero()
        {
            var fib = new Fib();
            Assert.All(fib.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo13")]
        public void FibInc13()
        {
            var calc = new Fib();
            Assert.Contains(13, calc.FiboNumbers);
            Assert.DoesNotContain(4, calc.FiboNumbers);
        }
    }
}
