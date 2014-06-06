namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            // Console.WriteLine(FilenameUtils.GetFileExtension("example"));
            Console.WriteLine(FilenameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileExtension("example.new.pdf"));

            // Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Geometry2dUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Geometry3dUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;
            Console.WriteLine("Volume = {0:f2}", Geometry3dUtils.CalcCuboidVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3dUtils.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry3dUtils.CalcDiagonalXYZ(width, height, 0));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry3dUtils.CalcDiagonalXYZ(width, 0, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry3dUtils.CalcDiagonalXYZ(0, height, depth));
        }
    }
}
