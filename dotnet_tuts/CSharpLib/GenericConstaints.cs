using System.Collections;

namespace CSharpLib;
// give constains to what you can put in generic

// restricts Generic to only a class
public class DataStore<T> where T : class
{
    public T? Data { get; set; }
}

// restricts Generic to only a struct
public class DataStore2<T> where T : struct
{
    public T Data { get; set; }
}

// restricts Generic to only a Enumerable
public class DataStore3<T> where T : IEnumerable
{
    public T? Data { get; set; }
}

public class TestClass
{
    public string data = "test";
}

public class GenericConstaints
{
    public static void TestGenericConstains()
    {
        var strStore = new DataStore<string>();
        strStore.Data = "Hello World";
    }
}