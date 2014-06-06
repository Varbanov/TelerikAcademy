namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius) 
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The radius must be a positive number!");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            checked
            {
                double perimeter = 2 * Math.PI * this.Radius;
                return perimeter;
            }
        }

        public override double CalcSurface()
        {
            checked
            {
                double surface = Math.PI * this.radius * this.radius;
                return surface;
            }
        }
    }
}
