using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractDates
{
    //19. Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

    static void ExtractDatesFromtext(string text)
    {
        string pattern = @"\b\d\d\.\d\d\.\d\d\d\d\b";
        List<DateTime> dates = new List<DateTime>();

        MatchCollection matches = Regex.Matches(text, pattern);
        //adding the dates in the DateTime type to a list
        foreach (var item in matches)
        {
            dates.Add(DateTime.ParseExact(item.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }

        //print in the Canada standard
        foreach (var item in dates)
        {
            Console.WriteLine(item.ToString(CultureInfo.GetCultureInfo("en-CA")));
        }
    }

    static void Main()
    {
        //input
        string text = "fsafas 03.03.2003 dsfds 05.05.2005.";
        
        ExtractDatesFromtext(text);
    }
}
