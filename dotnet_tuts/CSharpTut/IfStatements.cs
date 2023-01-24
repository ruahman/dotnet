using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class IfStatements
    {
        public static bool IsMale()
        {
            bool isMale = true;
            bool isTall = true;
            if(isMale && isTall)
            {
                return true;
            }
            else if (isMale && !isTall)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetMax(int a, int b)
        {
            if(a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static int TernaryOperator(bool condition)
        {
            var res = condition ? 11 : 77;
            return res;
        }
    }
}
