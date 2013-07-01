using System;

class MaxIncreasingSequence
{
    // Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.

    static void Main()
    {
        //input 
        int n;
        do
        {
            Console.Write("Please enter the number of elements in the array: ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.WriteLine("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }

        //solution
        int bestCounter = 1;
        int tempCounter = 1;
        int lastElem = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1] + 1)
            {
                tempCounter++;
            }
            if (tempCounter > bestCounter)
            {
                bestCounter = tempCounter;
                lastElem = arr[i];
            }
            if (!(arr[i] == arr[i - 1] + 1))
            {
                tempCounter = 1;
            }
        }

        //output
        lastElem = lastElem - bestCounter + 1;
        Console.Write("{");
        for (int i = 0; i < bestCounter - 1; i++)
        {
            Console.Write("{0}, ", lastElem);
            lastElem++;
        }
        Console.WriteLine(lastElem + "}");
    }
}

