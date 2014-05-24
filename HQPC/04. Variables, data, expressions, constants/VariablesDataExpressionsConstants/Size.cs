using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Size
{
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public static Size GetRotatedSize(Size size, double rotationAngle)
    {
        var newWidth = (Math.Abs(Math.Cos(rotationAngle)) * size.Width) + (Math.Abs(Math.Sin(rotationAngle)) * size.Height);
        var newHeight = (Math.Abs(Math.Sin(rotationAngle)) * size.Width) + (Math.Abs(Math.Cos(rotationAngle)) * size.Height);
        Size result = new Size(newWidth, newHeight);
        return result;
    }
}
