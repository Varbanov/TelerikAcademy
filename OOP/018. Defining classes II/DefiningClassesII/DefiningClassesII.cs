using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClassesII.Point3D;

namespace DefiningClassesII
{
    class DefiningClassesII
    {
        static void Main()
        {
            ////uncomment to easily test point functionalities
            //int[] xArr = new int[] { 1, 2, 3, 4, 5 };
            //int[] yArr = new int[] { 6, 7, 8, 9, 10 };
            //int[] zArr = new int[] { 11, 12, 13, 14, 15 };

            //Path path = new Path();

            //for (int i = 0; i < 5; i++)
            //{
            //    Point p = new Point();
            //    p.X = xArr[i];
            //    p.Y = yArr[i];
            //    p.Z = zArr[i];
            //    path.AddPoint(p);
            //}

            //Console.WriteLine("The path contains the following points:");
            //foreach (var point in path.Points)
            //{
            //    Console.WriteLine(point.ToString());
            //}

            ////save to file
            //Console.WriteLine("The path is saved to the file!");
            //PathStorage.SavePath(path);

            //path.ClearAllPoints();
            //Console.WriteLine("Path points are now cleared, the path containts {0} points", path.Points.Count);
            //Console.WriteLine("The paths are now loaded from the file:");

            //List<Path> loaded = PathStorage.LoadPaths();

            //foreach (var loadedPath in loaded)
            //{
            //    foreach (var point in loadedPath.Points)
            //    {
            //        Console.Write("{{{0}}} ", point);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
