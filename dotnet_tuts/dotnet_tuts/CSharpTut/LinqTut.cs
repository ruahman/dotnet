using CSharpTut.Classes;

namespace CSharpTut.LinqTut
{
    public static class LinqTut
    {
        public static (IEnumerable<Car>, IEnumerable<Car>) SelectCars()
        {
            List<Car> cars = new()
            {
                new Car() { Make="Ford", Modle="Toraus", Year="2001" },
                new Car() { Make="Ford", Modle="Focus", Year="2005" },
                new Car() { Make="Ford", Modle="Echo", Year="2010" },
                new Car() { Make="Ford", Modle="Mustain", Year="2015" },
                new Car() { Make="Toyota", Modle="Yaris", Year="2000" },
                new Car() { Make="Toyota", Modle="Carola", Year="2005" },
                new Car() { Make="Toyota", Modle="LandCruser", Year="2018" },
                new Car() { Make="Honda", Modle="Civic", Year="2019" },
            };

            // query syntax
            var fords = from car in cars where car.Make == "Ford" select car;

            // method syntas
            var toyotas = cars.Where(x => x.Make == "Toyota");

            return (fords, toyotas);
        }
    }
}
