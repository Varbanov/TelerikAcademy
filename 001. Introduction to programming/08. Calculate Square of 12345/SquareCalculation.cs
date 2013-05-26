using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SquareCalculation
{
    //Create a console application that calculates and prints the square of the number 12345.

    static void Main()
    {
        int num = 12345;
        double squareOfNum = Math.Pow(num, 2);
        Console.WriteLine("The square of 12345 is: {0}", squareOfNum);
    }
}

