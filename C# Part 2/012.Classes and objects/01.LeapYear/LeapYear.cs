using System;

class LeapYear
{
    //01. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

    static void Main()
    {
        //input
        int year;
        do
        {
            Console.Write("Please enter a year [1..9999]: ");
        } while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 9999);
        
        //solution
        bool isLeap = DateTime.IsLeapYear(year);
        if (isLeap)
        {
            Console.WriteLine("{0} is a leap year!", year);
        }
        else
        {
            Console.WriteLine("{0} is not a leap year", year);
        }
    }
}