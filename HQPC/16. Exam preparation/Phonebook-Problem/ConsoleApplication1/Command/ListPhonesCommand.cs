namespace Phonebook.Command
{
    using System;
    using System.Collections.Generic;
    using Phonebook.Model;
    using Phonebook.Repository;

    public class ListPhonesCommand : IPhoneBookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;

        public ListPhonesCommand(IPhonebookRepository data, IPrinter printer)
        {
            this.printer = printer;
            this.data = data;
        }

        public void Execute(string[] parameters)
        {
            var entries = this.data.ListEntries(int.Parse(parameters[0]), int.Parse(parameters[1]));
            if (entries == null)
            {
                this.printer.Print("Invalid range");
            }
            else
            {
                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
        }
    }
}

