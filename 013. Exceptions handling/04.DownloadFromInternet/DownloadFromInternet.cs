using System;
using System.Net;
using System.Text;

class DownloadFromInternet
{
    //04. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
    //and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
    //all exceptions and to free any used resources in the finally block.

 private static string ExtractNameFromURL(string url)
    {
        int startIndexOfName = url.LastIndexOf('/') + 1;
        StringBuilder fileName = new StringBuilder();
        for (int i = startIndexOfName; i < url.Length; i++)
        {
            fileName.Append(url[i]);
        }
        return fileName.ToString();
    }

    static void Main()
    {
        //input
        Console.WriteLine("Please enter the full url path:");
        string url = Console.ReadLine();
        //string url = @"http://www.devbg.org/img/Logo-BASD.jpg";

        //extract file name
        string fileName = ExtractNameFromURL(url);

        //solution
        WebClient client = new WebClient();
        try
        {
            //the file is downloaded in the current directory of the program (...\bin\debug)
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, client);
            client.DownloadFile(url, fileName);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The address parameter is null.");
        }
        catch (WebException webEx)
        {
            Console.WriteLine(webEx.Message);
        }
        catch (NotSupportedException notSupportedEX)
        {
            Console.WriteLine(notSupportedEX.Message);
        }
        finally
        {
            client.Dispose();
        }

        ////instead, one can use "using" block to dispose automatically:
        //using (WebClient client = new WebClient())
        //{
        //    string fileName = "your_file.jpg";
        //    Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, client);
        //    client.DownloadFile(url, fileName);
        //}
    }

   
}

