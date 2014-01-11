using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Lines
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        //input
        for (int rows = 0; rows < 8; rows++)
        {
            int temp = int.Parse(Console.ReadLine());
            for (int cols = 0; cols < 8; cols++)
            {
                matrix[rows, cols] = (temp >> cols) & 1;
            }
        }

        //solution
        int bestLength = 1;
        int linesCounter = 0;
        for (int rows = 0; rows < 8; rows++)
        {
            for (int cols = 7; cols >=0; cols--)
            {
                //searching for horizontal lines
                int length = 0;
                int rightCellCol = cols - 1;
                if (matrix[rows, cols] == 1)
                {
                    length = 1;
                    while (rightCellCol >= 0)
                    {
                        if (matrix[rows, rightCellCol] == matrix[rows, cols])
                        {
                            length++;
                            rightCellCol--;
                        }
                        else
                            break;
                    }
                }

                if (length > bestLength)
                {
                    bestLength = length;
                    linesCounter = 1;
                }
                else if (length == bestLength)
                {
                    linesCounter++;
                }

                //searching for vertical lines
                length = 0;
                int lowerCellRow = rows + 1;
                if (matrix[rows, cols] == 1)
                {
                    length = 1;
                    while (lowerCellRow <= 7)
                    {
                        if (matrix[lowerCellRow, cols] == matrix[rows, cols])
                        {
                            length++;
                            lowerCellRow++;
                        }
                        else
                            break;
                    }
                }

                if (length > bestLength)
                {
                    bestLength = length;
                    linesCounter = 1;
                }
                else if (length == bestLength)
                {
                    linesCounter++;
                }
            }
        }
        if (bestLength == 1)
        {
            linesCounter /= 2;
        }
        Console.WriteLine(bestLength);
        Console.WriteLine(linesCounter);
    }
}

