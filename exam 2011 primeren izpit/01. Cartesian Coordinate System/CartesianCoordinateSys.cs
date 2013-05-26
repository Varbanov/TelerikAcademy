using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


public class CartesianCoordinateSys
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        decimal x = decimal.Parse(Console.ReadLine());
        decimal y = decimal.Parse(Console.ReadLine());

        // chertejut ot uslovieto e greshen - razmeneni sa 5 i 6
        if (x > 0 && y > 0)
            Console.WriteLine("1");
        if (x < 0 && y > 0)
            Console.WriteLine("2");
        if (x < 0 && y < 0)
            Console.WriteLine("3");
        if (x > 0 && y < 0)
            Console.WriteLine("4");
        if (x == 0 && y != 0)
            Console.WriteLine("5");
        if (y == 0 && x != 0)
            Console.WriteLine("6");
        if (x == 0 && y == 0)
            Console.WriteLine("0");
    }
}

