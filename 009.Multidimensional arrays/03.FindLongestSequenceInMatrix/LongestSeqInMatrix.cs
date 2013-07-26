using System;

class LongestSeqInMatrix
{
    //We are given a matrix of strings of size N x M. Sequences in the matrix
    //we define as sets of several neighbor elements located on the same line,
    //column or diagonal. Write a program that finds the longest sequence of equal
    //strings in the matrix. Example:
    //
    //ha fifi ho hi     s qq  s
    //fo ha   hi xx     pp pp s
    //xxx ho ha  xx     pp qq s
    //

    static void Main()
    {
        //input
        string[,] matrix = 
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"},
        };
        //string[,] matrix =
        //{
        //    {"s", "qq", "s"},
        //    {"pp", "pp", "s"},
        //    {"pp", "qq", "s"},
        //};


        //solution
        int maxCount = 0;
        string maxElem = "";
        
        //rows
        int tempCount = 1;
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            int tempCol = 0;
            for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
            {
                if (matrix[rows, cols] == matrix[rows, cols + 1])
                {
                    tempCount++;
                    tempCol = cols;
                }
                else
                {
                    tempCount = 1;
                }
                //extract best length so far
                if (tempCount >= maxCount)
                {
                    maxCount = tempCount;
                    maxElem = matrix[rows, tempCol];
                }
            }
        }

        //cols
        tempCount = 1;
        for (int cols = 0; cols < matrix.GetLength(1); cols++)
        {
            int tempRow = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                if (matrix[rows, cols] == matrix[rows + 1, cols])
                {
                    tempCount++;
                    tempRow = rows;
                }
                else
                {
                    tempCount = 1;
                }
                //extract best length so far
                if (tempCount >= maxCount)
                {
                    maxCount = tempCount;
                    maxElem = matrix[tempRow, cols];
                }
            }
        }

        //left-to-right diagonals
        tempCount = 1;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int tempRow = row;
                int tempCol = col;
                //till the end of the diagonal is reached
                while ((tempCol + 1) < matrix.GetLength(1) && (tempRow + 1) < matrix.GetLength(0))
                {
                    if (matrix[tempRow, tempCol] == matrix[tempRow + 1, tempCol + 1])
                    {
                        tempCount++;
                        tempRow++;
                        tempCol++;
                    }
                    else
                    {
                        tempCount = 1;
                        tempRow++;
                        tempCol++;
                    }
                    //extract best length so far
                    if (tempCount >= maxCount)
                    {
                        maxCount = tempCount;
                        maxElem = matrix[tempRow -1, tempCol - 1];
                    }
                }
            }
        }

        //right to left diagonals
        tempCount = 1;
        for (int rows = matrix.GetLength(0) - 1; rows >= 0; rows--)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int tempRow = rows;
                int tempCol = cols;
                while ((tempRow - 1) >= 0 && (tempCol - 1) >= 0)
                {
                    if (matrix[tempRow, tempCol] == matrix[tempRow - 1, tempCol - 1])
                    {
                        tempCount++;
                    }
                    else
                    {
                        tempCount = 1;
                    }

                    tempRow--;
                    tempCol--;
                    //extract best length so far
                    if (tempCount > maxCount)
                    {
                        maxCount = tempCount;
                        maxElem = matrix[tempRow -1, tempCol - 1];
                    }
                }
            }
        }

        //output
        for (int i = 0; i < maxCount - 1; i++)
        {
            Console.Write("{0}, ", maxElem);
        }
        Console.WriteLine(maxElem);
    }
}

