namespace Phonebook.Command
{
    using System.Linq;
    using Phonebook.Repository;

    public class AddPhoneCommand : IPhoneBookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhoneNumberSanitizer sanitizer;

        public AddPhoneCommand(IPhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            string str0 = arguments[0];

            var numbers = arguments.Skip(1).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = this.sanitizer.Sanitize(numbers[i]);
            }

            bool phoneEntryCreated = this.data.AddPhone(str0, numbers);

            if (!phoneEntryCreated)
            {
                this.printer.Print("Phone entry created.");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }
        }
    }
}
