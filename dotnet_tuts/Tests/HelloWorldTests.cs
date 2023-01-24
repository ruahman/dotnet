using Xunit.Abstractions;

namespace XUnitTests
{
    public class HelloWorldTests
    {
        
        private readonly ITestOutputHelper output;

        public HelloWorldTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void HelloWorld()
        {

            var res = CSharpTut.HelloWorld.Hello();
            Assert.Equal("Hello World", res);
            output.WriteLine("Hello From xUnit");
        }
    }
}