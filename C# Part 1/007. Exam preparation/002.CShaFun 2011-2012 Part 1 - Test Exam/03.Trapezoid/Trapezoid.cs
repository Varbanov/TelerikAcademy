using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string d1 = new string('.', n);
        string a1 = new string('*', n);
        Console.WriteLine(d1 + a1);

        int p = n - 1;
        for (int i = n-2; i >= 0; i--)
        {
            string dots1 = new string('.', i + 1);
            string dots2 = new string('.', p);
            p++;
            Console.WriteLine(dots1 + "*" + dots2 + "*");
        }

        string a2 = new string('*', n * 2);
        Console.WriteLine(a2);
        


    }
}

