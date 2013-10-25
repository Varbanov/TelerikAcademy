using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Point3D
{
    struct Point
    {
        //Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.
        //Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

        private static readonly Point startPoint = new Point() { X = 0, Y = 0, Z = 0 };
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point StartPoint
        {
            get { return startPoint; }
        }
        
        public override string ToString()
        {
            string res = String.Format("{0} {1} {2}", this.X, this.Y, this.Z);
            return res;
        }
    }
}
