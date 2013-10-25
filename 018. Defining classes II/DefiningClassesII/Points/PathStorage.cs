using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DefiningClassesII.Point3D
{
    static class PathStorage
    {
        //Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

        private static string filePath = @"..\..\pathStorage.txt";

        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter(filePath, true);
            using (writer)
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(point.ToString());
                }
                writer.WriteLine("end");
            }
        }

        public static List<Path> LoadPaths()
        {
            List<Path> loaded = new List<Path>();
            Path tempPath = new Path();
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line == "end")
                    {
                        //if the end of the current path is reached
                        loaded.Add(tempPath);
                        tempPath = new Path(); //tempPath.ClearAllPoints();
                    }
                    else
                    {
                        //still in the current path, so add the point to it
                        string[] dimensions = line.Split(' ');
                        Point p = new Point()
                        {
                            X = int.Parse(dimensions[0]),
                            Y = int.Parse(dimensions[1]),
                            Z = int.Parse(dimensions[2]),
                        };

                        tempPath.AddPoint(p);
                    }

                    line = reader.ReadLine();
                }
            }
            return loaded;
        }
    }
}
