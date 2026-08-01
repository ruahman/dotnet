using Xunit.Abstractions;

namespace UnitTests;

using CSharpTut;

public class HelloWorldTests(ITestOutputHelper output)
{ 
    [Fact] 
    public  void HelloWorldTest()
    {
         output.WriteLine("Hello World!"); 
         Assert.Equal("Hello World", HelloWorld.Hello());
         Assert.Equal("Goodbye", HelloWorld.Goodbye());
    } 
}
