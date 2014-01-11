using System;
using System.Collections.Generic;

class RemoveElementsToSortArray
{
    /** Write a program that reads an array of integers and removes from it a minimal
     * number of elements in such way that the remaining array is sorted in increasing
     * order. Print the remaining sorted array.
     * Example: {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
    */

    static bool IsSorted(List<int> indexes, int[] arr)
    {
        //a method to check if the array we have found is sorted
        bool isSorted = true;
        List<int> resultArray = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (indexes.Contains(i))
            {
                continue;
            }
            resultArray.Add(arr[i]);
        }
        for (int i = 0; i < resultArray.Count - 1; i++)
        {
            if (resultArray[i + 1] < resultArray[i])
            {
                isSorted = false;
                break;
            }
        }
        return isSorted;
    }

    static void Main()
    {
        //input
        int n;
        do
        {
            Console.Write("Please enter \"N\" [N > 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }

        //solution using bitwise iterations from 1 to Math.Pow(2, n) - 1 to check each possible combination
        int minCount = int.MaxValue;
        List<int> bestList = new List<int>();
        int max = (int)Math.Pow(2, n) - 1;
        List<int> li = new List<int>();
        for (int i = 1; i <= max; i++)
        {
            li.Clear();
            for (int bitPosition = 0; bitPosition < n; bitPosition++)
            {
                int currBit = 1 & (i >> bitPosition);
                if (currBit == 1)
                {
                    li.Add(bitPosition);
                }
            }

            if (IsSorted(li, arr))
            {
                if (li.Count <= minCount)
                {
                    bestList.Clear();
                    minCount = li.Count;
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (li.Contains(j))
                        {
                            continue;
                        }
                        bestList.Add(arr[j]);
                    }
                }
            }
        }

        Console.WriteLine("Your result is:");
        foreach (var item in bestList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

    }
}
