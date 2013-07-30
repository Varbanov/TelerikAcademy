using System;

class CompareWithNeighboursClass
{
    //Write a method that checks if the element at given position in given array 
    //of integers is bigger than its two neighbors (when such exist).
    static bool CompareWithNeighbours(int[] arr, int index)
    {
        //if two neighbours
        if (index > 0 && index < arr.Length - 1)
        {
            if (arr[index] > arr[index + 1] && arr[index] > arr[index - 1])
            {
                return true;
            }
        }
            //if only next neighbour
        else if (index == 0)
        {
            if (arr[index] > arr[index + 1])
            {
                return true;
            }
        }
            //if only previous neighbour
        else 
        {
            if (arr[index] > arr[index - 1])
            {
                return true;
            }
        }
        return false;
    }

    static void Main()
    {
        int[] arr = { 0, 1, 2, 3, 4, 4, 3 };
        bool result = CompareWithNeighbours(arr, 4);
        Console.WriteLine(result);
    }
}
