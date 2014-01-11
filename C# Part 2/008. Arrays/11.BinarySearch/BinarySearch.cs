using System;

class BinarySearch
{
    //Write a program that finds the index of given element in a sorted array
    //of integers by using the binary search algorithm (find it in Wikipedia).

    static int BinSearch(int elem, int[] arr, int startIndex, int endIndex)
    {
        int index = endIndex - (endIndex - startIndex) / 2;
        if (startIndex > endIndex)
        {
            return -1;
        }
        else 
        {
            if (elem > arr[index])
            {
                return BinSearch(elem, arr, index + 1, endIndex);
            }
            else if (elem < arr[index])
            {
                return BinSearch(elem, arr, startIndex, index - 1);
            }
            else return index;
        }
    }

    static void Main()
    {
        //input
        //initialize sorted test array with elements {0, 1, ..., 20} and a test element to search for
        int elem = 4;
        int[] arr = new int[21];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        //solution
        int index = BinSearch(elem, arr, 0, arr.Length - 1);

        //output
        if (index >= 0)
        {
            Console.WriteLine("Index: {0} \nElement: {1}", index, arr[index]);
        }
        else
        {
            Console.WriteLine("The array does not contain the element requested! Index: {0}", index);
        }
    }
}

