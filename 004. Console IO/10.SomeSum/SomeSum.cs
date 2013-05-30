using System;

class SomeSum
{
    //Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

    static void Main()
    {
        //solution
        float currentSum = 1;
        int n = 1;
        float previousSum;
        do
        {
            previousSum = currentSum;
            n++;
            if (n % 2 == 0)
            {
                currentSum += (1f / n);
            }
            else
            {
                currentSum -= 1f / n;
            }
        } while (Math.Abs(currentSum - previousSum) > 0.0001);
        
        //output
        Console.WriteLine("The sum of the sequence (with accuracy 0.001): {0:0.000}", currentSum);
    }
}

