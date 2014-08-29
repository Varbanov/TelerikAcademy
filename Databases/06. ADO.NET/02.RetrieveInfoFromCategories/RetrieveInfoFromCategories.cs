namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.SqlClient;

    class RetrieveInfoFromCategories
    {
        //02.Write a program that retrieves the name and
        //description of all categories in the Northwind DB.

        static void Main()
        {
            var connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbConnection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["CategoryName"];
                        var description = (string)reader["Description"];
                        Console.WriteLine("{0} {1}", name.PadRight(15, ' '), description.PadRight(50, ' '));
                    }
                }
            }
        }
    }
}
