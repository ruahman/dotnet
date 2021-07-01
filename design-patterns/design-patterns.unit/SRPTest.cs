using System;
using Xunit;
using Xunit.Abstractions;
using design_patterns;


namespace design_patterns.unit
{
    public class SRPTest
    {
        private readonly ITestOutputHelper _output;

        public SRPTest(ITestOutputHelper output){
          _output = output;
        }

        [Fact]
        public void Test1()
        {
          _output.WriteLine("test ITestOutputHelper");

          // Assert.Equal(true, false);
        }
    }
}
