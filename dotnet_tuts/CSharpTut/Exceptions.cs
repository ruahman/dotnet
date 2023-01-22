using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Exceptions
    {
        public static bool DivideByZeroException(int a, int b)
        {
            bool res = false;
            bool result = false;
            try
            {
                int num = a / b;
                res = true;
            }
            catch(DivideByZeroException e)
            {
                res = false;
            }
            finally { 
                result = res; 
            }

            return result;
        }
    }
}
