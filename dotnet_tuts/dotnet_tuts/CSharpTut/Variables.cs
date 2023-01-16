namespace CSharpTut
{
    public class Variables
    {
        public static (string, string, int, string, bool, char, int) Strings()
        {
            string myName = "Diego";

            string interpolation = $"my name is {myName}";

            return (
                myName,
                interpolation,
                interpolation.Length,
                myName.ToUpper(),
                interpolation.Contains("Diego"),
                myName[0],
                interpolation.IndexOf("Diego")
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
    }
}
