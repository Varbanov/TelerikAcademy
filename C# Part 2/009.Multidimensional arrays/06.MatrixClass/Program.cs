using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //initialize two instances of class Matrix
        Matrix matr1 = new Matrix(2, 3);
        Matrix matr2 = new Matrix(2, 3);
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                matr1[row, col] = col + 1;
                matr2[row, col] = row + 1;
            }
        }

        //output
        Console.WriteLine("Mattrix 1:");
        Console.WriteLine(matr1.ToString());
        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matr2.ToString());
        //output sum
        Console.WriteLine("Sum:");
        Matrix sum = matr1 + matr2;
        Console.WriteLine(sum.ToString());
        //output multiplying
        Matrix mult = matr1 * matr2;
        Console.WriteLine("Matrix 1 * Matrix 2:");
        Console.WriteLine(mult.ToString());
        //output substraction
        Matrix substr = matr1 - matr2;
        Console.WriteLine("Matrix 1 - Matrix 2");
        Console.WriteLine(substr.ToString());
    }
}
