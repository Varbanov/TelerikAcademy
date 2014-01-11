using System;

class BinarySearchNum
{
    //Write a program, that reads from the console an array of N integers and an integer K,
    //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

    static void Main()
    {
        //input
        int n, k;
        do
        {
            Console.Write("Please enter \"N\": ");
        } while (!int.TryParse(Console.ReadLine(), out n));

        do
        {
            Console.Write("Please enter \"K\": ");
        } while (!int.TryParse(Console.ReadLine(), out k));

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Please enter integer [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }

        //solution
        Array.Sort(arr);
        int index = Array.BinarySearch(arr, 5);
        if (index < -1)
        {
            Console.WriteLine("The greatest element <= k is {0}", arr[~index - 1]);
        }
        else if (index == -1)
        {
            Console.WriteLine("All numbers in array are greater than K");
        }
        else
            Console.WriteLine("The number is {0}", arr[index]);
    }
}
