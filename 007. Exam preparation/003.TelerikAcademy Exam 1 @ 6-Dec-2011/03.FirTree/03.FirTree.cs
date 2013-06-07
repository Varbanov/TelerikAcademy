using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1, ast = 1, dot = ((2 * n) - 3) / 2; i < n; i++, ast += 2, dot -= 1)
        {
            string dots = new string('.', dot);
            string asts = new string('*', ast);

            Console.WriteLine(dots + asts + dots);
        }

        string bottomDots = new string('.', (2 * n - 4) / 2);
        Console.WriteLine(bottomDots + "*" + bottomDots);


    }
}

