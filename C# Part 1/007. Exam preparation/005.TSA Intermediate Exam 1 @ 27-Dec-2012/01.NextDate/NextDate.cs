using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime input = new DateTime(year, month, day);
        DateTime nextDay = input.AddDays(1);
        Console.WriteLine(nextDay.Day + "." + nextDay.Month + "." + nextDay.Year);
    }
}

