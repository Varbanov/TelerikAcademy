using System;

class Permutations
{
    //TODO:
    //* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
    //Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    static void PrintAllElements(int[] arr)
    {
        //a method to print all elements of an array
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void GenerateCombinations(int n, int[] arr, bool[] isUsed)
    {
        //recursive method to generate k nested loops from 1 to n
        if (n == arr.Length)
        {
            //if we fill in all current combination elements from last to first element
            PrintAllElements(arr);
        }
        else
        {
            for (int num = 1; num <= arr.Length; num++)
            {
                //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                if (isUsed[num])
                {
                    continue;
                }
                arr[n] = num;
                isUsed[num] = true;
                GenerateCombinations(n + 1, arr, isUsed);
                isUsed[num] = false;
            }
        }
    }

    static void Main()
    {
        //data input
        int n;
        do
        {
            Console.Write("Please enter \"N\" [> 0]: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

        //solution
        int[] arr = new int[n];
        bool[] isUsed = new bool[n + 1];
        Console.WriteLine("Permutations:");
       GenerateCombinations(0, arr, isUsed);
    }
}

