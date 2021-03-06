﻿namespace Phonebook.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Phonebook.Model;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}
