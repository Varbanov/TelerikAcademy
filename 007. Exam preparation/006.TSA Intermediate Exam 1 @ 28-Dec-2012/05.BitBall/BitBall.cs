using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitBall
{
    static void Main()
    {
        int[,] topMatrix = new int[8, 8];
        int[,] bottomMatrix = new int[8, 8];

        //input
        for (int rows = 0; rows < 8; rows++)
        {
            int currNum = int.Parse(Console.ReadLine());

            for (int cols = 0; cols < 8; cols++)
            {
                topMatrix[rows, cols] = (currNum & (1 << cols)) >> cols;
            }
        }

        for (int rows = 0; rows < 8; rows++)
        {
            int currNum = int.Parse(Console.ReadLine());

            for (int cols = 0; cols < 8; cols++)
            {
                bottomMatrix[rows, cols] = (currNum & (1 << cols)) >> cols;

                //rough players receive red cards..
                if (topMatrix[rows, cols] == bottomMatrix[rows, cols])
                {
                    topMatrix[rows, cols] = 0;
                    bottomMatrix[rows, cols] = 0;
                }
            }
        }

        //top team solution
        int topScores = 0;

        for (int cols = 0; cols < 8; cols++)
        {
            bool firstPlayer = false;
            for (int rows = 7; rows >= 0; rows--)
            {
                if (!firstPlayer && topMatrix[rows, cols] == 1)
                {
                    bool goal = true;
                    firstPlayer = true;
                    int tempRow = rows;

                    while (tempRow < 8)
                    {
                        if (bottomMatrix[tempRow, cols] != 0)
                        {
                            goal = false;
                            break;
                        }
                        tempRow++;
                    }

                    if (goal)
                    {
                        topScores++;
                    }
                }
            }
        }

        //bottom team solution
        int bottomScores = 0;

        for (int cols = 0; cols < 8; cols++)
        {
            bool firstPlayer = false;
            for (int rows = 0; rows < 8; rows++)
            {
                if (!firstPlayer && bottomMatrix[rows, cols] == 1)
                {
                    bool goal = true;
                    firstPlayer = true;
                    int tempRow = rows;

                    while (tempRow >= 0)
                    {
                        if (topMatrix[tempRow, cols] != 0)
                        {
                            goal = false;
                            break;
                        }
                        tempRow--;
                    }

                    if (goal)
                    {
                        bottomScores++;
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", topScores, bottomScores);
    }
}
