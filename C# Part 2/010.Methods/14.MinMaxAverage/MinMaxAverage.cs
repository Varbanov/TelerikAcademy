using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class MinMaxAverage
    {
        //Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

        static int CalculateMin(params int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static int CalculateMax(params int[] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static float CalculateAverage(params int[] arr)
        {
            float sum = 0; 
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum / arr.Length;
        }

        static long CalculateSum(params int[] arr)
        {
            long sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static decimal CalculateProduct(params int[] arr)
        {
            decimal product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }

        static void Main()
        {
            //min
            int min = CalculateMin(7, 2, 3, 4, 5);
            Console.WriteLine("Min: {0}", min);
            //max
            int max = CalculateMax(4, 5, 6, 7, 8);
            Console.WriteLine("Max: {0}", max);
            //average
            float average = CalculateAverage(2, 3, 4, 5);
            Console.WriteLine("Average: {0}", average);
            //sum
            long sum = CalculateSum(4, 5, 6, 7, 8);
            Console.WriteLine("Sum: {0}", sum);
            //product
            decimal product = CalculateProduct(4, 5, 6, 7, 8);
            Console.WriteLine("Product: {0}", product);
        }
    }
