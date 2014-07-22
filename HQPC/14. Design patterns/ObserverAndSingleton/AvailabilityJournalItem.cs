namespace Singleton
{
    using System;

    public class AvailabilityJournalItem
    {
        private DateTime eventDate;

        public AvailabilityJournalItem(string content, ChangeType type)
        {
            this.Content = content;
            this.eventDate = DateTime.Now;
            this.Type = type;
        }

        public ChangeType Type { get; private set; }

        public string Content { get; private set; }

        public string Message
        {
            get { return this.Content; }
        }

        public DateTime EventDate
        {
            get 
            { 
                return this.eventDate; 
            }
        }

        public override string ToString()
        {
            return string.Format("{0}  {1,3} {2}", this.EventDate, this.Type, this.Content);
        }
    }
}
