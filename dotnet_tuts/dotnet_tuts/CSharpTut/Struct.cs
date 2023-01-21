using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTut
{
    // this is a value type
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Struct
    {
        public static (Coordinate, Coordinate, Coordinate) Coordinates()
        {
            // can be created with our without new operator
            Coordinate point = new Coordinate();
            Console.WriteLine(point.x); //output: 0  
            Console.WriteLine(point.y); //output: 0 

            // withou new operator
            Coordinate point2;
             
            point2.x = 10;
            point2.y = 20;
            Console.Write(point2.x); //output: 10  
            Console.Write(point2.y); //output: 20  

            Coordinate point3 = new Coordinate(10, 20);

            Console.WriteLine(point3.x); //output: 10  
            Console.WriteLine(point3.y); //output: 20  

            return (point, point2, point3);
        }
    }
}
