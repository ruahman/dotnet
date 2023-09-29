namespace csharp_tut_tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
      Car myCar = new Car();
      Car.Exec();
      Assert.Equal("red", myCar.color);
    }
}
