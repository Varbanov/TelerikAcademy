using System;
using System.Diagnostics;

public class InsertionSort
{
    private static void SwapElements<T>(ref T first, ref T second)
    {
        dynamic temp = first;
        first = second;
        second = temp;
    }

    public static void RunInsertionSortStringPerformance(ref string[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j - 1].CompareTo(arr[j]) > 0)
            {
                SwapElements<string>(ref arr[j], ref arr[j - 1]);
                j--;
            }
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Insertion Sort String");

        //// print array
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }

    public static void RunInsertionSortDoublePerformance(ref double[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j - 1] > arr[j])
            {
                SwapElements<double>(ref arr[j], ref arr[j - 1]);
                j--;
            }
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Insertion Sort Double");

        //// print array
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }

    public static void RunInsertionSortIntPerformance(ref int[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i;
            while (j > 0 && arr[j - 1] > arr[j])
            {
                SwapElements<int>(ref arr[j], ref arr[j - 1]);
                j--;
            }
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Insertion Sort Int");

        //// print array
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }
}

