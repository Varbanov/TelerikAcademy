using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FallDown
{
    static void Main()
    {
        int[,] matrix = new int[8,8];

        for (int rows = 0; rows < 8; rows++)
        {
            int tempNum = int.Parse(Console.ReadLine());

            for (int cols = 7; cols >= 0; cols--)
            {
                matrix[rows, cols] = (tempNum >> 7 - cols) & 1;
            }
        }

        for (int rows = 6; rows >= 0; rows--)
        {
            for (int cols = 0; cols < 8; cols++)
            {
                int currRow = rows;
                int nextRow = currRow + 1;
                while (nextRow < 8 && matrix[nextRow, cols] == 0)
                {
                    matrix[nextRow, cols] = matrix[currRow, cols];
                    matrix[currRow, cols] = 0;
                    nextRow++;
                    currRow++;
                }
            }
        }
        Console.WriteLine();

        for (int rows = 0; rows < 8; rows++)
        {
            int tempNum = 0;

            for (int cols = 0; cols < 8; cols++)
            {
                tempNum = (matrix[rows, cols] | tempNum) << 1;
            }
            Console.WriteLine(tempNum >> 1);
        }



    }
}

