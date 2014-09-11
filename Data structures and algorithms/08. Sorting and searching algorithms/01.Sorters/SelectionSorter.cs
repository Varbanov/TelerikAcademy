namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private static void SwapElements(IList<T> arr, int start, int smallestIndex)
        {
            T temp = arr[start];
            arr[start] = arr[smallestIndex];
            arr[smallestIndex] = temp;
        }

        public void Sort(IList<T> arr)
        {
            int minIndex;
            for (int i = 0; i < arr.Count; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[j].CompareTo(arr[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    SwapElements(arr, minIndex, i);
                }
            }
        }
    }
}
