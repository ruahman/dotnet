using Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCalculations
{
    public class NameTest
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var res = names.MakeFullName("Diego", "Vila");
            Assert.Equal("Diego Vila", res);
            Assert.Contains("Diego", res);
            Assert.Matches("[a-z]+", res);

        }
    }
}
