namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sortedCollection = MergeSort(collection);
            collection.Clear();
            for (int i = 0; i < sortedCollection.Count; i++)
            {
                collection.Add(sortedCollection[i]);
            }
        }

        private static IList<T> MergeSort(IList<T> arr)
        {
            //divide each array into two subarrays
            List<T> left = new List<T>();
            List<T> right = new List<T>();

            if (arr.Count <= 1)
            {
                return arr;
            }
            else
            {
                int middle = arr.Count / 2;
                for (int i = 0; i < middle; i++)
                {
                    left.Add(arr[i]);
                }
                for (int i = middle; i < arr.Count; i++)
                {
                    right.Add(arr[i]);
                }
            }
            //divide each subarray into two other subarrays recursively
            left = MergeSort(left).ToList();
            right = MergeSort(right).ToList();

            //sort the two arrays and recursively return sorted array to upper calling methods
            return Merged(left, right);
        }

        private static List<T> Merged(List<T> left, List<T> right)
        {
            List<T> merged = new List<T>();
            int leftStart = 0;
            int rightStart = 0;
            while (leftStart < left.Count || rightStart < right.Count)
            {
                //merge elements till left or right is done
                if (leftStart < left.Count && rightStart < right.Count)
                {
                    if (left[leftStart].CompareTo(right[rightStart]) <= 0)
                    {
                        merged.Add(left[leftStart]);
                        leftStart++;
                    }
                    else
                    {
                        merged.Add(right[rightStart]);
                        rightStart++;
                    }
                }
                //add remaining elements
                if ((leftStart == left.Count) && rightStart < right.Count)
                {
                    merged.Add(right[rightStart]);
                    rightStart++;
                }
                if ((rightStart == right.Count) && leftStart < left.Count)
                {
                    merged.Add(left[leftStart]);
                    leftStart++;
                }
            }
            return merged;
        }
    }
}
