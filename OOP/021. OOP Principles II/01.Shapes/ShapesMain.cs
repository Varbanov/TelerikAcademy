using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class ShapesMain
    {
        /* 01. Define abstract class Shape with only one abstract method CalculateSurface() and
         * fields width and height. Define two new classes Triangle and Rectangle that 
         * implement the virtual method and return the surface of the figure (height*width
         * for rectangle and height*width/2 for triangle). Define class Circle and suitable
         * constructor so that at initialization height must be kept equal to width and 
         * implement the CalculateSurface() method. Write a program that tests the behavior
         * of  the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle)
         * stored in an array.
        */

        static void Main()
        {
            //initialize an array of shapes and calculate their surface
            Shape[] shapes = new Shape[5] { new Circle(4), new Rectangle(3, 4), new Triangle(3, 4), new Circle(5), new Rectangle(4, 5) };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Type: {0,10} Surface: {1:0.00}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
