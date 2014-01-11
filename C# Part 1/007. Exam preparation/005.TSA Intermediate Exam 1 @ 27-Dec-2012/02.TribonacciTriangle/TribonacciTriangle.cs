using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TribonacciTriangle
{
    static void Main()
    {
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());

        Console.WriteLine(first);
        Console.Write(second + " ");
        Console.WriteLine(third);

        for (int rows = 3; rows <= l; rows++)
        {
            for (int i = 0; i < rows; i++)
            {
                long next = first + second + third;
                first = second;
                second = third;
                third = next;
                if (i < rows - 1)
                {
                    Console.Write("{0} ", next);
                }
                else
                {
                    Console.Write("{0}", next);
                }
            }
            Console.WriteLine();
        }
    }
}

