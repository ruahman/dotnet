using System;

namespace CSharpTut.PatternMatching
{
    public class Shape
    {

    }
    public class Rectangle : Shape
    {
        int height;
        int width;
    }
    public class Circle : Shape
    {
        public double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
    }
    public class PatternMatching
    {
        public static String Demo()
        {
            String res;
            Shape test = new Circle(5.0);

            switch (test)
            {
                case Rectangle r:
                    res = $"this is a rectange: {r}";
                    break;
                case Circle c when c.radius < 10.0:
                    res = $"this is a small circle: {c}";
                    break;
                case Circle c:
                    res = $"this is a small circle: {c}";
                    break;
                default:
                    res = "nothing";
                    break;
            }
            return res;
        }

    }

}
