namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.OleDb;

    class AppendNewRowsToExcel
    {
        //07.Implement appending new rows to the Excel file.

        static void Main()
        {
            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=..\..\Table.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score)", dbConnection);
                command.Parameters.AddWithValue("@Name", "TestName Task 7");
                command.Parameters.AddWithValue("@Score", 100);
                command.ExecuteNonQuery();
                Console.WriteLine("Successfully added a new row!");
            }
        }
    }
}
