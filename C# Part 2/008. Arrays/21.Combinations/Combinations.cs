using System;

class Combinations
{
    //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
    //Example: N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
    static void PrintAllElements(int[] arr)
    {
        //a method to print all elements of an array
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void GenerateCombinations(int k, int n, int[] arr, int next = 1)
    {
        //recursive method to generate k nested loops from 1 to n
        if (k == -1)
        {
            //if we fill in all current combination elements from last to first element
            PrintAllElements(arr);
        }
        else
        {
            for (int num = next; num <= n; num++)
            {
                //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                arr[k] = num;
                GenerateCombinations(k - 1, n, arr, num + 1);
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
            Console.Write("Please enter \"K\" [1..N]: ");
        } while (!int.TryParse(Console.ReadLine(), out k) || k > n);

        //solution
        int[] arr = new int[k];
        Console.WriteLine("Combinations:");
        GenerateCombinations(k - 1, n, arr);
    }
}

