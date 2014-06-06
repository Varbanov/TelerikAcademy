using System;
using System.Collections.Generic;
using System.Diagnostics;

class QuickSort
{
    private static void SwapElements<T>(ref T first, ref T second)
    {
        dynamic temp = first;
        first = second;
        second = temp;
    }

    private static int Partition<T>(T[] arr, int left, int right, int pivotIndex)
        where T: IComparable, IComparable<T>
    {
        dynamic pivotValue = arr[pivotIndex];
        SwapElements(ref arr[pivotIndex], ref arr[right]);
        int storeIndex = left;
        for (int i = left; i < right; i++)
        {
            if (arr[i].CompareTo(pivotValue) <= 0)
            {
                SwapElements(ref arr[i], ref arr[storeIndex]);
                storeIndex++;
            }
        }
        SwapElements(ref arr[storeIndex], ref arr[right]);
        return storeIndex;
    }

    private static void QuickSorterInt(int[] arr, int left, int right)
    {
        if (left < right)
        {
            Random random = new Random();
            int pivotIndex = random.Next(left, right);
            int pivotNewIndex = Partition(arr, left, right, pivotIndex);

            QuickSorterInt(arr, left, pivotNewIndex - 1);
            QuickSorterInt(arr, pivotNewIndex + 1, right);
        }
    }

    private static void QuickSorterDouble(double[] arr, int left, int right)
    {
        if (left < right)
        {
            Random random = new Random();
            int pivotIndex = random.Next(left, right);
            int pivotNewIndex = Partition(arr, left, right, pivotIndex);

            QuickSorterDouble(arr, left, pivotNewIndex - 1);
            QuickSorterDouble(arr, pivotNewIndex + 1, right);
        }
    }

    private static void QuickSorterString(string[] arr, int left, int right)
    {
        if (left < right)
        {
            Random random = new Random();
            int pivotIndex = random.Next(left, right);
            int pivotNewIndex = Partition(arr, left, right, pivotIndex);

            QuickSorterString(arr, left, pivotNewIndex - 1);
            QuickSorterString(arr, pivotNewIndex + 1, right);
        }
    }

    public static void RunQuickSortStringPerformance(string[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        QuickSorterString(array, 0, array.Length - 1);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Quick sort String");

        ////print array
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.Write("{0} ", array[i]);
        //}
    }


    public static void RunQuickSortDoublePerformance(double[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        QuickSorterDouble(array, 0, array.Length - 1);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Quick sort Double");

        ////print array
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.Write("{0} ", array[i]);
        //}
    }

    public static void RunQuickSortIntPerformance(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        QuickSorterInt(array, 0, array.Length - 1);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Quick sort Int");

        ////print array
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.Write("{0} ", array[i]);
        //}
    }
}

