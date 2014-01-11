using System;
using System.Text;

class SomeMathSolver
{
    /*Write a program that can solve these tasks:
    Reverses the digits of a number
    Calculates the average of a sequence of integers
    Solves a linear equation a * x + b = 0
	    Create appropriate methods.
	    Provide a simple text-based menu for the user to choose which task to solve.
	    Validate the input data:
    The decimal number should be non-negative
    The sequence should not be empty
    a should not be equal to 0
    */

    static void LinearSolver(float a, float b)
    {
            Console.WriteLine("X = {0}", -b/a);
    }

    static bool ValidateNumber(string number)
    {
        decimal check;
        if (!decimal.TryParse(number, out check) || check < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void ReverseDigitsOfNumber(string num)
    {
        if (ValidateNumber(num))
        {
            StringBuilder reversed = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
            {
                reversed.Append(num[i]);
            }
            Console.WriteLine(reversed);
        }
        else
        {
            Console.WriteLine("The number you entered is incorrect!");
        }
    }

    static void CalculateAverage(int[] arr)
{
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        Console.WriteLine("Average: {0}", sum / arr.Length);
    }

    static void Menu()
    {
        int choice;
        do
        {
             Console.Write("Press 1 to reverse a decimal, 2 to calculate average of a sequence or 3 to solve a linear equation a * x + b = 0: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3));

        if (choice == 1)
        {
            Console.Write("Please enter a decimal: ");
            string num = Console.ReadLine();
            ReverseDigitsOfNumber(num);
        }
        else if (choice == 2)
        {
            int length;
            do
            {
                Console.Write("Please enter the number of elements in the sequence: ");
            } while (!int.TryParse(Console.ReadLine(), out length) || length <= 0);

            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                do
                {
                    Console.Write("Please enter element [{0}]", i);
                } while (!int.TryParse(Console.ReadLine(), out arr[i]));
            }
            CalculateAverage(arr);
        }
        else
        {
            float a, b;
            do
            {
                Console.Write("Please enter coefficient \"a\" [a != 0]: ");
            } while (!float.TryParse(Console.ReadLine(), out a) || a == 0);
            
            do
            {
                Console.Write("Please enter coefficient \"b\": ");
            } while (!float.TryParse(Console.ReadLine(), out b));
            LinearSolver(a, b);
        }
        
    }

    static void Main()
    {
        Menu();
    }
}
