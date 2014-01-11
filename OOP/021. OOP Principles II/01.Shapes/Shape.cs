using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
{
    abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        //abstract method to be implemented in the child classes
        public abstract double CalculateSurface();
    }
}
