using System;

class MaxKSum
{
    //Write a program that reads two integer numbers N and K and an array of N elements from the
    //console. Find in the array those K elements that have maximal sum.

    static void Main()
    {
        //input
        int k;
        do
        {
            Console.Write("Please enter \"k\": ");
        } while (!int.TryParse(Console.ReadLine(), out k));

        int n;
        do
        {
            Console.Write("Please enter \"n\": ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));

        }

        //solution for k CONSECUTIVE elements, as written in the book
        int bestSum = 0;
        int bestLastIndex;
        int tempSum = 0;
        for (int i = 0; i < k; i++)
        {
            tempSum += arr[i];
        }
        bestSum = tempSum;
        bestLastIndex = k - 1;
        
        for (int i = k; i < n; i++)
        {
            tempSum += arr[i];
            tempSum -= arr[i - k];
            if (tempSum >= bestSum)
            {
                bestSum = tempSum;
                bestLastIndex = i;
            }
        }

        //output
        Console.WriteLine();
        Console.WriteLine("SOLUTION FOR K CONSECUTIVE ELEMENTS:");
        int min = bestLastIndex - k + 1;
        Console.Write("Biggest sum: {0} \nElements: ", bestSum);
        Console.Write("{");
        for (int i = min; i < bestLastIndex; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine(arr[bestLastIndex] + "}");

        //solution for k RANDOM elements, as writen in the presentation
        Console.WriteLine();
        Console.WriteLine("SOLUTION FOR K RANDOM ELEMENTS:");
        Array.Sort(arr);
        int sum = 0;
        int leftmost = arr.Length - k;
        Console.Write("Elements: {");
        for (int i = arr.Length - 1; i > leftmost; i--)
        {
            sum += arr[i];
            Console.Write("{0}, ", arr[i]);
        }
        sum += arr[leftmost];
        Console.WriteLine(arr[leftmost] + "}");
        Console.WriteLine("Biggest sum: {0}", sum);

    }
}

