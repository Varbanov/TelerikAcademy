namespace Phonebook
{
    using Phonebook.Command;
    using Phonebook.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IPhonebookRepository data;
        private IPrinter printer;
        private IPhoneNumberSanitizer sanitizer;

        public CommandFactoryWithLazyLoading(IPhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.data = data;
            this.sanitizer = sanitizer;
            this.printer = printer;
        }

        public IPhoneBookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhoneBookCommand command;
            if (commandName.StartsWith("AddPhone") && (argumentsCount >= 2))
            {
                command = new AddPhoneCommand(data, printer, sanitizer);
            }
            else if ((commandName == "ChangePhone") && (argumentsCount == 2))
            {
                command = new ChangePhoneCommand(data, printer, sanitizer);
            }
            else if ((commandName == "List") && (argumentsCount == 2))
            {
                command = new ListPhonesCommand(data, printer);
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            return command;
        }
    }
}
