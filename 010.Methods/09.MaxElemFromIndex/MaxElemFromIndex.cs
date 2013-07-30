using System;

class MaxElemFromIndex
{
    //Write a method that return the maximal element in a portion of array of integers starting
    //at given index. Using it write another method that sorts an array in ascending / descending order.
    static int FindMaxElemPosFromIndex(int[] arr, int startIndex)
    {
        int maxElement = int.MinValue;
        int maxIndex = -1;
        for (int i = startIndex; i < arr.Length; i++)
        {
            if (arr[i] > maxElement)
            {
                maxElement = arr[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    static void SortArrayDescending(ref int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int tempMaxIndex = FindMaxElemPosFromIndex(arr, i);
            int temp = arr[i];
            arr[i] = arr[tempMaxIndex];
            arr[tempMaxIndex] = temp;
        }
    }

    static void SortArrayAscending(ref int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int tempMaxIndex = FindMaxElemPosFromIndex(arr, i);
            int temp = arr[i];
            arr[i] = arr[tempMaxIndex];
            arr[tempMaxIndex] = temp;
        }
        //reverse arr so that it is sorted ascending
        int[] reversed = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            reversed[i] = arr[i];
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = reversed[arr.Length - 1 - i];
        }
    }

    static void Main()
    {
        //test method for finding max elem from start
        int[] arr = { 6,3,4,4,2,0 };
        int max = FindMaxElemPosFromIndex(arr, 3);
        Console.WriteLine("Max: {0}", arr[max]);

        //test descending
        SortArrayDescending(ref arr);
        Console.WriteLine("Descending:");
        foreach (var item in arr)
        {
            Console.Write(" {0}", item);
        }
        Console.WriteLine();

        //test ascending
        SortArrayAscending(ref arr);
        Console.WriteLine("Ascending:");
        foreach (var item in arr)
        {
            Console.Write(" {0}", item);
        }
        Console.WriteLine();
    }
}
