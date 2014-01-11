using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
       BigInteger first = int.Parse(Console.ReadLine());
        BigInteger second = int.Parse(Console.ReadLine());
        BigInteger third = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        BigInteger next = 0;
        if (n == 1)
        {
            next = first;
        }
        else if (n == 2)
        {
            next = second;
        }
        else if (n == 3)
        {
            next = third;
        }
        else
        {
             int max = n - 3;
            for (int i = 0; i < max; i++)
            {
                next = first + second + third;
                first = second;
                second = third;
                third = next;
            }
        }
        Console.WriteLine(next);

    }
}

