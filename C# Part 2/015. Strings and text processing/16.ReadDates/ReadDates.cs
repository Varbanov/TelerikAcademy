using System;
using System.Text;
using System.Globalization;

class ReadDates
{
    //16. Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    //Enter the first date: 27.02.2006
    //Enter the second date: 3.03.2004
    //Distance: 4 days

    static int CountDates(string startDate, string endDate)
    {
        //parse
        DateTime start = DateTime.ParseExact(startDate,"dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        TimeSpan days = end - start;
        return days.Days;
    }

    static void Main()
    {
        //input
        Console.WriteLine("Enter first date dd.mm.yy: ");
        string firstDate = Console.ReadLine();
        Console.WriteLine("Enter second date dd.mm.yy: ");
        string secondDate = Console.ReadLine();

        //solution
        Console.WriteLine("Days: " + CountDates(firstDate, secondDate));
    }
}

