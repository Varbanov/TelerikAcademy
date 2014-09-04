namespace _14.MinimalDistancesInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        private int[,] Data { get; set; }

        public Labyrinth(int[,] inputData)
        {
            this.Data = inputData;
        }

        public void PrintStringifiedPathData(int startRow, int startCol)
        {
            var paths = this.CalculatePathsLength(startRow, startCol);

            string unreachable = "U";
            string full = "X";

            for (int row = 0; row < paths.GetLength(0); row++)
            {
                for (int col = 0; col < paths.GetLength(1); col++)
                {
                    var currentCell = paths[row, col];
                    if (currentCell < 0)
                    {
                        Console.Write("{0}, ", full);
                    }
                    else if (row != startRow && col != startCol && currentCell == 0)
                    {
                        Console.Write("{0}, ", unreachable);
                    }
                    else
                    {
                        Console.Write("{0}, ", currentCell);
                    }

                }

                Console.WriteLine();
            }
        }

        private int[,] CalculatePathsLength(int startRow, int startCol)
        {
            if (!ValidateRowAndCol(startRow, startCol))
            {
                throw new ArgumentOutOfRangeException("Invalid row or col!");
            }

            int[,] result = GetInitialResultMatrix();
            bool[,] isVisited = new bool[result.GetLength(0), result.GetLength(1)];
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(0, startRow, startCol));

            int currentRow;
            int currentCol;

            while (queue.Count > 0)
            {
                var root = queue.Dequeue();
                currentRow = root.Item2;
                currentCol = root.Item3;

                isVisited[currentRow, currentCol] = true;
                if (Data[currentRow, currentCol] < 0)
                {
                    result[currentRow, currentCol] = -1;
                    continue;
                }

                int newValue = root.Item1 + 1;
                int upperRow = root.Item2 - 1;
                int lowerRow = root.Item2 + 1;
                int leftCol = root.Item3 - 1;
                int rightCol = root.Item3 + 1;

                //upper
                if (upperRow >= 0 && !(isVisited[upperRow, currentCol]))
                {
                    queue.Enqueue(new Tuple<int, int, int>(newValue, upperRow, currentCol));
                    result[upperRow, currentCol] = newValue;
                    isVisited[upperRow, currentCol] = true;
                }

                //lower
                if (lowerRow < result.GetLength(0) && !(isVisited[lowerRow, currentCol]))
                {
                    queue.Enqueue(new Tuple<int, int, int>(newValue, lowerRow, currentCol));
                    result[lowerRow, currentCol] = newValue;
                    isVisited[lowerRow, currentCol] = true;
                }

                //left
                if (leftCol >= 0 && !(isVisited[currentRow, leftCol]))
                {
                    queue.Enqueue(new Tuple<int, int, int>(newValue, currentRow, leftCol));
                    result[currentRow, leftCol] = newValue;
                    isVisited[currentRow, leftCol] = true;
                }

                //right
                if (rightCol < result.GetLength(1) && !(isVisited[currentRow, rightCol]))
                {
                    queue.Enqueue(new Tuple<int, int, int>(newValue, currentRow, rightCol));
                    result[currentRow, rightCol] = newValue;
                    isVisited[currentRow, rightCol] = true;
                }
            }

            return result;
        }

        private int[,] GetInitialResultMatrix()
        {
            int rows = this.Data.GetLength(0);
            int cols = this.Data.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (this.Data[row, col] < 0)
                    {
                        result[row, col] = -1;
                    }
                }
            }
            return result;
        }

        private bool ValidateRowAndCol(int startRow, int startCol)
        {
            if (startRow < 0 || startRow > this.Data.GetLength(0))
            {
                return false;
            }
            else if (startCol < 0 || startCol > this.Data.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
