using System;

class MatrixOfNums
{
    //Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
    // 1234
    // 2345
    // 3456
    // 4567
    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter \"N\" [1..19]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 19);
        
        //solution
        for (int rows = 0; rows < n; rows++)
        {
            int counter = rows + 1;
            for (int cols = 0; cols < n; cols++)
            {
                Console.Write("{0} ", counter.ToString().PadLeft(3));
                counter++;
            }
            Console.WriteLine();
        }
    }
}

