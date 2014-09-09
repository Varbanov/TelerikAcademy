using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindAllPathsInMatrix
{
    public class FindAllPaths
    {
        // 1 means non-passable cell and 0 means passable cell
        static int[,] matrix = new int[,]
            {
                { 0, 0, 1, 1, 0},
                { 1, 0, 0, 0, 0},
                { 1, 0, 1, 0, 0},
                { 1, 0, 0, 0, 0},
                { 1, 1, 1, 1, 1},
            };

        static bool[,] visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        static int paths = 0;
        static int endRow = 3;
        static int endCol = 1;


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
                paths++;
                return;
            }

            visitedCells[startRow, startCol] = true;

            TraverseMatrix(visited, startRow + 1, startCol);
            TraverseMatrix(visited, startRow - 1, startCol);
            TraverseMatrix(visited, startRow, startCol + 1);
            TraverseMatrix(visited, startRow, startCol - 1);

            visitedCells[startRow, startCol] = false;
        }

        public static void Main()
        {
            TraverseMatrix(visitedCells, 0, 0);
            Console.WriteLine("Paths: "  + paths);
        }
    }
}
