using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrintAllSubsetsOfStrings
{
    class StringCombinations
    {
        static void PrintAllElements(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void GenerateCombinations(string[] inputArr, int k, int n, string[] arr, int next = 0)
        {
            if (k == -1)
            {
                PrintAllElements(arr);
            }
            else
            {
                for (int num = next; num < n; num++)
                {
                    //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                    arr[k] = inputArr[num];
                    GenerateCombinations(inputArr, k - 1, n, arr, num + 1);
                }
            }
        }

        static void Main()
        {
            var inputArr = new string[]
            {
                "test",
                "rock",
                "fun",
            };

            int n = inputArr.Length;
            int k = 2;
            //solution
            string[] result = new string[k];
            Console.WriteLine("Combinations:");
            GenerateCombinations(inputArr, k - 1, n, result);
        }
    }
}
