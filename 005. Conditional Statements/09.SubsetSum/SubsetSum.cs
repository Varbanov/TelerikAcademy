using System;
using System.Collections.Generic;

class SubsetSum
{
    //We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
    //Example: 3, -2, 1, 1, 8  1+1-2=0.
    static void Main()
    {
        //input using matrix
        int[] nums = new int[5];
        for (int i = 0; i < 5; i++)
        {
            do
            {
                Console.Write("Please enter integer {0}: ", i + 1);
            } while (!int.TryParse(Console.ReadLine(), out nums[i]));
        }

        //solution (alternating numbers 1 - 2^5 - 1 to alternate all subset sums)
        int sum = 0;
        List<int> sumMembers = new List<int>();
        bool zeroSum = false;
        
        //alternate 1 - 2^5 - 1
        for (int i = 1; i <= 31; i++)
        {
            sum = 0;
            sumMembers.Clear();

            //check bits at each position (0 - 4) and add corresponding number if bit = 1;
            for (int bitPosition = 0; bitPosition < 5; bitPosition++)
            {
                int currBit = 1 & (i >> bitPosition);
                if (currBit == 1)
                {
                    sum += nums[bitPosition];
                    sumMembers.Add(nums[bitPosition]);
                }
            }

            //output
            if (sum == 0)
            {
                zeroSum = true;
                Console.WriteLine("There is a subset sum = 0. The numbers are:");
                foreach (var member in sumMembers)
                {
                    Console.Write("{0}, ", member);
                }
                Console.WriteLine();
            }
        }
        if (!zeroSum)
        {
            Console.WriteLine("No subset sums = 0");
        }
    }
}
