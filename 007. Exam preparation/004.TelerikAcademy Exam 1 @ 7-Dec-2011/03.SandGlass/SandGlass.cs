using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1, ast = n, dot = 0 ; i <= n / 2 + 1; i++, ast -= 2, dot += 1)
        {
            string asts = new string('*', ast);
            string dots = new string('.', dot);
            
            Console.WriteLine(dots + asts + dots);
        }

        for (int i = 1, ast = 3, dot = (n - 3) / 2; i <= n / 2; i++, ast += 2, dot -= 1)
        {
            string asts = new string('*', ast);
            string dots = new string('.', dot);

            Console.WriteLine(dots + asts + dots);

        }


    }
}

