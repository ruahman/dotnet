using CSharpTut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTests
{
    public class VariableTests
    {
        ITestOutputHelper output;

        public VariableTests(ITestOutputHelper output) => this.output = output;
        
        [Fact]
        [Trait("Category","Variables")]
        public void Strings()
        {
            (String first, String second, int length, string upper, bool contains, char myChar, int idx) = Variables.Strings();
            Assert.Equal("Diego", first);
            Assert.Equal("my name is Diego", second);
            Assert.Equal(16, length);
            Assert.Equal("DIEGO", upper);
            Assert.True(contains);
            Assert.Equal('D', myChar);
            Assert.Equal(11, idx);
            output.WriteLine(second);

        }

        [Fact]
        [Trait("Category", "Variables")]
        public void Chars()
        {
            var res = Variables.Chars();
            Assert.Equal('A', res);
        }

        [Fact]
        [Trait("Category", "Variables")]
        public void Integers()
        {
            (int age, int abs) = Variables.Integers();
            Assert.Equal(42, age);
            Assert.Equal(7, abs);
        }


    }
}
