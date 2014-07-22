namespace Singleton
{
    using System;
    using System.Collections.Generic;

    public sealed class AvailabilityChangeJournal : IReportable
    {
        private static readonly AvailabilityChangeJournal journal = new AvailabilityChangeJournal();
        private List<AvailabilityJournalItem> items;
        private List<IInformable> subscribers = new List<IInformable>();

        private AvailabilityChangeJournal()
        {
            this.items = new List<AvailabilityJournalItem>();
        }

        public static AvailabilityChangeJournal Journal
        {
            get
            {
                return journal;
            }
        }

        public void Subscribe(IInformable subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void SaveToJournal(string message, ChangeType type)
        {
            this.items.Add(new AvailabilityJournalItem(message, type));
            this.NotifySubscribers(string.Format("Event added to the availability journal: event message: {0}; event type: {1}", message, type));
        }

        public void CreateReport()
        {
            foreach (var item in this.items)
            {
                Console.WriteLine(item);
            }
        }

        private void NotifySubscribers(string information)
        {
            for (int i = 0; i < this.subscribers.Count; i++)
            {
                this.subscribers[i].Inform(information);
            }
        }
    }
}
