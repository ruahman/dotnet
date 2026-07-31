using Xunit.Abstractions;

namespace UnitTests;

using CSharpTut;

public class HelloWorldTests(ITestOutputHelper testOutputHelper)
{ 
    [Fact] 
    public  void HelloWorldTest()
    {
         testOutputHelper.WriteLine("Hello World!"); 
         Assert.Equal("Hello World", HelloWorld.Hello());
         Assert.Equal("Goodbye", HelloWorld.Goodbye());
    } 
}
