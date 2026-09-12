using System.Text;
using CSharpLib;

namespace UnitTests;

public class StringBuilderTests
{
    [Fact]
    public void TestStringBuilder_ShouldExecuteWithoutExceptions()
    {
        var exception = Record.Exception(() => StringBuilderTut.TestStringBuilder());

        Assert.Null(exception);
    }

    [Fact]
    public void StringBuilder_AppendAndAppendLine_ShouldProduceExpectedContent()
    {
        var sb = new StringBuilder();
        sb.Append("Hello ");
        sb.AppendLine("World!");
        sb.AppendLine("Hello C#");

        var result = sb.ToString();

        Assert.StartsWith("Hello World!", result);
        Assert.Contains("Hello C#", result);
    }
}
