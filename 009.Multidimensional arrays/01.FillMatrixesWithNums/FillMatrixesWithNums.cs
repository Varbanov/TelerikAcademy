using System;

class FillMatrixesWithNums
{
    /*Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
 *      a)          b)          c)            d*)
 * 1 5 9  13    1 8 9  16   7 11 14 16    1 12 11 10
 * 2 6 10 14    2 7 10 15   4 8  12 15    2 13 16 9
 * 3 7 11 15    3 6 11 14   2 5  9  13    3 14 15 8
 * 4 8 12 16    4 5 12 13   1 3  6  10    4 5  6  7
 * */
    static void PrintMatrix(int[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write("{0,3} ", matrix[rows, cols]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter \"n\": ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        //solution a)
        int[,] matrix = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter++;
            }
        }

        PrintMatrix(matrix);

        //solution b)
        Array.Clear(matrix, 0, n * n);
        counter = 1;
        for (int col = 0; col < n; col += 2)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter++;
            }
            counter += n;
        }

        counter = n + 1;
        for (int col = 1; col < n; col += 2)
        {
            for (int row = n - 1; row > -1; row--)
            {
                matrix[row, col] = counter++;
            }
            counter += n;
        }

        PrintMatrix(matrix);

        //solution c)
        Array.Clear(matrix, 0, n * n);
        counter = 1;
        for (int row = n - 1; row >= 0; row--)
        {
            matrix[row, 0] = counter++;
            int lowerRow = row + 1;
            int rightCol = 1;
            while (lowerRow < n && rightCol < n)
            {
                matrix[lowerRow, rightCol] = counter++;
                lowerRow++;
                rightCol++;
            }
        }

        for (int col = 1; col < n; col++)
        {
            int lowerRow = 0;
            int rightCol = col;
            while (lowerRow < n && rightCol < n)
            {
                matrix[lowerRow, rightCol] = counter++;
                lowerRow++;
                rightCol++;
            }
        }

        PrintMatrix(matrix);

        //solution d)
        Array.Clear(matrix, 0, n * n);
        counter = 1;
        int maxCol = n - 1;
        int maxRow = n - 1;
        int minCol = 0;
        int minRow = 0;
        int maxCounter = n * n;

        while (counter <= maxCounter)
        {
            //leftmost column
            for (int row = minRow; row <= maxRow; row++)
            {
                matrix[row, minCol] = counter;
                counter++;
            }
            minCol++;

            //downmost row
            for (int col = minCol; col <= maxCol; col++)
            {
                matrix[maxRow, col] = counter;
                counter++;
            }
            maxRow--;

            //rightmost column
            for (int row = maxRow; row >= minRow; row--)
            {
                matrix[row, maxCol] = counter;
                counter++;
            }
            maxCol--;

            //uppermost row
            for (int col = maxCol; col >= minCol; col--)
            {
                matrix[minRow, col] = counter;
                counter++;
            }
            minRow++;
        }

        PrintMatrix(matrix);
    }
}