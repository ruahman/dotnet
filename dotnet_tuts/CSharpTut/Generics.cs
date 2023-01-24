using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut.Generics
{
    public struct Rectangle<T>
    {
        private T width;
        private T height;

        public T Width
        {
            get { return width; }
            set { width = value; }
        }

        public T Height
        {
            get { return height; }
            set { height = value; }
        }

        public Rectangle(T width, T height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            double dblWidth = Convert.ToDouble(Width);
            double dblHeight = Convert.ToDouble(Height);

            return dblWidth * dblHeight;
        }
    }
    
    public class Generics
    {
        public static double GetSum<T>(T x, T y)
        {
            double dblX = Convert.ToDouble(x);
            double dblY = Convert.ToDouble(y);
            return dblX + dblY;
        }

    }
}
