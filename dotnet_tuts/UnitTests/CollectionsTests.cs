using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class CollectionsTests
{
    private readonly ITestOutputHelper _output;

    public CollectionsTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void Lists()
    {
        var res = Collections.Lists();
        Assert.True(res.Item1.SequenceEqual(new List<int> { 5, 4, 777, 3, 2, 1 }));
        Assert.True(res.Item2.SequenceEqual(new List<int> { 1, 2, 3, 5, 8, 13 }));
        Assert.True(res.Item3);
        Assert.Equal(6, res.Item2.Count);
        _output.WriteLine(string.Join(", ", res.Item2));
        res.Item2.Clear();
        Assert.Empty(res.Item2);
    }
}