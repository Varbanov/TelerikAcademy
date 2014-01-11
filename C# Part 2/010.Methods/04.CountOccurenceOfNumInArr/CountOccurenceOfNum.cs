using System;

namespace TaskCountOccurence
{
    public class CountOccurenceOfNum
    {
        //Write a method that counts how many times given number appears in given array.
        //Write a test program to check if the method is working correctly.
        public static int CountOccurenceOfNumInArray(int[] arr, int num)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void Main()
        {
            //see test project 040 in Solution Explorer for tests. Right click and run tests :)
            int[] arr = { 1, 2, 3, 4, 2, 5, 6, 2, 7, 2, 8, 9, 0, 2 };
            int result = CountOccurenceOfNumInArray(arr, 2);
            Console.WriteLine(result);
        }
    }
}