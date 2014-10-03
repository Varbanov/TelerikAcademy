namespace _02.DayOfWeek.ConsoleClient
{
    using System;
    using _02.DayOfWeek.ConsoleClient.DayofWeekServiceReference;

    public class Client
    {
        static void Main()
        {
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();
            var day = client.GetDayOfWeek(DateTime.Now);
            Console.WriteLine(day);

            // Always close the client.
            client.Close();
        }
    }
}
