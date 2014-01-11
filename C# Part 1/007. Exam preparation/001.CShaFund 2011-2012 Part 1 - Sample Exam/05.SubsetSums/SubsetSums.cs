using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] nums = new long[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = long.Parse(Console.ReadLine());
        }

        int maxNum = (int) Math.Pow(2, n) - 1;
        int counter = 0;
        for (int i = 1; i <= maxNum ; i++)
        {
            int tempNum = i;
            long tempSum = 0;
            int temPosition = 0;
            while (tempNum != 0)
            {
                if ((tempNum & 1) == 1)
                {
                    tempSum += nums[temPosition];
                }
                tempNum >>= 1;
                temPosition += 1;
            }

            if (tempSum == s)
            {
                counter++;
            }

        }
        Console.WriteLine(counter);




    }
}

