using System;

public static class Matrix
{
    private static void ChangeDirection(ref int changeInX, ref int changeInY)
    {
        int[] possibleDirectionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] possibleDirectionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int possibleDirectionIndex = 0;

        for (int count = 0; count < 8; count++)
        {
            if (possibleDirectionsX[count] == changeInX && possibleDirectionsY[count] == changeInY)
            {
                possibleDirectionIndex = count;
                break;
            }
        }

        if (possibleDirectionIndex == 7)
        {
            changeInX = possibleDirectionsX[0]; changeInY = possibleDirectionsY[0];
            return;
        }

        changeInX = possibleDirectionsX[possibleDirectionIndex + 1];
        changeInY = possibleDirectionsY[possibleDirectionIndex + 1];
    }

    private static bool CheckDirection(int[,] arr, int col, int row)
    {
        int[] possibleDirectionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] possibleDirectionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        for (int i = 0; i < possibleDirectionsX.Length; i++)
        {
            if (col + possibleDirectionsX[i] >= arr.GetLength(0) || col + possibleDirectionsX[i] < 0)
            {
                possibleDirectionsX[i] = 0;
            }

            if (row + possibleDirectionsY[i] >= arr.GetLength(0) || row + possibleDirectionsY[i] < 0)
            {
                possibleDirectionsY[i] = 0;
            }
        }

        for (int i = 0; i < possibleDirectionsX.Length; i++)
        {
            if (arr[col + possibleDirectionsX[i], row + possibleDirectionsY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    private static void FindAnyFreeCell(int[,] arr, out int col, out int row)
    {
        col = 0;
        row = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    col = i; row = j;
                    return;
                }
            }
        }
    }

    public static int[,] GetFilledMatrix(int size)
    {
        int n = size;
        int[,] matrix = new int[n, n];
        int step = n;
        int value = 1;
        int col = 0;
        int row = 0;
        int changeX = 1;
        int changeY = 1;
        while (true)
        {
            matrix[col, row] = value;

            if (!CheckDirection(matrix, col, row))
            {
                break;
            }

            if (col + changeX >= n || col + changeX < 0 || row + changeY >= n || row + changeY < 0 || matrix[col + changeX, row + changeY] != 0)
            {
                while ((col + changeX >= n || col + changeX < 0 || row + changeY >= n || row + changeY < 0 || matrix[col + changeX, row + changeY] != 0))
                {
                    ChangeDirection(ref changeX, ref changeY);
                }
            }

            col += changeX;
            row += changeY;
            value++;
        }

        //for (int p = 0; p < n; p++)
        //{
        //    for (int q = 0; q < n; q++) Console.Write("{0,3}", matrix[p, q]);
        //    Console.WriteLine();
        //}

        FindAnyFreeCell(matrix, out col, out row);

        if (col != 0 && row != 0)
        {
            changeX = 1; changeY = 1;

            while (true)
            {
                matrix[col, row] = value;
                if (!CheckDirection(matrix, col, row)) 
                {
                    break; 
                }

                if (col + changeX >= n || col + changeX < 0 || row + changeY >= n || row + changeY < 0 || matrix[col + changeX, row + changeY] != 0)
                {
                    while ((col + changeX >= n || col + changeX < 0 || row + changeY >= n || row + changeY < 0 || matrix[col + changeX, row + changeY] != 0))
                    {
                        ChangeDirection(ref changeX, ref changeY);
                    }
                }

                col += changeX; row += changeY; value++;
            }
        }



        //for (int pp = 0; pp < n; pp++)
        //{
        //    for (int qq = 0; qq < n; qq++) Console.Write("{0,3}", matrix[pp, qq]);
        //
        //    Console.WriteLine();
        //}


        return matrix;
    }
}


