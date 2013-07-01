using System;

class MaxSequeEqualElems
{
    /*Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
    */
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
                Console.Write("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }

        //solution
        int bestElement = 0;
        int bestCounter = 1;
        int tempCounter = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                tempCounter++;
            }
            if (tempCounter >= bestCounter)
            {
                bestCounter = tempCounter;
                bestElement = arr[i - 1];
            }
            if (!(arr[i] == arr[i - 1]))
            {
                tempCounter = 1;
            }
        }

        //output
        Console.Write("{");
        for (int i = 0; i < bestCounter - 1; i++)
        {
            Console.Write("{0}, ", bestElement);
        }
        Console.WriteLine(bestElement + "}");
    }
}

