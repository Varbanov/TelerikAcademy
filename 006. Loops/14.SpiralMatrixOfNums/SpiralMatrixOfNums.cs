using System;

class SpiralMatrixOfNums
{
    // *Write a program that reads a positive integer number N (N < 20) from console and outputs in
    //the console the numbers 1 ... N numbers arranged as a spiral.
    //Example for N = 4
    //1  2  3  4
    //12 13 14 5
    //11 16 15 6
    //10 9  8  7
    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter \"N\" [1..19]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 19);

        //solution
        int[,] matrix = new int[n, n];
        int maxCol = n - 1;
        int maxRow = n - 1;
        int minCol = 0;
        int minRow = 0;
        int maxCounter = n * n;
        int counter = 1;

        while (counter <= maxCounter)
        {
            //uppermost row
            for (int col = minCol; col <= maxCol; col++)
            {
                matrix[minRow, col] = counter;
                counter++;
            }
            minRow++;

            //rightmost column
            for (int row = minRow; row <= maxRow; row++)
            {
                matrix[row, maxCol] = counter;
                counter++;
            }
            maxCol--;

            //downmost row
            for (int col = maxCol; col >= minCol; col--)
            {
                matrix[maxRow, col] = counter;
                counter++;
            }
            maxRow--;

            //leftmost column
            for (int row =  maxRow; row >= minRow; row--)
            {
                matrix[row, minCol] = counter;
                counter++;
            }
            minCol++;
        }

        //output
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0} ", matrix[row, col].ToString().PadLeft(3));
            }
            Console.WriteLine();
        }
    }
}

