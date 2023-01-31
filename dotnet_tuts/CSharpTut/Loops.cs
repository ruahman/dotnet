namespace CSharpTut
{
    public class Loops
    {
        public static int WhileLoop()
        {
            int index = 1;
            while (index <= 5)
            {
                index++;
            }
            return index;
        }

        public static int ForLoop()
        {
            int res = 0;
            for (int i = 1; i <= 5; i++)
            {
                res = i;
            }
            return res;
        }

        public static int ForEachLoop()
        {
            int res = 0;
            List<int> items = new List<int>() { 1, 2, 3, 5, 8, 13 };
            foreach (int i in items)
            {
                res += i;
            }
            return res;
        }
    }
}
