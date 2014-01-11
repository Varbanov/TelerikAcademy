using System;

class SubsetSum
{
    //* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
// arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)

    //dynamic programming solution
    //data input
    static int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
    static int sum = 14;
    //declare a boolean 2-dim array to fill in all possible sums
    static bool[,] func = new bool[arr.Length, sum + 1];
    static bool[,] isCalculated = new bool[arr.Length, sum + 1];

    static bool CalculateFunc(int arrElemIndex, int sum)
    {
        // Recursively check in the bool array "f" from rigthmost element if the sum including current element
        // or excluding it is possible            
        if (sum < 0)
        {
            return false;
        }
        if (arrElemIndex < 0)
        {
            return false;
        }
        if (arr[arrElemIndex] == sum)
        {
            return true;
        }

        //remember already calculated elements of "f"
        if (isCalculated[arrElemIndex, sum])
        {
            return func[arrElemIndex, sum];
        }
        //recursively check possible sums for every next element to the left from the current
        func[arrElemIndex, sum] = (arr[arrElemIndex] == sum) || CalculateFunc(arrElemIndex - 1, sum) || CalculateFunc(arrElemIndex - 1, sum - arr[arrElemIndex]);
        isCalculated[arrElemIndex, sum] = true;
        return func[arrElemIndex, sum];
    }

    static void Main()
    {
        bool res = CalculateFunc(arr.Length - 1, sum);
        Console.WriteLine("The sum exists: {0}", res);

        //print numbers
        int i = arr.Length - 1;
        while (true)
        {
            if (arr[i] == sum)
            {
                Console.WriteLine(arr[i]);
                return;
            }
            if (CalculateFunc(i - 1, sum - arr[i]))
            {
                // If arr[i] is included
                Console.WriteLine(arr[i]);
                sum = sum - arr[i];
                i--;
            }
            else if (CalculateFunc(i - 1, sum))
            {
                // If arr[i] is excluded
                i--;
            }
        }
    }
}
