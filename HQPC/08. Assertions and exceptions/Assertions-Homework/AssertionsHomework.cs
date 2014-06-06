using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Empty array in SelectionSort");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Array is empty in BinarySearch");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(0 < arr.Length, "Empty array in FindMinElementIndex");
        Debug.Assert(0 <= startIndex, "startIndex in FindMinElementIndex out of range");
        Debug.Assert(endIndex <= arr.Length, "endIndex in FindMinElementIndex out of range");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (i == minElementIndex)
            {
                continue;
            }

            Debug.Assert(arr[i].CompareTo(arr[minElementIndex]) > 0, "Wrong minIndex in FindMinElementIndex");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
   
    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length >= 0, "Array length must be positive.");
        Debug.Assert(0 <= startIndex, "StartIndex must be positive");
        Debug.Assert(endIndex < arr.Length, "EndIndex must be smaller than array length");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            Debug.Assert(0 <= midIndex, "midIndex out of range");
            Debug.Assert(midIndex <= arr.Length, "midIndex out of range");

            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}
