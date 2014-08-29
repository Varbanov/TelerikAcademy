namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.SqlClient;

    class AddProductWithParameters
    {
        //04.Write a method that adds a new product in the
        //products table in the Northwind database. Use a
        //parameterized SQL command.

        static void AddProduct(SqlConnection dbConnection, string name, int supplier, int category, string quantityPerUnit = null, bool discontinued = false)
        {
            string query = "INSERT INTO Products (ProductName, SupplierID, CategoryID, Discontinued)" +
                "VALUES (@name, @supplier, @category, @discontinued)";
            SqlCommand commandInsertProduct = new SqlCommand(query, dbConnection);
            commandInsertProduct.Parameters.AddWithValue("@name", name);
            commandInsertProduct.Parameters.AddWithValue("@supplier", supplier);
            commandInsertProduct.Parameters.AddWithValue("@category", category);
            commandInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);

            SqlParameter sqlParameterQuantityPerUnit = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                sqlParameterQuantityPerUnit.Value = DBNull.Value;
            }

            commandInsertProduct.Parameters.Add(sqlParameterQuantityPerUnit);
            commandInsertProduct.ExecuteNonQuery();
        }

        static void Main()
        {
            var connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                AddProduct(dbConnection, "TEST", 1, 1);
            }
        }
    }
}
