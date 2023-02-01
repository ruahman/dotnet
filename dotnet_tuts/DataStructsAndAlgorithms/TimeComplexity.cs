namespace DataStructsAndAlgorithms.TimeComplexity
{
    public class TimeComplexity
    {
        // this is O(n)
        public static int Fun1(int n)
        {
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                m += 1;
            }
            return m;
        }

        // this is O(n^2)
        public static int Fun2(int n)
        {
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m += 1;
                }
            }

            return m;
        }

        // this is O(n^3)
        public static int Fun3(int n)
        {
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        m += 1;
                    }
                }
            }

            return m;
        }

        // this O(log(n)) 
        public static int Fun4(int n)
        {
            int i = 1, m = 0;
            while (i < n)
            {
                m += 1;
                i = i * 2;
            }
            // 2*m = n,
            // m = log(n)

            return m;
        }
    }
}
