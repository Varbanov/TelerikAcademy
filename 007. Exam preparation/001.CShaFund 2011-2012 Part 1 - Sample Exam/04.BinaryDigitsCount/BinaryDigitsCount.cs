using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryDigitsCount
{
    static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            uint num = uint.Parse(Console.ReadLine());
            int counter = 0;

            while (num != 0)
            {
                int bit = (int) num & 1;
                if (bit == b)
                {
                    counter++;
                }
                num >>= 1;
            }

            Console.WriteLine(counter);


        }


    }
}

