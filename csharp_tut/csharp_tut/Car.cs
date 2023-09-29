namespace csharp_tut;


public class Car {
  public string color = "red";

  public static void Exec() {
    Car myObj = new Car();
    Console.WriteLine($"from my statice method {myObj.color}");
  }
}
