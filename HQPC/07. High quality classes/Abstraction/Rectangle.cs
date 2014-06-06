namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get 
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height of the rectangle must be positive.");                    
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width of the rectangle must be positive.");
                }

                this.width = value; 
            }
        }

        public override double CalcPerimeter()
        {
            checked
            {
                double perimeter = (2 * this.Width) + (2 * this.Height);
                return perimeter;
            }
        }

        public override double CalcSurface()
        {
            checked
            {
                double surface = this.Width * this.Height;
                return surface;
            }
        }
    }
}
