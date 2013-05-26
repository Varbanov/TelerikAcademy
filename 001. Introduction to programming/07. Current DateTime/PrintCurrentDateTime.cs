using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintCurrentDateTime
{
    //Create a console application that prints the current date and time.

    static void Main()
    {
        DateTime currentDateTime = DateTime.Now;

        Console.WriteLine(currentDateTime);
    }
}

