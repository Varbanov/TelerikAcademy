using System;

class FindIndexOfBiggerThanNeighb
{
    //Write a method that returns the index of the first element in array that is bigger than its neighbors,
    //or -1, if there’s no such element.
    //Use the method from the previous exercise.
    static int FirstBiggerThanNeighbours(int[] arr)
    {
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (CompareWithNeighbours(arr, i))
            {
                index = i;
                return index;
            }
        }

        return index;
    }

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
        int[] arr = { 0, 1, 2, 3, 4, 5 };
        Console.WriteLine(FirstBiggerThanNeighbours(arr));
    }
}

