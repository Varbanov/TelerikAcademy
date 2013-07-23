using System;
using System.Collections.Generic;

class QuickSort
{
    //14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

    //Complexity (n*n), usually (nlogN)
    /*The steps are:
      1.Pick an element, called a pivot, from the list.
      2.Reorder the list so that all elements with values less than the pivot come before the pivot, while all elements
      with values greater than the pivot come after it (equal values can go either way). After this partitioning, the 
      pivot is in its final position. This is called the partition operation.
      3.Recursively apply the above steps to the sub-list of elements with smaller values and separately the sub-list of elements with greater values.
      */

    static void SwapElements(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }

    static int Partition(int[] arr, int left, int right, int pivotIndex)
    {
        int pivotValue = arr[pivotIndex];
        SwapElements(ref arr[pivotIndex], ref arr[right]);
        int storeIndex = left;
        for (int i = left; i < right; i++)
		{
			if (arr[i] <= pivotValue)
            {
                SwapElements(ref arr[i], ref arr[storeIndex]);
                storeIndex++;
            }
		}
        SwapElements(ref arr[storeIndex], ref arr[right]);
        return storeIndex;
        /*// left is the index of the leftmost element of the subarray
   // right is the index of the rightmost element of the subarray (inclusive)
   //   number of elements in subarray = right-left+1
         * 
   function partition(array, left, right, pivotIndex)
      pivotValue := array[pivotIndex]
      swap array[pivotIndex] and array[right]  // Move pivot to end
      storeIndex := left
      for i from left to right - 1  // left ≤ i < right
          if array[i] <= pivotValue
              swap array[i] and array[storeIndex]
              storeIndex := storeIndex + 1
      swap array[storeIndex] and array[right]  // Move pivot to its final place
      return storeIndex
*/
    }

    static void QuickSorter(int[] arr, int left, int right)
    {
        if (left < right)
        {
            Random random = new Random();
            int pivotIndex = random.Next(left, right);
            int pivotNewIndex = Partition(arr, left, right, pivotIndex);

            QuickSorter(arr, left, pivotNewIndex - 1);
            QuickSorter(arr, pivotNewIndex + 1, right);
        }

        /*function quicksort(array, left, right)
 
      // If the list has 2 or more items
      if left < right
 
          // See "Choice of pivot" section below for possible choices
          choose any pivotIndex such that left ≤ pivotIndex ≤ right
 
          // Get lists of bigger and smaller items and final position of pivot
          pivotNewIndex := partition(array, left, right, pivotIndex)
 
          // Recursively sort elements smaller than the pivot
          quicksort(array, left, pivotNewIndex - 1)
 
          // Recursively sort elements at least as big as the pivot
          quicksort(array, pivotNewIndex + 1, right)
*/
    }

    static void Main()
    {
        //input
        int[] arr = { 0, 5, 1, 4, -3, 10, 11, 9, 6, 2, 1 };

        //solution and output
        QuickSorter(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
    }
}

