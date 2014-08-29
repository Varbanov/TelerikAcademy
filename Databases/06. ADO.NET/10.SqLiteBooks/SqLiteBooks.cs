using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace _10.SqLiteBooks
{
    class SqLiteBooks
    {

        //Because with all packages, the archive exceeds the maximum
        //upload size of 16 MB in the Telerik Academy System, for task 10 
        //just install System.Data.SQLite Core (x86/x64) (find it in
        //the Visual Studio NuGet Package Manager).

        static void AddBook(SQLiteConnection dbConnection, string author, string title, string Isbn, DateTime DatePublished)
        {
            string query = @"USE Books; INSERT INTO BOOKS (Title, Author, Isbn, DatePublished) VALUES(@Title, @Author, @Isbn, @DatePublished)";
            SQLiteCommand command = new SQLiteCommand(query, dbConnection);
            command.Parameters.AddWithValue("@ISBN", Isbn);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@PublishDate", DatePublished);

            command.ExecuteNonQuery();
        }

        static void SearchByName(SQLiteConnection dbConnection, string input)
        {
            input = input.Replace("%", "[%]")
                .Replace("_", "[_]");
            string query = @"USE Books; SELECT Title, Author, Isbn, DatePublished FROM Books WHERE Title LIKE @bookName";
            SQLiteCommand command = new SQLiteCommand(query, dbConnection);
            command.Parameters.AddWithValue("@bookName", "%" + input + "%");
            SQLiteDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["Isbn"], reader["DatePublished"]);
                }
            }
        }

        static void ListBooks(SQLiteConnection dbConnection)
        {
            string query = @"USE Books; SELECT Title, Author, Isbn, DatePublished FROM Books";

            SQLiteCommand insertBook = new SQLiteCommand(query, dbConnection);
            SQLiteDataReader reader = insertBook.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["Isbn"], reader["DatePublished"]);
                }
            }
        }

        static void Main()
        {
            //Because with all packages, the archive exceeds the maximum
            //upload size of 16 MB in the Telerik Academy System, for task 10 
            //just install System.Data.SQLite Core (x86/x64) (find it in
            //the Visual Studio NuGet Package Manager).

            var connectionString = @"Data Source=..\..\Books.db;Version=3;";
            SQLiteConnection dbConnection = new SQLiteConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                AddBook(dbConnection, "Book 1", "Title 1", "123456", DateTime.Now);
                AddBook(dbConnection, "Book 2", "Title 2", "123456", DateTime.Now);

                ListBooks(dbConnection);

                Console.WriteLine("Please enter a book title's part: ");
                string input = Console.ReadLine();
                input = input.Replace("%", "[%]")
                        .Replace("_", "[_]");
                SearchByName(dbConnection, input);
            }
        }
    }
}
