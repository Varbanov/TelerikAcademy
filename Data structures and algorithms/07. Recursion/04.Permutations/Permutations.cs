using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Permutations
    {
        static void PrintAllElements(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void GeneratePermutations(int n, int[] arr, bool[] isUsed)
        {
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
                    GeneratePermutations(n + 1, arr, isUsed);
                    isUsed[num] = false;
                }
            }
        }

        static void Main()
        {
            //data input
            Console.WriteLine("Enter integer n: ");
            int n = int.Parse(Console.ReadLine());

            //solution
            int[] arr = new int[n];
            bool[] isUsed = new bool[n + 1];
            GeneratePermutations(0, arr, isUsed);
        }
    }
}
