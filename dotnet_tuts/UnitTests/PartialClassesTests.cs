using CSharpLib;
using Xunit.Abstractions;

namespace UnitTests;

public class PartialClassesTests
{
    private readonly ITestOutputHelper _output;

    public PartialClassesTests(ITestOutputHelper output)
    {
        _output = output;
        Console.SetOut(new Converter(_output));
    }

    [Fact]
    public void Employee_ConstructorAndProperties_ShouldInitializeCorrectly()
    {
        var employee = new PartialClasses.Employee(101, "Alice");

        Assert.Equal(101, employee.EmpId);
        Assert.Equal("Alice", employee.Name);

        employee.EmpId = 102;
        employee.Name = "Bob";

        Assert.Equal(102, employee.EmpId);
        Assert.Equal("Bob", employee.Name);
    }

    [Fact]
    public void Employee_DisplayEmpInfo_ShouldExecuteSuccessfully()
    {
        var employee = new PartialClasses.Employee(1, "John Doe");

        var exception = Record.Exception(() => employee.DisplayEmpInfo());

        Assert.Null(exception);
    }

    [Fact]
    public void Employee2_Constructor_ShouldInvokePartialMethodToGenerateEmpId()
    {
        var employee2 = new PartialClasses.Employee2
        {
            Name = "Charlie"
        };

        Assert.Equal(312, employee2.EmpId);
        Assert.Equal("Charlie", employee2.Name);
    }

    [Fact]
    public void TestPartialClasses_ShouldExecuteWithoutExceptions()
    {
        var exception = Record.Exception(() => PartialClasses.TestPartialClasses());

        Assert.Null(exception);
    }
}
