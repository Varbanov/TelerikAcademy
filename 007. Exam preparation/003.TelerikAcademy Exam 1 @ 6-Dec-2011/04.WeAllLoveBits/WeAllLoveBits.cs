using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        uint[] nums = new uint[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = uint.Parse(Console.ReadLine());
        }

        //solution
        uint[] pXORp = new uint[n];
        uint[] pWithDots = new uint[n];

        for (int i = 0; i < n; i++)
        {
            //P ^ P~
            int bitCounter = 0;
            uint temp = nums[i];
            while (temp != 0)
            {
                temp >>= 1;
                bitCounter++;
            }

            for (int bitPos = 0; bitPos < bitCounter; bitPos++)
            {
                pXORp[i] |= 1;
                pXORp[i] <<= 1;

                //p with dots
                uint currBit = (nums[i] >> bitPos) & 1;
                pWithDots[i] |= currBit;
                pWithDots[i] <<= 1;
            }

            pXORp[i] >>= 1;
            pWithDots[i] >>= 1;

            Console.WriteLine(pXORp[i] & pWithDots[i]);
        }

    }
}

