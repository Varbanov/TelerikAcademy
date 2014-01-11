using System;
using System.Collections.Generic;

class CalculateWorkdays
{
    //05. Write a method that calculates the number of workdays between today and given date, passed as parameter.
    //Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

    static void Main()
    {
        //input
        int year, month, day;
        
        do
        {
            Console.Write("Please enter day: ");
        } while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31);

        do
        {
            Console.Write("Please enter month: ");
        } while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12);

        do
        {
            Console.Write("Please enter year: ");
        } while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 9999);

        DateTime date = new DateTime(year, month, day);

        //an example holiday list
        List<DateTime> holidays = new List<DateTime>()
        {
            new DateTime(2013, 8, 13),
            new DateTime(2013, 8, 9),
            new DateTime(2013, 8, 15)
        };

        //solution and output
        int daysCounter = CountWorkDaysFromDate(date, holidays);
        Console.WriteLine("Working dates from/to {0}: {1}", date, daysCounter);
    }

    private static int CountWorkDaysFromDate(DateTime date, List<DateTime> holidays)
    {
        //solution
        int counter = 0;
        DateTime today = DateTime.Now.Date;
        //if the date is in the future
        if (date >= today)
        {
            while (today < date)
            {
                today = today.AddDays(1);
                if (holidays.Contains(today) || today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                counter++;
            }
        }
        //if the date is in the past
        else
        {
            while (date <= today)
            {
                date = date.AddDays(1);
                if (holidays.Contains(date) || date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }
                counter++;
            }
        }
        return counter;
    }
}
