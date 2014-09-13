namespace _01.KnapsackProblem
{
    using System;

    public class KnapsackProblemMain
    {
        public static void Main()
        {
            int n = 6;
            int volume = 10;

            Product[] products = new Product[] {
                                  new Product("beer", 3, 2),
                                  new Product("vodka", 8, 12),
                                  new Product("cheese", 4, 5),
                                  new Product("nuts", 1, 4),
                                  new Product("ham", 2, 3),
                                  new Product("whiskey", 8, 13),
                             };

            //initialize solution matrix
            //rows - knapsack volumes from 0 to volume; cols - products from 0 to the last product
            int[,] solution = new int[n + 1, volume + 1];
            int[,] backtracking = new int[n + 1, volume + 1];

            //fill matrix
            for (int row = 1; row < solution.GetLength(0); row++)
            {
                var currentProductWeight = products[row - 1].Weight;
                var currentProductCost = products[row - 1].Cost;
                for (int col = 1; col < solution.GetLength(1); col++)
                {
                    var valuewWithoutCurrent = solution[row - 1, col];
                    var valueWithCurrent = 0;
                    if (col - currentProductWeight >= 0)
                    {
                        valueWithCurrent = solution[row - 1, col - currentProductWeight] + currentProductCost;
                    }

                    if (valueWithCurrent >= valuewWithoutCurrent)
                    {
                        solution[row, col] = valueWithCurrent;
                        backtracking[row, col] = col - currentProductWeight;
                    }
                    else
                    {
                        solution[row, col] = valuewWithoutCurrent;
                    }
                }
            }

            PrintSolution(solution, backtracking, products);
        }

        private static void PrintSolution(int[,] solution, int[,] backtracking, Product[] products)
        {
            for (int i = 0; i < solution.GetLength(0); i++)
            {
                for (int j = 0; j < solution.GetLength(1); j++)
                {
                    Console.Write("{0, 2} ", solution[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------");

            int maxCost = 0;
            int rowIndex = 0;
            int lastCol = solution.GetLength(1) - 1;
            int lastRow = solution.GetLength(0) - 1;

            for (int row = 0; row < solution.GetLength(0); row++)
            {
                if (solution[row, lastCol] > maxCost)
                {
                    maxCost = solution[row, lastCol];
                    rowIndex = row;
                }
            }

            Console.WriteLine("Max cost: " + maxCost);

            int colIndex = lastCol;

            for (int row = rowIndex; row > 0; row--)
            {
                if (solution[row, colIndex] != solution[row - 1, colIndex])
                {
                    Console.WriteLine(products[row - 1].Name);
                    colIndex = backtracking[row, colIndex];
                }
            }

            Console.WriteLine("----------------------------------------");
        }
    }
}
