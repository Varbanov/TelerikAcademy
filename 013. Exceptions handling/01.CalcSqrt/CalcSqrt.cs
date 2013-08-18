using System;

class CalcSqrt
{
    //01. Write a program that reads an integer number and calculates and prints its square root.
    //If the number is invalid or negative, print "Invalid number". In all cases finally print
    //"Good bye". Use try-catch-finally.

    static double CalculateSqrt(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException("The number must be positive!");
        }
        else
        {
            double res = Math.Sqrt((double)num);
            return res;
        }
    }

    static void Main()
    {
        try
        {
            Console.Write("Please enter an integer: ");
            CalculateSqrt(int.Parse(Console.ReadLine()));
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Invalid number! " + fe.Message);
        }
        catch (ArgumentException outOfRange)
        {
            Console.Error.WriteLine(outOfRange.Message);
        }
        catch (OverflowException overflowEx)
        {
            Console.Error.WriteLine("Error! The number must be smaller or equal to {0}! {1}", int.MaxValue, overflowEx);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}

