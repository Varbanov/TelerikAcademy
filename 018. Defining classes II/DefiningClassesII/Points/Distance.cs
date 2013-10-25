using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Point3D
{
    static class Distance
    {
        //Write a static class with a static method to calculate the distance between two points in the 3D space.

        static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            double dist = Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2) + Math.Pow(firstPoint.Z - secondPoint.Z, 2));
            return dist;
        }
    }
}
