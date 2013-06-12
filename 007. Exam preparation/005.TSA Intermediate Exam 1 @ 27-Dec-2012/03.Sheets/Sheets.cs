using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] sheets = new int[11];
        for (int i = 0; i < 11; i++)
        {
            int temp = 1024;
            sheets[i] = temp >> i;
        }

        //solution
        List<int> bestPositions = new List<int>();
        int minDifference = int.MaxValue;

        for (int i = 0; i < 2047; i++)
        {
            int temp = i;
            int tempSum = 0;
            int tempDifference;
            List<int> currPositions = new List<int>();
            
            for (int bitPos = 0; bitPos < 11; bitPos++)
            {
                if (((temp >> bitPos) & 1) == 1)
                {
                    tempSum += sheets[bitPos];
                    currPositions.Add(bitPos);
                }
            }

            if (tempSum >= n)
            {
                tempDifference = tempSum - n;
                if (tempDifference < minDifference)
                {
                    minDifference = tempDifference;
                    bestPositions = currPositions;
                }
            }


        }

        //output
        for (int i = 0; i < 11; i++)
        {
            if (!bestPositions.Contains(i))
            {
                Console.WriteLine("A{0}", i);
            }
        }
    }
}

