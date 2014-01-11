using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    class Circle : Shape
    {

        //constructor
        public Circle(double radius)
        {
            this.Width = radius;
            this.Height = radius; //this line can be skipped
        }

        //base virtual method overriden
        public override double CalculateSurface()
        {
            return Math.PI * Width * Width;
        }
    }
}
