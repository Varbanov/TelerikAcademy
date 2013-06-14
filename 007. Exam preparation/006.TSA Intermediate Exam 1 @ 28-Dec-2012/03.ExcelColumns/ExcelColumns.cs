using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExcelColumns
{
    static void Main()
    {
        long n = int.Parse(Console.ReadLine());

        long sum = 0;

        for (long i = n - 1; i >= 0; i--)
        {
            string symbol = Console.ReadLine();

            sum += (long)Math.Pow(26, i) * (((int)symbol[0]) - 64); 

        
        }

        Console.WriteLine(sum);
    }
}

