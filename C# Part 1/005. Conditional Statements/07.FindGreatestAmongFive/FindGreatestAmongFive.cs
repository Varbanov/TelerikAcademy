using System;

class FindGreatestAmongFive
{
    //Write a program that finds the greatest of given 5 variables.
    static void Main()
    {
        //data input
        float[] var = new float[5];
        for (int i = 0; i < 5; i++)
        {
            do
            {
                Console.Write("Please enter variable {0}: ", i + 1);
            } while (!float.TryParse(Console.ReadLine(), out var[i]));
            Console.WriteLine();
        }
        //solution
        float greatest = float.MinValue;
        for (int i = 0; i < var.Length; i++)
        {
            if (var[i] >= greatest)
            {
                greatest = var[i];
            }
        }
        //output
        Console.WriteLine("The greatest number is: {0}", greatest);
    }
}
