namespace Phonebook.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Phonebook.Model;

    public class SimpleRepository : IPhonebookRepository
    {
        private IList<PhonebookEntry> entries;

        public SimpleRepository() 
            : this(new List<PhonebookEntry>())
        { 
        }

        public SimpleRepository(IList<PhonebookEntry> entries)
        {
            this.entries = entries;
        }

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var oldEntries =
                from e in this.entries
                where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select e;

            if (oldEntries.Count() == 0)
            {
                PhonebookEntry newEntry = new PhonebookEntry();
                newEntry.Name = name;

                foreach (var num in nums)
                {
                    newEntry.PhoneNumbers.Add(num);
                }

                this.entries.Add(newEntry);
                return false;
            }
            else if (oldEntries.Count() == 1)
            {
                PhonebookEntry oldEntry = oldEntries.First();
                foreach (var num in nums)
                {
                    oldEntry.PhoneNumbers.Add(num);
                }

                return true;
            }
            else
            {
                throw new Exception("Duplicated name in the phonebook found: " + name);
            }
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var entriesWithOldNumber = 
                from entry in this.entries 
                where entry.PhoneNumbers.Contains(oldNumber) 
                select entry;

            int changedNumbersCount = 0;
            foreach (var entry in entriesWithOldNumber)
            {
                entry.PhoneNumbers.Remove(oldNumber); 
                entry.PhoneNumbers.Add(newNumber);
                changedNumbersCount++;
            }

            return changedNumbersCount;
        }

        public PhonebookEntry[] ListEntries(int start, int entriesPerPage)
        {
            if (start < 0 || start + entriesPerPage > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or numbers per page.");
            }

            this.entries.ToList().Sort();
            PhonebookEntry[] resultEntries = new PhonebookEntry[entriesPerPage];

            for (int i = start; i < start + entriesPerPage; i++)
            {
                PhonebookEntry entry = this.entries[i];
                resultEntries[i - start] = entry;
            }

            return resultEntries;
        }
    }
}