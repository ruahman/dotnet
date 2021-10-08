using System;
using Xunit;
using Xunit.Abstractions;
using design_patterns;
using System.Collections.Generic;

namespace design_patterns.unit
{
    public class Journal
    {
        private readonly List<string> entries = new();

        private static int count = 0;

        public int AddEntry(string text)
        {

        }
    }

    public class SRPTest
    {
        private readonly ITestOutputHelper _output;

        public SRPTest(ITestOutputHelper output)
        {
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
