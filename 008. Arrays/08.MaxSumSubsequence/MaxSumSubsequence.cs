using System;

class MaxSumSubsequence
{
    /*Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	Can you do it with only one loop (with single scan through the elements of the array)?
    */
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int maxSum = 0;
        int startIndex = -1;
        int endIndex = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            int tempSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                tempSum += arr[j];
                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                    startIndex = i;
                    endIndex = j;
                }
            }
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.WriteLine("{0} ", arr[i]);
        }
        /* SOLUTION WITH ONLY ONE LOOP USING KADANE'S ALGORITHM 
         int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
         int maxSoFar = arr[0];
         int maxSeqEndingHere = arr[0];
         int start = 0;
         int tempStart = 0;
         int end = 0;

         for (int i = 1; i < arr.Length; i++)
         {
             if (maxSeqEndingHere < 0)
             {
                 maxSeqEndingHere = arr[i];
                 tempStart = i;
             }
             else
             {
                 maxSeqEndingHere += arr[i];
             }

             if (maxSeqEndingHere >= maxSoFar)
             {
                 maxSoFar = maxSeqEndingHere;
                 start = tempStart;
                 end = i;
             }
         }

      //   output
         for (int i = start; i <= end; i++)
         {
             Console.Write("{0} ", arr[i]);
         }
         Console.WriteLine("Sum = {0}", maxSoFar);

         */

    }
}

