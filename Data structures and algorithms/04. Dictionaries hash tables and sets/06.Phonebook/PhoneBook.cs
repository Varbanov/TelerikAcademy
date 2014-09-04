using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _06.Phonebook
{
    public class PhoneBook
    {
        private MultiDictionary<string, Record> FirstNames { get; set; }
        private MultiDictionary<string, Record> MiddleNames { get; set; }
        private MultiDictionary<string, Record> LastNames { get; set; }
        private MultiDictionary<string, Record> Towns { get; set; }

        public PhoneBook()
        {
            this.FirstNames = new MultiDictionary<string, Record>(true);
            this.MiddleNames = new MultiDictionary<string, Record>(true);
            this.LastNames = new MultiDictionary<string, Record>(true);
            this.Towns = new MultiDictionary<string, Record>(true);
        }

        public void Add(Record record)
        {
            var firstname = record.FirstName != null ? record.FirstName.ToLower() : string.Empty;
            var middleName = record.MiddleName != null ? record.MiddleName.ToLower() : string.Empty;
            var lastname = record.LastName != null ? record.LastName.ToLower() : string.Empty;
            var town = record.Town != null ? record.Town.ToLower() : string.Empty;
            var phone = record.Phone != null ? record.Phone.ToLower() : string.Empty;

            this.FirstNames.Add(firstname, record);
            this.MiddleNames.Add(middleName, record);
            this.LastNames.Add(lastname, record);
            this.Towns.Add(town, record);
        }

        public HashSet<Record> Find(string name)
        {
            var foundRecords = new HashSet<Record>();

            GetDistinctRecords(name, foundRecords, this.FirstNames);
            GetDistinctRecords(name, foundRecords, this.MiddleNames);
            GetDistinctRecords(name, foundRecords, this.LastNames);

            return foundRecords;
        }
        private static void GetDistinctRecords(string name, HashSet<Record> foundRecords, MultiDictionary<string, Record> data)
        {
            //add to the foundRecords only distinct records to avoid 
            //adding one person with two same names twice
            if (data.ContainsKey(name))
            {
                foreach (var record in data[name])
                {
                    if (!foundRecords.Contains(record))
                    {
                        foundRecords.Add(record);
                    }
                }
            }
        }

    }
}
