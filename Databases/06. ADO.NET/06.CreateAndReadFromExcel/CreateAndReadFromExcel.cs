namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.OleDb;

    class CreateAndReadFromExcel
    {
        //06.Create an Excel file with 2 columns: name and score:
        //Write a program that reads your MS Excel file
        //through the OLE DB data provider and displays the
        //name and score row by row.

        static void Main()
        {
            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=..\..\Table.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT Name, Score FROM [Sheet1$]", dbConnection);
                OleDbDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0}: {1} scores", name, score);
                    }
                }
            }
        }
    }
}
