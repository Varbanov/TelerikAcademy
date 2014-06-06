using System;
using System.Diagnostics;

class SelectionSort
{
    private static void SwapElements<T>(ref T n1, ref T n2)
    {
        dynamic temp = n1;
        n1 = n2;
        n2 = temp;
    }

    private static void FindSmallest(ref int[] arr, int start)
    {
        int smallest = int.MaxValue;
        int smallestIndex = -1;
        if (start == arr.Length - 1)
        {
            return;
        }
        else
        {
            for (int i = start; i < arr.Length; i++)
            {
                if (arr[i] <= smallest)
                {
                    smallest = arr[i];
                    smallestIndex = i;
                }
            }
            SwapElements(ref arr[start], ref arr[smallestIndex]);
            FindSmallest(ref arr, start + 1);
        }
    }

    public static void RunSelectionSortIntPerformance(int arrayLength, ref int[] arr)
    {
        Stopwatch stopwatch = new Stopwatch();

        ////initialize
        //int[] arr = new int[arrayLength];
        //Random random = new Random();

        //for (int i = 0; i < arrayLength; i++)
        //{
        //    arr[i] = random.Next(0, 1000);
        //}

        //solution
        int smallestIndex = -1;
        stopwatch.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int smallest = int.MaxValue;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] <= smallest)
                {
                    smallest = arr[j];
                    smallestIndex = j;
                }
            }
            SwapElements<int>(ref arr[i], ref arr[smallestIndex]);
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Selection sort Int");

        ////array output
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }

    public static void RunSelectionSortDoublePerformance(int arrayLength, ref double[] arr)
    {
        var ARRAY_LENGTH = arrayLength;
        Stopwatch stopwatch = new Stopwatch();

        //solution
        int smallestIndex = -1;
        stopwatch.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            double smallest = int.MaxValue;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] <= smallest)
                {
                    smallest = arr[j];
                    smallestIndex = j;
                }
            }

            SwapElements<double>(ref arr[i], ref arr[smallestIndex]);
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Selection sort Double");

        ////array output
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }

    public static void RunSelectionSortStringPerformance(int arrayLength, ref string[] arr)
    {
        var ARRAY_LENGTH = arrayLength;
        Stopwatch stopwatch = new Stopwatch();


        //solution
        int smallestIndex = -1;
        stopwatch.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            string smallest = arr[i];
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(smallest) <= 0)
                {
                    smallest = arr[j];
                    smallestIndex = j;
                }
            }

            SwapElements<string>(ref arr[i], ref arr[smallestIndex]);
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + " Selection sort String");

        ////array output
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }






}

