using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Point3D
{
    class Path
    {
        //Create a class Path to hold a sequence of points in the 3D space. 

        private List<Point> points = new List<Point>();

        public List<Point> Points
        {
            get { return points; }
            //set { points = value; }
        }

        //a metthod to add points to a path one by one 
        public void AddPoint(Point point)
        {
            this.points.Add(point);
        }
        
        //a method to dispose all points contained in a path (needed for restarting tempPath in PathStorage class)
        public void ClearAllPoints()
        {
            this.Points.Clear();
        }


    }
}
