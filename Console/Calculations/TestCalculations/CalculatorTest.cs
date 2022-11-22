using Calculations;
using System;
using Xunit;

namespace TestCalculations
{
    public class CalculatorTest
    {
        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Add_TwoInts_ReturnInt()
        {
            var calc = new Calculator();
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoublesValues_RetrunsDouble()
        {
            var calc = new Calculator();
            var result = calc.AddDouble(1.2, 3.2);
            Assert.Equal(4.4, result);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            Assert.Null(names.NickName);

            names.NickName = "Strong man";

            Assert.NotNull(names.NickName);
        }
    }
}
