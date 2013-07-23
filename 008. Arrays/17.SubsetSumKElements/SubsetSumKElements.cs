using System;

class SubsetSumKElements
{
    //17* Write a program that reads three integer numbers N, K and S and an array of N elements from
    //the console. Find in the array a subset of K elements that have sum S or indicate about its absence.

    static bool subsetExists = false;

    static void PrintAllElements(int[] arr)
    {
        //a method to print all elements of an array
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void GenerateCombinations(int k, int[] arr, int s, int[] result, int next = 0)
    {
        //recursive method to generate k nested loops from 1 to n
        if (k == -1)
        {
            //if we fill in all current combination elements from last to first element
            int sum = 0;
            foreach (var item in result)
            {
                sum += item;
            }
            if (sum == s)
            {
                subsetExists = true;
                PrintAllElements(result);
            }
        }
        else
        {
            for (int num = next; num < arr.Length; num++)
            {
                //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                result[k] = arr[num];
                GenerateCombinations(k - 1, arr, s, result, num + 1);
            }
        }
    }

    static void Main()
    {
        //input
        int n, k, s;
        do
        {
            Console.Write("Please enter \"N\" [N > 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

        do
        {
            Console.Write("Please enter \"K\" [K > 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out k) || n < 1);

        do
        {
            Console.Write("Please enter \"S\": ");
        } while (!int.TryParse(Console.ReadLine(), out s));

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            do
            {
                Console.Write("Please enter element [{0}]: ", i);
            } while (!int.TryParse(Console.ReadLine(), out arr[i]));
        }

        //solution using recursive combinations generator (see problem 21)
        Array.Sort(arr);
        int[] result = new int[k];
        GenerateCombinations(k - 1, arr, s, result);
        if (!subsetExists)
        {
            Console.WriteLine("No subset sum of K elements equals {0}", s);
        }
    }
}

