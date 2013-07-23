using System;

class Variations
{
    //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
    //Example: N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
    static void PrintAllElements(int[] arr)
    {
        //a method to print all elements of an array
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void GenerateVariations(int k, int n, int[] arr)
    {
        if (k == -1)
        {
            //if the index of current element is -1, i.e. we have filled in all elements 0..k-1 of the array with current variation values
            PrintAllElements(arr);
        }
        else
        {
            //recursively simulate k nested loops from 1 to n;
            for (int num = 1; num <= n; num++)
            {
                arr[k] = num;
                GenerateVariations(k - 1, n, arr);
            }
        }
    }

    static void Main()
    {
        //data input
        int n, k;
        do
        {
            Console.Write("Please enter \"N\" [> 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

        do
        {
            Console.Write("Please enter \"K\": ");
        } while (!int.TryParse(Console.ReadLine(), out k));

        //solution
        int[] arr = new int[k];
        Console.WriteLine("Variations:");
        GenerateVariations(k - 1, n, arr);
    }
}

