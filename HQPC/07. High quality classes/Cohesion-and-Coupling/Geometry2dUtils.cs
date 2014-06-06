namespace CohesionAndCoupling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Geometry2dUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            checked
            {
                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                return distance;
            }
        }

        public static double CalcRectangleDiagonal(double width, double height)
        {
            checked
            {
                double distance = Math.Sqrt((width * width) + (height * height));
                return distance;
            }
        }
    }
}
