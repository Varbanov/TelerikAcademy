using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BatGoikoTower
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());

        int outerDot = (2 * h - 2) / 2;

        int dashStep = 1;
        int dashLine = 1;

        for (int i = 0; i < h; i++, outerDot--)
        {
           string leftDots = new string('.', outerDot);

           Console.Write(leftDots);
           Console.Write("/");

           if (i == dashLine)
           {
               int innerdot = (h * 2) - (outerDot * 2) - 2;
               string innerDots = new string('-', innerdot);
               Console.Write(innerDots);

               dashStep++;
               dashLine += dashStep;
           }
           else
           {
               int innerdot = (h * 2) - (outerDot * 2) - 2;
               string innerDots = new string('.', innerdot);
               Console.Write(innerDots);
           }

           Console.Write("\\" + leftDots);

           

           Console.WriteLine();
        }



    }
}

