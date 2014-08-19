using Phonebook.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phonebook
{
    public interface ICommandFactory
    {
        IPhoneBookCommand CreateCommand(string commandName, int argumentsCount);
    }
}
