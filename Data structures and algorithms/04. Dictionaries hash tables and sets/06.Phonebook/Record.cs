using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Phonebook
{
    public class Record
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Town { get; set; }

        public Record(string firstName, string middleName, string lastName, string phone, string town)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Phone = phone;
            this.Town = town;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.MiddleName + " " +
                this.LastName + " " + this.Town + " " + this.Phone;
        }

    }
}
