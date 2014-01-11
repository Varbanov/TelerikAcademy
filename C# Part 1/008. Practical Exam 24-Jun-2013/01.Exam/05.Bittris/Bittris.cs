using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Bittris
{

    static bool CanMoveLeft(int[,] matrix, int row)
    {
        bool canMoveLeft = false;

        if (matrix[row, 0] != 1)
        {
            canMoveLeft = true;
        }
       
        return canMoveLeft;
    }

    static bool CanMoveRight(int[,] matrix, int row)
    {
        bool canMoveRight = false;

        if (matrix[row, 7] != 1)
        {
            canMoveRight = true;
        }
        return canMoveRight;
    }

    static bool CanMoveDown(int[,] matrix, int row)
    {
        bool canMoveDown = true;

        if (row == 3)
        {
            canMoveDown = false;
        }
        else
        {
            for (int col = 0; col < 8; col++)
            {
                if (row < 3 && matrix[row, col] == 1 && matrix[row + 1, col] == 1)
                {
                    canMoveDown = false;
                    break;
                }
            }
        }
        return canMoveDown;
    }

    static int[,] MovesDown(int[,] matrix, int row)
    {
        for (int col = 0; col < 8; col++)
        {
            matrix[row + 1, col] = matrix[row, col] | matrix[row + 1, col];
            matrix[row, col] = 0;
        }
        return matrix;
    }

    static int[,] MovesLeft(int[,] matrix, int row)
    {
        for (int col = 0; col < 7; col++)
        {
            matrix[row, col] = matrix[row, col + 1];
        }
        matrix[row, 7] = 0;
        return matrix;
    }

    static int[,] MovesRight(int[,] matrix, int row)
    {
        for (int col = 7; col > 0; col--)
        {
            matrix[row, col] = matrix[row, col - 1];
        }
        matrix[row, 0] = 0;
        return matrix;
    }

    static int[,] ClearLine(int[,] matrix, int row)
    {
        bool clear = true;

        for (int i = 0; i < 8; i++)
        {
            if (matrix[row, i] == 0)
            {
                clear = false;
                break;
            }

        }

        if (clear)
        {
            for (int i = 0; i < 8; i++)
            {
                matrix[row, i] = 0;
            }
        }

        return matrix;
    }
 

    static void Main()
    {
        int scores = 0;
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[4, 8];

        while (n != 0)
        {
            int piece = int.Parse(Console.ReadLine());

            int bitPosition = 7;
            int currPiece = piece;
            for (int i = 7; i >= 0; i--)
            {
                matrix[0, i] = currPiece & 1;
                currPiece >>= 1; 
            }

            int currRow = 0;
            string firstMove = Console.ReadLine();
            string secondMove = Console.ReadLine();
            string thirdMove = Console.ReadLine();

//first move
            if (CanMoveDown(matrix, currRow))
            {
                if (firstMove == "D")
                {
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (firstMove == "L")
                {
                    matrix = MovesLeft(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (firstMove == "R")
                {
                    matrix = MovesRight(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
            }

//second move
            if (CanMoveDown(matrix, currRow))
            {
                if (secondMove == "D")
                {
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (secondMove == "L")
                {
                    matrix = MovesLeft(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (secondMove == "R")
                {
                    matrix = MovesRight(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
            }

//third move
            if (CanMoveDown(matrix, currRow))
            {
                if (thirdMove == "D")
                {
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (thirdMove == "L")
                {
                    matrix = MovesLeft(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
                else if (thirdMove == "R")
                {
                    matrix = MovesRight(matrix, currRow);
                    matrix = MovesDown(matrix, currRow);
                    currRow++;
                }
            }

            


            n -= 4;
        }



        Console.WriteLine();
    }
}

