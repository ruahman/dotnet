namespace CSharpTut
{
    
    public class Arrays
    {
        public static (int[], int) ArrayOfIntegers()
        {
            int[] numbers = { 1, 2, 3, 5, 8, 13 };
            return (numbers, numbers[3]);
        }

        public static string[] ArrayOfString()
        {
            string[] strings = new string[6];
            strings[0] = "Diego";
            strings[1] = "Vila";

            return strings;
        }

        public static int[,] Arrays2D()
        {
          
            int[,] numbers =
            {
                {1,2},
                {2,3},
                {3,4},
                {4,5}
            };

            return numbers;
        }

        public static int[][] JaggedArrays()
        {
            int[][] jagged = {
                new int[]{1,2,3},
                new int[]{1,2},
                new int[]{1,2,3,4}
            };

            return jagged;
        }

    }
}
