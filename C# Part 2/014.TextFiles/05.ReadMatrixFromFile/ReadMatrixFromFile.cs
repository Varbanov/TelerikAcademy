using System;
using System.Text;
using System.IO;

class ReadMatrixFromFile
{
    //Write a program that reads a text file containing a square matrix of numbers and finds in
    //the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file
    //contains the size of matrix N. Each of the next N lines contain N numbers separated by space. 
    //The output should be a single number in a separate text file. Example:
    /*
     * 4
     * 2 3 3 4
     * 0 2 3 4      Result: 17
     * 3 7 1 2
     * 4 3 3 2
     * */

    static int[,] ParseMatrixFromFile(StreamReader reader)
    {
        using (reader)
        {
            //read n and initialize output matrix
            string currLine = reader.ReadLine();
            int n = int.Parse(currLine.Trim());
            int[,] matrix = new int[n, n];

            //fill in the output matrix
            for (int row = 0; row < n; row++)
            {
                currLine = reader.ReadLine();
                string[] splitedNums = currLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(splitedNums[col]);
                }
            }
            return matrix;
        }
    }

    private static int FindMax2x2InSquareMatrix(int[,] matrix)
    {
        int rightmostStart = matrix.GetLength(0) - 1;
        int downmostStart = matrix.GetLength(1) - 1;
        int maxSum = int.MinValue;

        for (int row = 0; row < downmostStart; row++)
        {
            for (int col = 0; col < rightmostStart; col++)
            {
                int sum = 0;
                //obtain the sum of the current 2x2 square
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        sum += matrix[row + i, col + j];
                    }
                }
                //save sum if better
                if (sum >= maxSum)
                {
                    maxSum = sum;
                }
            }
        }
        return maxSum;
    }

    static void Main()
    {
        //input (in the main folder of the current project)
        StreamReader reader = new StreamReader(@"..\..\input.txt");
        int[,] matrix = ParseMatrixFromFile(reader);

        //solution
        int maxSum = FindMax2x2InSquareMatrix(matrix);

        //output (in the main folder of the current project)
        StreamWriter writer = new StreamWriter(@"..\..\output.txt");
        using (writer)
        {
            writer.Write(maxSum.ToString());
        }
    }

}

