using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Queens
{
    private const int Size = 8;
    private const char EmptyCell = '0';
    private const char AttackedCell = '1';
    private const char Queen = 'Q';
    private static int queensCounter = 0;
    private static char[,] board = new char[Size, Size];

    static void Main()
    {
        int row = 0;
        int col = 0;
        for (int rows = 0; rows < Size; rows++)
        {
            row = rows;
            col = 0;
            SetQueen(row, col);
            queensCounter = 0;
            board = new char[Size, Size];
        }

    }

    private static void SetQueen(int row, int col)
    {
        if (!IsInRange(row, col))
        {
            return;
        }

        if (board[row, col] == EmptyCell - '0')
        {
            FillCurrentRow(row);
            FillCurrentCol(col);
            FillTopLeftDiagonal(row, col);
            FillTopRightDiagonal(row, col);
            FillBottomLeftDiagonal(row, col);
            FIllBottomRightDiagonal(row, col);

            board[row, col] = Queen;
            queensCounter++;
            if (queensCounter == 8)
            {
                Print();
            }

            SetQueen(row, col + 1);
            SetQueen(row + 1, col - 1);
        }
        else
        {
            SetQueen(row - 1, col + 1);
            SetQueen(row + 1, col + 1);
            SetQueen(row + 1, col);

        }
    }

    private static void Print()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static bool IsInRange(int row, int col)
    {
        if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
        {
            return true;
        }
        return false;
    }

    private static void FillCurrentCol(int col)
    {
        for (int i = 0; i < Size; i++)
        {
            board[i, col] = '1';
        }
    }

    private static void FillCurrentRow(int row)
    {
        for (int i = 0; i < Size; i++)
        {
            board[row, i] = '1';
        }
    }

    private static void FIllBottomRightDiagonal(int row, int col)
    {
        int rowBottomRight = row + 1;
        int colBottomRight = col + 1;
        while (rowBottomRight < Size && colBottomRight < Size)
        {
            board[rowBottomRight, colBottomRight] = '1';
            rowBottomRight++;
            colBottomRight++;
        }
    }

    private static void FillBottomLeftDiagonal(int row, int col)
    {
        int rowBottomLeft = row + 1;
        int colBottomLeft = col - 1;
        while (rowBottomLeft < Size && colBottomLeft >= 0)
        {
            board[rowBottomLeft, colBottomLeft] = '1';
            rowBottomLeft++;
            colBottomLeft--;
        }
    }

    private static void FillTopRightDiagonal(int row, int col)
    {
        int rowTopRight = row - 1;
        int colTopRight = col + 1;
        while (rowTopRight >= 0 && colTopRight < Size)
        {
            board[rowTopRight, colTopRight] = '1';
            rowTopRight--;
            colTopRight++;
        }
    }

    private static void FillTopLeftDiagonal(int row, int col)
    {
        int diagonalRowTopLeft = row - 1;
        int diagonalColTopLeft = col - 1;
        while (diagonalRowTopLeft >= 0 && diagonalColTopLeft >= 0)
        {
            board[diagonalRowTopLeft, diagonalColTopLeft] = '1';
            diagonalRowTopLeft--;
            diagonalColTopLeft--;
        }
    }
}