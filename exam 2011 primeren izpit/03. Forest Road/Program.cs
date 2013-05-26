using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        for (int row = 0; row < n; row++)
        {
            string dot = new String('.', row);
            string dot2 = new String('.', n - row - 1);
            Console.WriteLine("{0}*{1}", dot, dot2);
        }
        for (int row = 0; row < n - 1; row++)
        {
            string dot = new String('.', n - 2 - row);
            string dot2 = new String('.', row + 1);
            Console.WriteLine("{0}*{1}", dot, dot2);
        }
    }
}

