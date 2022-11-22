using System;
using Xunit;
using Xunit.Abstractions;
using TutorialCSharp;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOut;

        public UnitTest1(ITestOutputHelper testOut)
        {
            _testOut = testOut;
        }


        [Fact]
        public void TestVariables()
        {
            string name = "Diego Vila";
            _testOut.WriteLine($"Hello {name}");

            //// nullable types
            int? y = null;


            if (y.HasValue)
            {
                _testOut.WriteLine("has value");
            }
            else
            {
                _testOut.WriteLine("has no valeu");
            }

            /// floats
            float f = 5.5F;
            double d = 5.5;
            decimal fm = 5.5M;

            decimal fa = decimal.MaxValue;

            _testOut.WriteLine($"{f} {d} {fm} {fa}");


            //// array
            int[] a = { -5, 5, 9, 0 };

            _testOut.WriteLine($"{a}");


            string x = @"foo/bar/folder";

            _testOut.WriteLine(x);

            string path = "myPath";
            string xa = $@"this/is/a/{path}";
            _testOut.WriteLine(xa);


            const double PI = 3.14;
            _testOut.WriteLine(PI.ToString());

            int? xi = null;
            bool? yb = null;
            double? zd = null;

            if (xi.HasValue)
            {
                Console.WriteLine(xi);
                Console.WriteLine(yb);
                Console.WriteLine(zd);
            }

            try
            {
                int yt = xi.Value;
                yt = xi.GetValueOrDefault(3);
                yt = xi ?? 56;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("x is null");
            }


            string nombre = "Diego    ";
            Console.WriteLine(nombre.Trim());

            string testSplit = "diego/ramon/vila";

            foreach (var sx in testSplit.Split('/'))
            {
                Console.WriteLine(sx);
            }
        }

        [Fact]
        public void TestPerson()
        {
            var p = new Person();
            p.FirstName = "Diego";
            p.LastName = "Vila";

            _testOut.WriteLine(p.GetFullName());
            _testOut.WriteLine(p.FullName);


        }

        [Fact]
        public void TestList()
        {
            List<int> grades = new() { 1, 2, 3, 4, 5 };
            grades.Add(55);

            if (grades.Contains(3))
            {
                _testOut.WriteLine("found");
            }

            if (grades.Count < 5)
            {
                _testOut.WriteLine("count less than 5");
            }

            var list = new List<int>();
            list.Add(3);
            list.Add(5);
        }

        [Fact]
        public void TestStudent()
        {
            var s = new Student("Diego", "Vila");
        }

        [Fact]
        public void HashTable()
        {
            Hashtable config = new Hashtable();

            config["version"] = 1;
            config["dir"] = "c/path/to/dic";
            config["valid"] = DateTime.Today.AddMinutes(1);


            var dict = new Dictionary<int, string>();

            dict.Add(3, "test");
            //dict.Add(4, 5555);

        }

        [Fact]
        public void TestGenerics()
        {
            var test = new ListaElementos<int>();
            test.Agregar(3);
            //test.Agregar("asdf");
            test.Listar();
        }

        delegate int numeros(int n);

        int sumar(int x)
        {
            return x;
        }

        [Fact]
        public void TestDelegate()
        {
            numeros numero = new(sumar);

            numeros lambda = y => y * y;

            numeros test = (int x) =>
            {
                return x;
            };

            _testOut.WriteLine(numero(10).ToString());
            _testOut.WriteLine(test(77).ToString());

        }

        struct Libros
        {
            public string titulo;
            public string autor;
            public string categoria;
            public int libro_id;
        }

        [Fact]
        public void TestLINQ()
        {
            string[] nombres = { "diego", "andy", "sam" };

            var lista = from n in nombres select n;

            foreach (var x in lista)
            {
                _testOut.WriteLine(x);
            }

            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 25, 27, 29, 50 };

            double valorMedio = numeros.Where(num => num % 2 == 1).Average();
            _testOut.WriteLine(valorMedio.ToString());





        }

        [Fact]
        public void Lamda()
        {
            Func<int, int> expression = x => x + 1;

            Func<int, int, int> expresion2 = (x, y) => x + y;

            var x = expression(1);
            var res = expresion2(1, 2);

            _testOut.WriteLine(x.ToString());
            _testOut.WriteLine(res.ToString());

        }

        [Fact]
        public void LinqXML()
        {
            var docXML = @"<departments>
                <department>a</department>
                <department>b</department>
                <department>c</department>
                <department>d</department>
                <department>e</department>
                <department>f</department>
            </departments>";

            var document = XDocument.Parse(docXML);

            var res = document.Descendants().Where(x => x.Name == "department").Select(x => x.Value);

            foreach (var x in res)
            {
                _testOut.WriteLine(x);
            }
        }

        [Fact]
        public void AsyncTest()
        {
            Task task1 = new Task((x) => _testOut.WriteLine($"run my task: {x}"), "hello world");

            _testOut.WriteLine("before task");
            task1.Start();
            Task.WaitAll(task1);
            _testOut.WriteLine("after task");


            Task<int> task2 = new Task<int>(() =>
            {
                return 100 * 100;
            });

            task2.Start();

            _testOut.WriteLine(task2.Result.ToString());
        }


        [Fact]
        public void OutVariableTest()
        {
            DateTime dt;
            if (DateTime.TryParse("8/11/2021", out dt))
            {
                _testOut.WriteLine(dt.ToString());
            }

            //if (DateTime.TryParse("8/12/2021", out DateTime dt2))
            if (DateTime.TryParse("8/12/2021", out var dt2))

            {
                _testOut.WriteLine(dt2.ToString());
            }

            _ = int.TryParse("23", out var i);
            _testOut.WriteLine(i.ToString());
        }

        interface IShape
        {

        }

        class Rectangle : IShape
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        class Circle : IShape
        {
            public int Radius { get; set; }
        }

        static void DisplayShape(IShape shape)
        {
            //if (shape is Rectangle r)
            //{
            //    Console.WriteLine(r);
            //}

            switch (shape)
            {
                case Circle c:
                    Console.WriteLine(c);
                    break;
                case Rectangle r when (r.Height == r.Width):
                    Console.WriteLine("this is a square");
                    break;
            }
        }

        [Fact]
        public void PatternMatchingTest()
        {

        }

        (double sum, double product) NewSumAndProduct(double a, double b)
        {
            return (a + b, a * b);
        }


        [Fact]
        public void TestTuples()
        {
            var res = NewSumAndProduct(2.0, 3.0);
            _testOut.WriteLine($"{res.sum} {res.product}");

            var (sum, product) = NewSumAndProduct(4.5, 6.2);
            _testOut.WriteLine($"{sum}");
            _testOut.WriteLine($"{product}");

            (double ss, double pp) = NewSumAndProduct(4.5, 6.2);
            _testOut.WriteLine($"{ss} {pp}");

            var me = (name: "Diego", age: 123);
            _testOut.WriteLine($"{me.name} {me.age}");

            var snp = new Func<double, double, (double sum, double prod)>((a, b) => (a + b, a * b));
            var res2 = snp(1, 2);
            _testOut.WriteLine($"{res2.sum} {res2.prod}");
        }


        class Point
        {
            public int X, Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }

        [Fact]
        public void DeconstructionTest()
        {
            var p = new Point(4, 5);
            var (x, y) = p;
            _testOut.WriteLine($"{x} {y}");

            var (x1, _) = p;
            _testOut.WriteLine(x1.ToString());
        }

        [Fact]
        public void TestLocalFunc()
        {
            string testLocal(string x)
            {
                return x + "--test";
            }

            Assert.Equal("hello--test", testLocal("hello"));
        }



        [Fact]
        public void TestRef()
        {

            ref int Min(ref int x, ref int y)
            {
                if (x < y) return ref x;
                return ref y;
            }

            int a = 1, b = 2;

            // why is the usfull
            ref int minValue = ref Min(ref a, ref b);
        }



        [Fact]
        public void TestExpBody()
        {
            void ExpressionBody(string x) => Console.WriteLine(x);

            ExpressionBody("test");
        }

        [Fact]
        public void ThrowEx()
        {
            string name = null;
            var Name = name ?? throw new ArgumentNullException();
        }

        [Fact]
        public void TestDefault()
        {
            int a = default;
            _testOut.WriteLine($"{a}");
        }

        public class Animal { }
        public class Pig : Animal { }

        [Fact]
        public void TestPatternMatchGen()
        {
            void Cook<T>(T animal)
                where T : Animal
            {
                if (animal is Pig pig)
                {

                }

                switch (animal)
                {
                    case Pig pork:
                        break;
                }
            }

            var a = new Pig();

            Cook<Pig>(a);


        }

        [Fact]
        public void TestRange()
        {

            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var r = x[..5];

            _testOut.WriteLine(x.ToString());
            _testOut.WriteLine(r.ToString());


        }

        struct PhoneNumber
        {
            public int Code, Number;
        }

        [Fact]
        public void TestMorePatternMatching()
        {
            var phoneNumber = new PhoneNumber();
            var orging = phoneNumber switch
            {
                { Number: 122 } => "Emergency",
                { Code: 44 } => "UK",
                { Code: var code } when code < 0 => $"code: {code}",
                _ => "nothing"
            };

            if (phoneNumber is { Number: 911 })
            {
                _testOut.WriteLine("911");
            }

            _testOut.WriteLine(orging);
        }

        public record PersonR
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public record Address
        {
            public int HouseNumber { get; }
            public string Street { get; }
        }

        public record Car
        {
            public string Color { get; set; }
            public string Engine { get; set; }
        }

        [Fact]
        public void testRecords()
        {
            var p = new PersonR { Name = "John", Age = 22 };

            Car myFirstCar = new() { Color = "Black", Engine = "v6" };
            Car upgradeCar = myFirstCar with { Engine = "v8" };
        }

        public class PersonInit
        {
            // this is read only
            public int SSN { get; init; }

            private readonly string _lastName;

            public string LastName
            {
                get => _lastName;
                init => _lastName = value;
            }

            //public PersonInit() { }
            //public PersonInit(int ssn)
            //{
            //    SSN = ssn;
            //}
        }

        [Fact]
        public void TestInitSetters()
        {
            var p = new PersonInit { SSN = 248_76_6579, LastName = "Vila" };

            _testOut.WriteLine(p.SSN.ToString());
            _testOut.WriteLine(p.LastName);
        }

        [Fact]
        public void TestAdvancePaternMatchin()
        {
            object a = 1;

            if (a is not null)
            {
                _testOut.WriteLine("Im not null");
            }
            int temp = 666;
            var feel = temp switch
            {
                < 0 => "freezing",
                >= 0 and < 20 => "tolerable",
                >= 20 => "warm"
            };

            _testOut.WriteLine(feel);
        }
    }
}
