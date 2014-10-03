namespace _01.DateTimeWcfService
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class DayOfWeekService : IDayOfWeekService
    {
        public string GetDayOfWeek(DateTime dateTime)
        {
           return dateTime.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("bg-BG"));
        }
    }
}
