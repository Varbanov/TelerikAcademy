using System;
using System.Collections.Generic;

class GenericMethods
{
    //* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.).
    //Use generic method (read in Internet about generic methods in C#).

    static T CalculateMin<T>(params T[] numArray)
    {
        dynamic min = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] < min)
            {
                min = numArray[i];
            }
        }
        return min;
    }

    static T CalculateMax<T>(params T[] numArray)
    {
        dynamic max = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] > max)
            {
                max = numArray[i];
            }
        }
        return max;
    }

    static T CalculateAverage<T>(params T[] numArray)
    {
        dynamic sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }
        return (sum / numArray.Length);
    }

    static T CalculateSum<T>(params T[] numArray)
    {
        dynamic sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }
        return sum;
    }

    static T CalculateProduct<T>(params T[] numArray)
    {
        dynamic product = 1;
        for (int i = 0; i < numArray.Length; i++)
        {
            product = product * numArray[i];
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("The minimum of set of ints is: {0}", CalculateMin(1, 2.0, 3, 4, -5, 6, 7));
        Console.WriteLine("The maximum of set of ints is: {0}", CalculateMax(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The average of set of ints is: {0}", CalculateAverage(2, 3));
        Console.WriteLine("The sum of set of ints is: {0}", CalculateSum(1, 2, 3, 4, -5, 6M, 7));
        Console.WriteLine("The product of set of ints is: {0}", CalculateProduct(1, 2, 3, 4, -5, 6, 7));
    }
}
