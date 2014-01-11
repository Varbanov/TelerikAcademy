
using System;
using System.Collections.Generic;
using System.Text;

class Permutations
{
    static int examCounter = 0;
    static List<string> li = new List<string>();




    //* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
    //Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

    static void PrintAllElements(StringBuilder arr)
    {
        //a method to print all elements of an array
        //foreach (var item in arr)
        //{

        //    Console.Write(item + " ");

        //}

        Console.WriteLine(arr.ToString());
    }

    static bool CheckWord(StringBuilder input)
    {
        bool isOk = true;
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i-1])
            {
                isOk = false;
            }
        }
        return isOk;
    }

    static void GenerateCombinations(int n, StringBuilder arr, bool[] isUsed, string choice)
    {
        //recursive method to generate k nested loops from 1 to n

        if (n == arr.Capacity -1)
        {
            //if we fill in all current combination elements from last to first element
            PrintAllElements(arr);
            if (CheckWord(arr))
            {
                if (!li.Contains(arr.ToString()))
                {
                    examCounter++;
                    //PrintAllElements(arr);
                    li.Add(arr.ToString());
                }
            }
        }
        else
        {
            for (int num = 0; num < arr.Capacity; num++)
            {
                //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                if (isUsed[num])
                {
                    continue;
                }

                arr.Append(choice[num]);
                isUsed[num] = true;
                GenerateCombinations(n + 1, arr, isUsed, choice);
                isUsed[num] = false;
            }
        }
    }

    static void Main()
    {
        //data input
        int n = int.Parse(Console.ReadLine());

        //solution
        string choice = String.Empty;

        for (int i = 0; i < n; i++)
        {
            string p = Console.ReadLine();
            choice += p;
        }

        StringBuilder arr = new StringBuilder(n);
        bool[] isUsed = new bool[n + 1];
        GenerateCombinations(0, arr, isUsed, choice);

        Console.WriteLine(examCounter);

    }

}