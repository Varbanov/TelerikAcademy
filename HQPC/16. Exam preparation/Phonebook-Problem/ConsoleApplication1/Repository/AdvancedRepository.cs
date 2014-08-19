namespace Phonebook.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Model;
    using Wintellect.PowerCollections;

    public class AdvancedRepository : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> sortedEntries;
        private Dictionary<string, PhonebookEntry> dictEntries;
        private MultiDictionary<string, PhonebookEntry> multidictEntries;

        public AdvancedRepository()
            : this(new OrderedSet<PhonebookEntry>(), new Dictionary<string, PhonebookEntry>(), new MultiDictionary<string, PhonebookEntry>(false))
        {
        }

        public AdvancedRepository(OrderedSet<PhonebookEntry> sortedEntries, Dictionary<string, PhonebookEntry> dictionaryOfEntries, MultiDictionary<string, PhonebookEntry> multiDictionaryOfEntries)
        {
            this.sortedEntries = sortedEntries;
            this.dictEntries = dictionaryOfEntries;
            this.multidictEntries = multiDictionaryOfEntries;
        }

        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            string lowerName = name.ToLowerInvariant();
            bool entryExists = this.dictEntries.ContainsKey(lowerName);

            PhonebookEntry newEntry = new PhonebookEntry();

            if (entryExists)
            {
                newEntry = new PhonebookEntry();
                newEntry.Name = name;
                this.dictEntries.Add(lowerName, newEntry);
                this.sortedEntries.Add(newEntry);
            }

            foreach (var num in numbers)
            {
                this.multidictEntries.Add(num, newEntry);
            }

            newEntry.PhoneNumbers.UnionWith(numbers);
            return entryExists;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidictEntries[oldent].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.multidictEntries.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent);
                this.multidictEntries.Add(newent, entry);
            }

            return found.Count;
        }

        public PhonebookEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dictEntries.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            PhonebookEntry[] list = new PhonebookEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PhonebookEntry entry = this.sortedEntries[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}
