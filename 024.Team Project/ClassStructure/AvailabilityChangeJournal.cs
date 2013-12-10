using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace TimberYardSoft.ClassStructure
{
    public sealed class AvailabilityChangeJournal : IReportable
    {
        private static readonly AvailabilityChangeJournal journal = new AvailabilityChangeJournal();

        public static AvailabilityChangeJournal Journal
        {
            get
            {
                return journal;
            }
        }

        private List<AvailabilityJournalItem> items;

        private AvailabilityChangeJournal()
        {
            this.items = new List<AvailabilityJournalItem>();
        }

        public void SaveToJournal(string message, ChangeType type)
        {
            this.items.Add(new AvailabilityJournalItem(message, type));
        }


        public void TraceYard(TimberYard yard)
        {
            yard.YardChanged += (snd, args) =>
                {
                    SaveToJournal(args.Lot.ToString(), args.Type);
                };
        }

        public void CreateReport()
        {
            StreamWriter writer = new StreamWriter(@"..\..\firm journal.txt", true);
            using (writer)
            {
                foreach (var item in this.items)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
