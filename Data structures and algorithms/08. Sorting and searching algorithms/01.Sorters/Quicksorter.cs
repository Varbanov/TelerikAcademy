namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private static void SwapElements(IList<T> arr, int firstIndex, int secondIndex)
        {
            T temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        private static int Partition(IList<T> arr, int left, int right, int pivotIndex)
        {
            T pivotValue = arr[pivotIndex];
            SwapElements(arr, pivotIndex, right);
            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i].CompareTo(pivotValue) <= 0)
                {
                    SwapElements(arr, i, storeIndex);
                    storeIndex++;
                }
            }

            SwapElements(arr, storeIndex, right);
            return storeIndex;
        }

        private static void QuickSort(IList<T> arr, int left, int right)
        {
            if (left < right)
            {
                Random random = new Random();
                int pivotIndex = random.Next(left, right);
                int pivotNewIndex = Partition(arr, left, right, pivotIndex);

                QuickSort(arr, left, pivotNewIndex - 1);
                QuickSort(arr, pivotNewIndex + 1, right);
            }
        }
    }
}
