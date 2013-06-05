using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < (2 * n - 1) / 2 + 1; i++)
        {
            string dots1 = new String('.', i);
            string ast = "*";
            string dots2 = new String('.', n - i - 1);
            Console.WriteLine(dots1 + ast + dots2);
        }

        int maxdots1 = n - 2;
        int maxdots2 = 1;

        for (int i = n + 1; i <= (2 * n - 1); i++)
        {
            
            string dots1 = new String('.', maxdots1);
            string ast = "*";
            string dots2 = new String('.', maxdots2);
            Console.WriteLine(dots1 + ast + dots2);
            maxdots1--;
            maxdots2++;
        }


    }
}

