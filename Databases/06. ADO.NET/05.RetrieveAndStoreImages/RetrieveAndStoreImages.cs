namespace _02.RetrieveInfoFromCategories
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class RetrieveAndStoreImages
    {
        //05.Write a program that retrieves the images for all
        //categories in the Northwind database and stores
        //them as JPG files in the file system.


        private static void WriteBinaryFile(string fileName,
        byte[] fileContents)
        {
            FileStream stream = File.OpenWrite("..\\..\\" + fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private static void ExtractImagesFromCategoryToFiles(string connectionString, out byte[] rawImage)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbConnection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    rawImage = new byte[0];

                    while (reader.Read())
                    {
                        rawImage = (byte[])reader["Picture"];
                        int length = rawImage.Length;
                        int header = 78;
                        byte[] imgData = new byte[length - header];
                        Array.Copy(rawImage, header, imgData, 0, length - header);
                        string name = ((string)reader["CategoryName"]).Replace('/', '_') + ".jpg";
                        WriteBinaryFile(name, imgData);
                    }
                }
            }
        }

        static void Main()
        {
            string connectionString = @"Server=.\SQLEXPRESS ; Database=Northwind; Integrated security=SSPI";
            byte[] imageFromDB;
            ExtractImagesFromCategoryToFiles(connectionString, out imageFromDB);
            Console.WriteLine("Successfully extracted all images in the current project directory!");
        }
    }
}
