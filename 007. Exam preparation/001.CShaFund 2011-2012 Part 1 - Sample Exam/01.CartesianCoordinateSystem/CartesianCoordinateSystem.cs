using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class CartesianCoordinateSystem
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        decimal xCoor = decimal.Parse(Console.ReadLine());
        decimal yCoor = decimal.Parse(Console.ReadLine());

        int res = 0;

        if (xCoor == 0 && yCoor != 0)
        {
            res = 5;
        }
          
        if (yCoor == 0 && xCoor != 0)
        {
            res = 6;
        }

        if (yCoor == 0 && xCoor == 0)
        {
            res = 0;
        }

        if (xCoor > 0 && yCoor > 0)
        {
            res = 1;
        }

        if (xCoor > 0 && yCoor < 0)
        {
            res = 4;
        }
          
        if (xCoor < 0 && yCoor > 0)
        {
            res = 2;
        }
          
        if (xCoor < 0 && yCoor < 0)
        {
            res = 3;
        }
        Console.WriteLine(res);
    }
}

