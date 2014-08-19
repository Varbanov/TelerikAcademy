namespace Phonebook.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameLower;

        public PhonebookEntry()
            : this(new SortedSet<string>())
        {
        }

        public PhonebookEntry(SortedSet<string> phoneNumbers)
        {
            this.PhoneNumbers = phoneNumbers;
        }

        public SortedSet<string> PhoneNumbers { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameLower = value.ToLowerInvariant();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append('[');
            result.Append(this.Name);
            bool isFirstPhone = true;

            foreach (var phone in this.PhoneNumbers)
            {
                if (isFirstPhone)
                {
                    result.Append(": ");
                    isFirstPhone = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameLower.CompareTo(other.nameLower);
        }
    }
}
