using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pillars
{
    static void Main()
    {
        int[] nums = new int[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int[,] matrix = new int[8, 8];

        for (int rows = 0; rows < 8; rows++)
        {
            for (int cols = 0; cols < 8; cols++)
            {
                matrix[rows, cols] = nums[rows] & 1;
                nums[rows] >>= 1;
            }
        }

        //solution

        for (int pillar = 7; pillar >= 0; pillar--)
        {
            int leftSum = 0;
            int rightSum = 0;
            for (int rows = 0; rows < 8; rows++)
            {
                for (int colsLeft = 7; colsLeft > pillar; colsLeft--)
                {
                    leftSum += matrix[rows, colsLeft]; 
                }

                for (int colsRight = 0; colsRight < pillar; colsRight++)
                {
                    rightSum += matrix[rows, colsRight];
                }

            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(leftSum);
                return;
            }
        }

        Console.WriteLine("No");
    }
}

