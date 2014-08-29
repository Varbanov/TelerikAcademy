namespace _09.MySqlConnection
{
    using System;
    using MySql.Data.MySqlClient;

    class MySqlDatabaseBooks
    {
        //Just run the script 
        //"MySQL Workbench book schema for task 9.sql"
        //to generate the corresponding database.
        //You may also need to edit the connection string.


        static void AddBook(MySqlConnection dbConnection, string author, string title, string Isbn, string DatePublished)
        {
            string query = @"USE mydb; INSERT INTO books (Title, Author, Isbn, DatePublished) VALUES(@Title, @Author, @Isbn, @DatePublished)";
            MySqlCommand command = new MySqlCommand(query, dbConnection);
            command.Parameters.AddWithValue("@ISBN", Isbn);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@DatePublished", DatePublished);

            command.ExecuteNonQuery();
        }

        static void SearchByName(MySqlConnection dbConnection, string input)
        {
            input = input.Replace("%", "[%]")
                .Replace("_", "[_]");
            string query = @"USE mydb; SELECT Title, Author, Isbn, DatePublished FROM Books WHERE Title LIKE @bookName";
            MySqlCommand command = new MySqlCommand(query, dbConnection);
            command.Parameters.AddWithValue("@bookName", "%" + input + "%");
            MySqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["Isbn"], reader["DatePublished"]);
                }
            }
        }

        static void ListBooks(MySqlConnection dbConnection)
        {
            string query = @"USE mydb; SELECT Title, Author, Isbn, DatePublished FROM Books";

            MySqlCommand insertBook = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = insertBook.ExecuteReader();
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
            //Just run the script 
            //"MySQL Workbench book schema for task 9.sql"
            //to generate the corresponding database.
            //You may also need to edit the connection string.


            var connectionString = "Server=localhost; Port=3306; Database=mydb; Uid=root; Pwd=123qwe; pooling=true";
            MySqlConnection dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                AddBook(dbConnection, "Author 1", "Title 1", "123456", null);
                AddBook(dbConnection, "Author 2", "Title 2", "123456", null);

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
