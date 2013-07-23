using System;
using System.Collections.Generic;
class MostFrequentNumber
{
    //Write a program that finds the most frequent number in an array. Example:
	//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        //solution
        Dictionary<int, int> dict = new Dictionary<int,int>();
        int tempMaxCounter = 1;
        int tempBestNum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (dict.ContainsKey(arr[i]))
            {
                dict[arr[i]]++;
                if (dict[arr[i]] >= tempMaxCounter)
                {
                    tempMaxCounter = dict[arr[i]];
                    tempBestNum = arr[i];
                }
            }
            else
            {
                dict.Add(arr[i], 1);
            }
        }

        Console.WriteLine("Result: {0} ({1} times)", tempBestNum, tempMaxCounter);
        /*solution without using Dictionary 
        int[] arr = {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3};
        int[] counter = new int[arr.Length];
        int maxCounter = 0;
        int maxIndex = -1;
        
        for (int i = 0; i < arr.Length - 1; i++)
        {
            counter[i] = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] == arr[i])
                    counter[i]++;
            }

            if (counter[i] > maxCounter)
            {
                maxCounter = counter[i];
                maxIndex = i;
            }
        }
        Console.WriteLine("Result: {0} ({1} times)", arr[maxIndex], maxCounter);
        */
    }
}

