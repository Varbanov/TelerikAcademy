using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubsetSums
{
    static void Main()
    {
        byte b = byte.Parse(Console.ReadLine());
        short n = short.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            uint num = uint.Parse(Console.ReadLine());
            byte counter = 0;

            if (b == 1)
            {
                while (num > 0)
                {
                    if ((num & b) == 1)
                    {
                        counter++;
                    }
                    num >>= 1;
                }
            }
            if (b == 0)
            {
                while (num > 0)
                {
                    if ((num & 1) == 0)
                    {
                        counter++;
                    }
                    num >>= 1;
                }
            }
            Console.WriteLine(counter);
        }
    }
}

