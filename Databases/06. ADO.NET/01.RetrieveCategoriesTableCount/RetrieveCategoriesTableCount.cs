namespace _01.RetrieveCategoriesTableCount
{
    using System;
    using System.Data.SqlClient;

    class RetrieveCategoriesTableCount
    {
        //01. Write a program that retrieves from the Northwind
        //sample database in MS SQL Server the number of
        //rows in the Categories table.

        static void Main()
        {
            var connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbConnection);
                int rowsNumber = (int)command.ExecuteScalar();
                Console.WriteLine("Rows in Categories: {0}", rowsNumber);
            }
        }
    }
}
