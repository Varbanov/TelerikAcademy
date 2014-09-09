using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindAllPathsInMatrix
{
    public class FindPath
    {
        static int[,] matrix = new int[100, 100];

        static bool[,] visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        static bool pathExists = false;

        //find path from [0,0] to [99, 99]
        static int endRow = matrix.GetLength(0) - 1;
        static int endCol = matrix.GetLength(1) - 1;


        public static void TraverseMatrix(bool[,] visited, int startRow, int startCol)
        {
            if (startRow < 0 || startRow >= matrix.GetLength(0))
            {
                return;
            }

            if (startCol < 0 || startCol >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[startRow, startCol] == 1)
            {
                //non-passable cell
                return;
            }

            if (visitedCells[startRow, startCol])
            {
                // exclude passed cells to prevent endless loops between cells
                return;
            }

            if (startRow == endRow && startCol == endCol)
            {
                //end cell is reached
                pathExists = true;
                return;
            }

            visitedCells[startRow, startCol] = true;

            TraverseMatrix(visited, startRow + 1, startCol);
            TraverseMatrix(visited, startRow - 1, startCol);
            TraverseMatrix(visited, startRow, startCol + 1);
            TraverseMatrix(visited, startRow, startCol - 1);
        }

        public static void Main()
        {
            //uncomment if you want to test with unreachable bottom right end cell
            //matrix[98, 99] = 1;
            //matrix[99, 98] = 1;

            TraverseMatrix(visitedCells, 0, 0);
            Console.WriteLine("Path exists: " + pathExists.ToString().ToUpper());
        }
    }
}
