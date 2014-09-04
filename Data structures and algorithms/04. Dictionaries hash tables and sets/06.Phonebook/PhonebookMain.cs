using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using System.IO;

namespace _06.Phonebook
{
    class PhonebookMain
    {
        static void Main()
        {
            var path = @"../../records.txt";
            var phonebook = new PhoneBook();

            PopulatePhoneBookFromFile(phonebook, path);

            Console.WriteLine(string.Join(", ", phonebook.Find("mimi")));
            Console.WriteLine(string.Join(", ", phonebook.Find("gancho")));
        }

        private static  void PopulatePhoneBookFromFile(PhoneBook phonebook, string path)
        {
            var reader = new StreamReader(path);

            using (reader)
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var recordParts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var names = recordParts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Record record;

                    if (names.Length == 1)
                    {
                        record = new Record(names[0], null, null, recordParts[1], recordParts[2]);
                        phonebook.Add(record);
                    }
                    else if (names.Length == 2)
                    {
                        record = new Record(names[0], names[1], null, recordParts[1], recordParts[2]);
                        phonebook.Add(record);
                    }
                    else if (names.Length == 3)
                    {
                        record = new Record(names[0], names[1], names[2], recordParts[1], recordParts[2]);
                        phonebook.Add(record);
                    }
                    else
                    {
                        throw new FormatException("The file database is not correct");
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
