namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class RetrieveWithJoin
    {
        //03.Write a program that retrieves from the Northwind
        //database all product categories and the names of
        //the products in each category. Can you do this with a
        //single SQL query (with table join)?
        static void Main()
        {
            var connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                var query = "SELECT c.CategoryName, p.ProductName FROM Products p JOIN Categories c ON c.CategoryID = p.CategoryID GROUP BY c.CategoryName, p.ProductName";
                SqlCommand command = new SqlCommand(query, dbConnection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Dictionary<string, List<string>> items = new Dictionary<string, List<string>>();

                    while (reader.Read())
                    {
                        var category = (string)reader[0];
                        var product = (string)reader[1];

                        if (!items.ContainsKey(category))
                        {
                            items[category] = new List<string>();
                            items[category].Add(product);
                        }
                        else
                        {
                            items[category].Add(product);
                        }
                    }

                    foreach (var pair in items)
                    {
                        Console.WriteLine(new string('-', 20));
                        Console.WriteLine("{0}: ", pair.Key.PadRight(20, ' '));
                        Console.WriteLine(new string('-', 20));
                        Console.WriteLine("{0}", string.Join(", ", pair.Value));
                    }
                }
            }
        }
    }
}
