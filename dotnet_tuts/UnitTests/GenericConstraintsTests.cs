using System.Collections;
using CSharpLib;

namespace UnitTests;

public class GenericConstraintsTests
{
    [Fact]
    public void TestDataStore_WithReferenceTypes()
    {
        var stringStore = new DataStore<string>();
        Assert.Null(stringStore.Data);

        stringStore.Data = "Sample text";
        Assert.Equal("Sample text", stringStore.Data);

        var classStore = new DataStore<TestClass>();
        Assert.Null(classStore.Data);

        var testObj = new TestClass { data = "custom" };
        classStore.Data = testObj;
        Assert.NotNull(classStore.Data);
        Assert.Equal("custom", classStore.Data.data);
    }

    [Theory]
    [InlineData(42)]
    [InlineData(-100)]
    public void TestDataStore2_WithInt(int value)
    {
        var intStore = new DataStore2<int> { Data = value };
        Assert.Equal(value, intStore.Data);
    }

    [Theory]
    [InlineData(3.14159)]
    [InlineData(-0.001)]
    public void TestDataStore2_WithDouble(double value)
    {
        var doubleStore = new DataStore2<double> { Data = value };
        Assert.Equal(value, doubleStore.Data);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void TestDataStore2_WithBool(bool value)
    {
        var boolStore = new DataStore2<bool> { Data = value };
        Assert.Equal(value, boolStore.Data);
    }

    [Fact]
    public void TestDataStore3_WithList()
    {
        var listStore = new DataStore3<List<string>>();
        Assert.Null(listStore.Data);

        var list = new List<string> { "one", "two", "three" };
        listStore.Data = list;
        Assert.NotNull(listStore.Data);
        Assert.Equal(3, listStore.Data.Count);
        Assert.Equal(new[] { "one", "two", "three" }, listStore.Data);
    }

    [Fact]
    public void TestDataStore3_WithArray()
    {
        var arrayStore = new DataStore3<int[]>();
        Assert.Null(arrayStore.Data);

        int[] numbers = [1, 2, 3, 4, 5];
        arrayStore.Data = numbers;
        Assert.NotNull(arrayStore.Data);
        Assert.Equal(5, arrayStore.Data.Length);
        Assert.Equal(numbers, arrayStore.Data);
    }

    [Fact]
    public void TestDataStore3_WithArrayList()
    {
        var arrayListStore = new DataStore3<ArrayList>();
        Assert.Null(arrayListStore.Data);

        var arrayList = new ArrayList { "a", 1, true };
        arrayListStore.Data = arrayList;
        Assert.NotNull(arrayListStore.Data);
        Assert.Equal(3, arrayListStore.Data.Count);
    }

    [Fact]
    public void TestGenericConstaints_RunnerExecutesSuccessfully()
    {
        var exception = Record.Exception(() => GenericConstaints.TestGenericConstains());
        Assert.Null(exception);
    }
}
