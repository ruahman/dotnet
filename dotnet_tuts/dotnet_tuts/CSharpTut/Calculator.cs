using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    public class Calculator
    {
        public virtual int Add(int x, int y)
        {
            return x + y;
        }

        public virtual int Sub(int x, int y) 
        { 
            return x - y; 
        }  
    }
}
