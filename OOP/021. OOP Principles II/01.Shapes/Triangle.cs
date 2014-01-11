using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Triangle : Shape
    {
        //constructor
        public Triangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        //base virtual method overriden
        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
    }
}
