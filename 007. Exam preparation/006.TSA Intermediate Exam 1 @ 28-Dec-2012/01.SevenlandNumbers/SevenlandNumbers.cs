using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SevenlandNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int next = n;


        if (n % 10 == 6)
        {
            if ((n % 100) / 10 == 6 && (n / 100 != 6))
            {
                next -= 6;
                next += 40;
            }
            else if ((n % 100) / 10 == 6 && (n / 100 == 6))
            {
                next = 1000;
            }
            else
            {
                next += 4;
            }
        }
        else
        {
            next += 1;
        }

        Console.WriteLine(next);
    }
}

