using System;
using System.Collections.Generic;

class MergeSort
{
    //13* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
    //Complexity: (nlogN)
    /*Conceptually, a merge sort works as follows
1.Divide the unsorted list into n sublists, each containing 1 element (a list of 1 element is considered sorted).
2.Repeatedly merge sublists to produce new sublists until there is only 1 sublist remaining. This will be the sorted list.
*/
    static List<int> MergeSorter(List<int> arr)
    {
        //divide each array into two subarrays
        List<int> left = new List<int>();
        List<int> right = new List<int>();

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
        left = MergeSorter(left);
        right = MergeSorter(right);

        //sort the two arrays and recursively return sorted array to upper calling methods
        return Merged(left, right);
    }

    static List<int> Merged(List<int> left, List<int> right)
    {
        List<int> merged = new List<int>();
        int leftStart = 0;
        int rightStart = 0;
        while (leftStart < left.Count || rightStart < right.Count)
        {
            //merge elements till left or right is done
            if (leftStart < left.Count && rightStart < right.Count)
            {
                if (left[leftStart] <= right[rightStart])
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

    static void Main()
    {
        //input
        Console.Write("Enter the size of the array to be sorted: ");
        int sizeOfArray = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();
        for (int i = 0; i < sizeOfArray; i++)
        {
            Console.Write("Enter element [{0}] of the array: ", i);
            array.Add(int.Parse(Console.ReadLine()));
        }

        //solution and output
        List<int> sortedArr= MergeSorter(array);
        foreach (int element in sortedArr)
        {
            Console.Write("{0}, ", element);
        }

    }
}

