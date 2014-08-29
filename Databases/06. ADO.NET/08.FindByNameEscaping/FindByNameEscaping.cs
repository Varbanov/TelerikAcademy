namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.SqlClient;

    class FindByNameEscaping
    {
        //08.Write a program that reads a string from the console
        //and finds all products that contain this string. Ensure
        //you handle correctly characters like ', %, ", \ and _.

        static void SearchForProduct(string seekedInput, SqlConnection connection)
        {
            seekedInput = seekedInput.Replace("%", "[%]")
                .Replace("_", "[_]");
            SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName Like @searchedSubstring;", connection);
            command.Parameters.AddWithValue("@searchedSubstring", "%" + seekedInput + "%");
            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string product = (string)reader["ProductName"];
                    Console.WriteLine(product);
                }
            }
        }


        static void Main()
        {
            Console.Write("Enter part of product name to search for: ");
            var input = Console.ReadLine();
            var connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            SearchForProduct(input, dbConnection);
        }
    }
}
