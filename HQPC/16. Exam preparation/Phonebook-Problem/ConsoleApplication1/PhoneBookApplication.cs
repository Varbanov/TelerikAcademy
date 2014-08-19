namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Phonebook;
    using Phonebook.Command;
    using Phonebook.Model;
    using Phonebook.Repository;

    public class PhoneBookApplication
    {
        public static void Main()
        {
            IPhonebookRepository data = new AdvancedRepository();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhonebookSanitizer();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);
           

            while (true)
            {
                string currentCommand = Console.ReadLine();
                if (currentCommand == "End" || currentCommand == null)
                {
                    Console.Write(printer.GetAllText());
                    return;
                }

                int openingBracketIndex = currentCommand.IndexOf('('); 
                
                if (openingBracketIndex == -1) 
                {
                    throw new ArgumentException("Invalid command. The command must have an opening bracket.");
                }

                if (!currentCommand.EndsWith(")"))
                {
                    throw new ArgumentException("Invalid command. The command must end with a closing bracket.");
                }

                string commandText = currentCommand.Substring(0, openingBracketIndex);
                string parametersString = currentCommand.Substring(openingBracketIndex + 1, currentCommand.Length - openingBracketIndex - 2);

                string[] parameters = parametersString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < parameters.Length; j++)
                {
                    parameters[j] = parameters[j].Trim();
                }

                IPhoneBookCommand command = commandFactory.CreateCommand(commandText, parameters.Length);

                command.Execute(parameters);
            }
         }
    }
}