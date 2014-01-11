using System;

class CompareTwoArrays
{
    //Write a program that reads two arrays from the console and compares them element by element.

    static void Main()
    {
        //length input
        int length;
        do
        {
            Console.Write("Please enter the length of the arrays: ");
        } while (!int.TryParse(Console.ReadLine(), out length));


        //arrays initialization and solution
        int[] firstArray = new int[length];
        int[] secondArray = new int[length];
        bool areEqual = true;

        for (int i = 0; i < length; i++)
        {
            do
	        {
	                Console.Write("Please enter integer {0} for FIRST array: ", i);   
	        } while (!int.TryParse(Console.ReadLine(), out firstArray[i]));

            do
            {
                Console.Write("Please enter integer {0} for SECOND array: ", i);
            } while (!int.TryParse(Console.ReadLine(), out secondArray[i]));

            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
                break;
            }
        }
        Console.WriteLine("The two arrays are equal: {0}!", areEqual.ToString().ToUpper());
    }
}

