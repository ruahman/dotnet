using CSharpTut.ExtentionMethods;
using Xunit.Abstractions;

namespace UnitTests
{
    public class ExtentionMethodTests
    {
        ITestOutputHelper _output;
        public ExtentionMethodTests(ITestOutputHelper output)
        {
            _output = output;
            // console now outputs to xUnit
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        [Trait("CSharp","ExtensionMethods")]
        public void Test()
        {
            Console.WriteLine("test");
            ExtentionMethods.Test();
        }
    }
}
