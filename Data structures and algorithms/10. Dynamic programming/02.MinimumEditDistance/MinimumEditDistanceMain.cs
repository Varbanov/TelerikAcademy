namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MinimumEditDistanceMain
    {
        public static void Main()
        {
            var firstWord = "developer";
            var secondWord = "enveloped";

            double replace = 1;
            double delete = 0.9;
            double insert = 0.8;

            var n = firstWord.Length;
            var m = secondWord.Length;
            double[,] d = new double[n + 1,  m + 1];
            for (int row = 0; row < n + 1; row++)
            {
                d[row, 0] = delete * row;
            }

            for (int col = 0; col < m + 1; col++)
            {
                d[0, col] = delete * col;
            }


            for (int row = 1; row < n  + 1; row++)
            {
                for (int col = 1; col < m + 1; col++)
                {
                    double del = d[row - 1, col] + delete;
                    double ins = d[row, col - 1] + insert;

                    double rep = firstWord[row - 1] != secondWord[col - 1] ? replace : 0;

                    rep += d[row - 1, col - 1];

                    var min = Math.Min(del, ins);
                    var finalMin = Math.Min(min, rep);

                    d[row, col] = finalMin;

                }
            }

            //for (int i = 0; i < n + 1; i++)
            //{
            //    for (int j = 0; j < m + 1; j++)
            //    {
            //        Console.Write("{0, 5}", d[i, j]);
            //    }

            //    Console.WriteLine();
            //}

            Console.WriteLine("Minimum edit distance: " + d[n,m]);
        }
    }
}
