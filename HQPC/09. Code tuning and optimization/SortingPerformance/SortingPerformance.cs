using System;

class SortingPerformance
{
    static void SwapElements(ref int n1, ref int n2)
    {
        int temp = n1;
        n1 = n2;
        n2 = temp;
    }

    static void FindSmallest(ref int[] arr, int start)
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

    static void Main()
    {
        var ARRAY_LENGTH = 3000;
        Random random = new Random();

        int[] arrInt1 = new int[ARRAY_LENGTH];
        int[] arrInt2 = new int[ARRAY_LENGTH];
        int[] arrInt3 = new int[ARRAY_LENGTH];

        double[] arrDouble1 = new double[ARRAY_LENGTH];
        double[] arrDouble2 = new double[ARRAY_LENGTH];
        double[] arrDouble3 = new double[ARRAY_LENGTH];

        string[] arrString1 = new string[ARRAY_LENGTH];
        string[] arrString2 = new string[ARRAY_LENGTH];
        string[] arrString3 = new string[ARRAY_LENGTH];

        for (int i = 0; i < ARRAY_LENGTH; i++)
        {
            arrInt1[i] = random.Next(0, 1000);
            arrInt2[i] = arrInt1[i];
            arrInt3[i] = arrInt2[i];

            arrDouble1[i] = arrInt1[i];
            arrDouble2[i] = arrInt1[i];
            arrDouble3[i] = arrInt1[i];

            arrString1[i] = ((char)random.Next(65, 91)).ToString();
            arrString1[i] += ((char)random.Next(65, 91)).ToString();
            arrString1[i] += ((char)random.Next(65, 91)).ToString();
            arrString2[i] = arrString1[i];
            arrString3[i] = arrString1[i];
        }

        SelectionSort.RunSelectionSortIntPerformance(ARRAY_LENGTH, ref arrInt1);
        SelectionSort.RunSelectionSortDoublePerformance(ARRAY_LENGTH, ref arrDouble1);
        SelectionSort.RunSelectionSortStringPerformance(ARRAY_LENGTH, ref arrString1);

        QuickSort.RunQuickSortIntPerformance(arrInt2);
        QuickSort.RunQuickSortDoublePerformance(arrDouble2);
        QuickSort.RunQuickSortStringPerformance(arrString2);

        InsertionSort.RunInsertionSortIntPerformance(ref arrInt3);
        InsertionSort.RunInsertionSortDoublePerformance(ref arrDouble3);
        InsertionSort.RunInsertionSortStringPerformance(ref arrString3);
    }
}

