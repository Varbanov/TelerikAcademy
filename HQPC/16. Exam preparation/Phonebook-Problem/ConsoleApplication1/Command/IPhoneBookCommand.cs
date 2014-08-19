namespace Phonebook.Command
{
    public interface IPhoneBookCommand
    {
        void Execute(string[] arguments);
    }
}
