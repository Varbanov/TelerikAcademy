using System;
using System.Text;
using System.Globalization;

class PrintDate
{
    //17. Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
    //and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

    static void AddHoursAndPrintDate(string inputDateandTime)
    {
        DateTime outputDate = DateTime.ParseExact(inputDateandTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        outputDate = outputDate.AddHours(6.5);
        Console.WriteLine("Day of week: {0} , {1}", outputDate.ToString("dddd", new CultureInfo("bg-BG")), outputDate);
    }

    static void Main()
    {
        //check easily with:
        //01.09.2013 22:22:00
        Console.WriteLine("Enter date and time in the format: day.month.year hour:minute:second");
        AddHoursAndPrintDate(Console.ReadLine());
    }

}
