using CSharpTut;
using Xunit.Abstractions;

namespace UnitTests
{
    public class VariableTests
    {

        private readonly ITestOutputHelper output;

        public VariableTests(ITestOutputHelper output)
        {
            this.output = output;

            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Strings()
        {
            (String first, String second, int length, string upper, bool contains, char myChar, int idx, string literal) = Variables.Strings();
            Assert.Equal("Diego", first);
            Assert.Equal("my name is Diego", second);
            Assert.Equal(16, length);
            Assert.Equal("DIEGO", upper);
            Assert.True(contains);
            Assert.Equal('D', myChar);
            Assert.Equal(11, idx);
            Assert.Equal(@"G:\My Drive\Documents\denote", literal);
            output.WriteLine(second);

        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Chars()
        {
            var res = Variables.Chars();
            Assert.Equal('A', res);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Integers()
        {
            (int age, int abs) = Variables.Integers();
            Assert.Equal(42, age);
            Assert.Equal(7, abs);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Floats()
        {
            (float f, double d, decimal dec, double pow) = Variables.Floats();
            Assert.Equal(3.12f, f);
            Assert.Equal(3.33333, d);
            Assert.Equal(4.566666666m, dec);
            Assert.Equal(27, pow);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Booleans()
        {
            bool x = Variables.Booleans();
            Assert.True(x);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Nullable()
        {
            int? x = Variables.Nullable();
            Assert.Null(x);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Casts()
        {
            int x = Variables.Casting();
            Assert.Equal(9, x);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void Conversion()
        {
            var res = Variables.Conversion();
            Assert.Equal("10", res.Item1);
            Assert.Equal(10.0, res.Item2);
            Assert.Equal(5, res.Item3);
            Assert.Equal("True", res.Item4);
        }


        [Fact]
        [Trait("CSharp", "Variables")]
        public void TryParse()
        {
            var res = Variables.TryParse();
            Assert.True(res.Item1);
            Assert.Equal(128, res.Item2);
        }

        [Fact]
        [Trait("CSharp", "Variables")]
        public void OutVariables()
        {
            var res = Variables.OutVariables();

            var test1 = new DateTime(2023, 2, 22);
            Assert.Equal(test1, res.Item1);

            var test2 = new DateTime(2024, 2, 22);
            Assert.Equal(test2, res.Item2);
        }


    }
}
