namespace CSharpTut
{
    public class Variables
    {
        public static (string, string, int, string, bool, char, int, string) Strings()
        {
            string myName = "Diego";

            string interpolation = $"my name is {myName}";

            string literal = @"G:\My Drive\Documents\denote";

            return (
                myName,
                interpolation,
                interpolation.Length,
                myName.ToUpper(),
                interpolation.Contains("Diego"),
                myName[0],
                interpolation.IndexOf("Diego"),
                literal
            );
        }

        public static char Chars()
        {
            char mychar = 'A';

            return mychar;
        }

        public static (int, int) Integers()
        {
            int myAge = 42;
            int abs = Math.Abs(-7);


            return (myAge, abs);
        }

        public static (float, double, decimal, double) Floats()
        {
            float f = 3.12f; // least accurate
            double d = 3.33333; // default
            decimal dec = 4.566666666m;  // most acurate
            var pow = Math.Pow(3, 3);

            return (f, d, dec, pow);
        }

        public static bool Booleans()
        {
            bool x = true;
            return x;
        }

        public static int? Nullable()
        {
            int? x = null;

            return x;
        }

        public static int Casting()
        {
            double myDouble = 9.78;
            int myInt = (int)myDouble;    // Manual casting: double to int

            Console.WriteLine(myDouble);   // Outputs 9.78
            Console.WriteLine(myInt);      // Outputs 9

            return myInt;

        }

        public static (string, double, int, string) Conversion()
        {
            int myInt = 10;
            double myDouble = 5.25;
            bool myBool = true;

            var res1 = Convert.ToString(myInt);    // convert int to string
            var res2 = Convert.ToDouble(myInt);    // convert int to double
            var res3 = Convert.ToInt32(myDouble);  // convert double to int
            var res4 = Convert.ToString(myBool);   // convert bool to string

            return (res1, res2, res3, res4);

        }

        public static (bool, int) TryParse()
        {
            string number = "128";

            bool success = int.TryParse(number, out int parseValue);
            return (success, parseValue);
        }

        // you can use out to return more than on variable from a function
        public static (DateTime, DateTime) OutVariables()
        {
            DateTime dt;
            DateTime.TryParse("2/22/2023", out dt);
            DateTime.TryParse("2/22/2024", out DateTime dt2);

            return (dt, dt2);
        }
    }
}
