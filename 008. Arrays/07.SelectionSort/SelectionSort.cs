using System;

class SelectionSort
{
    /*Sorting an array means to arrange its elements in increasing order. Write a program to
     * sort an array. Use the "selection sort" algorithm: Find the smallest element, move it 
     * at the first position, find the smallest from the rest, move it at the second position, etc.
    */

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
        //data input
        int n;
        do
        {
            Console.Write("Please enter the number of elements in the array: ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }
        //solution
        int smallestIndex = -1;
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
            SwapElements(ref arr[i], ref arr[smallestIndex]);
        }
        //output
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
        ////interesting solution using resursion
        //FindSmallest(ref arr, 0);
        ////print sorted array
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.Write("{0} ", arr[i]);
        //}
    }
}

