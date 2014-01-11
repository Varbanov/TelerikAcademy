using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Rectangle : Shape
    {
        //constructor
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        //base virtual method overriden
        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
