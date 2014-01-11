using System;

class DayOfWeek
{
    //03.Write a program that prints to the console which day of the week is today. Use System.DateTime.

    static void Main()
    {
        DateTime day = DateTime.Now;
        Console.WriteLine(day.DayOfWeek);

        //the same on a single line
        //Console.WriteLine(DateTime.Now.DayOfWeek);
    }
}

