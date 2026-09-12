using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class NullableTests
{
    private readonly ITestOutputHelper _output;

    public NullableTests(ITestOutputHelper output)
    {
        _output = output;
        var converter = new Converter(output);
        Console.SetOut(converter);
    }

    [Fact]
    public void TestNullable_ExecutesWithoutException()
    {
        CSharpLib.Nullable.TestNullable();
    }

    [Fact]
    public void Nullable_HasValueAndDefaultValue_BehaveAsExpected()
    {
        int? nullInt = null;
        Assert.False(nullInt.HasValue);
        Assert.Equal(0, nullInt.GetValueOrDefault());
        Assert.Equal(42, nullInt.GetValueOrDefault(42));

        int? valuedInt = 10;
        Assert.True(valuedInt.HasValue);
        Assert.Equal(10, valuedInt.Value);
        Assert.Equal(10, valuedInt.GetValueOrDefault());
    }

    [Fact]
    public void Nullable_NullCoalescingOperator_AssignsFallback()
    {
        int? x = null;
        int j = x ?? 0;
        Assert.Equal(0, j);

        int? y = 25;
        int k = y ?? 0;
        Assert.Equal(25, k);

        double? dNull = null;
        double dFallback = dNull ?? 3.14;
        Assert.Equal(3.14, dFallback);

        double? dVal = 2.718;
        double dResult = dVal ?? 3.14;
        Assert.Equal(2.718, dResult);
    }
}
