using System;

class CompareCharArrays
{   
    //Write a program that compares two char arrays lexicographically (letter by letter).

    static void Main()
    {
        //input
        char[] firstArray = {'n', 'a', 'k', 'o', 'v'};
        char[] secondArray = {'n', 'a', 'K', 'o', 'v', 'v'};

        //solution
        int minLength = Math.Min(firstArray.Length, secondArray.Length);
        bool firstIsFirst = true;
        bool areEqualToMinLength = true;
        for (int i = 0; i < minLength; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                areEqualToMinLength = false;
                break;
            }
            else if (secondArray[i] < firstArray[i])
            {
                areEqualToMinLength = false;
                firstIsFirst = false;
                break;
            }
        }

        if (areEqualToMinLength)
        {
            if (firstArray.Length > secondArray.Length)
            {
                firstIsFirst = false;
            }
        }

        //output
        if (firstIsFirst)
        {
            Console.WriteLine(firstArray);
            Console.WriteLine(secondArray);
        }
        else
        {
            Console.WriteLine(secondArray);
            Console.WriteLine(firstArray);
        }
    }
}

