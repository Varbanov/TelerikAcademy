using System;

class FindMaxSum3x3InMatrix
{
    //Write a program that reads a rectangular matrix of size N x M and
    //finds in it the square 3 x 3 that has maximal sum of its elements.

    public struct StartPoint
    {
        public int row;
        public int col;
    }

    static void Main()
    {
        //input
        int[,] matrix = 
        {
            {1,1,1,1,3},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {9,1,1,1,4},
        };

        //solution
        int leftmostStart = matrix.GetLength(1) - 2;
        int downmostStart = matrix.GetLength(0) - 2;
        int maxSum = int.MinValue;
        StartPoint bestStart = new StartPoint();

        for (int row = 0; row < downmostStart; row++)
        {
            for (int col = 0; col < leftmostStart; col++)
            {
                int sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sum += matrix[row + i, col + j];
                    }
                }

                if (sum >= maxSum)
                {
                    maxSum = sum;
                    bestStart.row = row;
                    bestStart.col = col;
                }
            }
        }

        //output
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write("{0, 3} ", matrix[bestStart.row + row, bestStart.col + col]);
            }
            Console.WriteLine();
        }
    }
}
