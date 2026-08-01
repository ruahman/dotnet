using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class ConditionStatementsTests
{
    private readonly ITestOutputHelper _output;

    public ConditionStatementsTests(ITestOutputHelper output)
    {
        _output = output;

        // console now outputs to xUnit
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void IsMale()
    {
        var res = ConditionStatements.IsMale();
        Assert.True(res);
    }

    [Fact]
    public void Switch()
    {
        ConditionStatements.Switch("Monday");
    }


    [Fact]
    public void IsMax()
    {
        ConditionStatements.GetMax(2, 3);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(false, 77)]
    public void Ternery(bool condition, int res)
    {
        var result = ConditionStatements.TernaryOperator(condition);
        Assert.Equal(res, result);
    }
}