using System;

    class Program
    {
        static void Main()
        {

           // Matrix.GetFilledMatrix(3);

            var matrix  = Matrix.GetFilledMatrix(4);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
