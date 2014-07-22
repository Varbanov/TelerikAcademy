namespace Singleton
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var journal = AvailabilityChangeJournal.Journal;
            var subscriber1 = new Subscriber();
            journal.Subscribe(subscriber1);

            journal.SaveToJournal("outcomming message1", ChangeType.OUT);
            journal.SaveToJournal("outcomming message2", ChangeType.OUT);

            var subscriber2 = new Subscriber();
            journal.Subscribe(subscriber2);

            journal.SaveToJournal("incomming message1", ChangeType.IN);
            journal.SaveToJournal("incomming message2", ChangeType.IN);

            journal.CreateReport();
            Console.WriteLine("-------------------------");

            subscriber1.ShowAllInformation();
            Console.WriteLine("-------------------------");
            subscriber2.ShowAllInformation();
        }
    }
}
