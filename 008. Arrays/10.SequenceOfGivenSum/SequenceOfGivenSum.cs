using System;

class SequenceOfGivenSum
{
    //Write a program that finds in given array of integers a sequence of given sum S (if present). 
    //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
    static void Main()
    {
        //input
        int[] arr = {11, 4, 3, 1, 4, 2, 5, 7, 4};
        int s = 11;
        //solution
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int tempSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                tempSum += arr[j];
                if (tempSum == s)
                {
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write("{0} ", arr[k]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

