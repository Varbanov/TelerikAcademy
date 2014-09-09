using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Combinations
{
    class Combinations
    {
        static void PrintAllElements(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void GenerateCombinations(int k, int n, int[] arr, int next = 1)
        {
            if (k == -1)
            {
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
}