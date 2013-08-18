using System;
using System.IO;
using System.Text;

class ReadFileClass
{
    //03. Write a program that enters file name along with its full file path 
    //(e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
    //Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all 
    //possible exceptions and print user-friendly error messages.

    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter a file path: ");
            string path = Console.ReadLine();
            string res = File.ReadAllText(path);
            Console.WriteLine(res);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path has a null value! ");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white spaceor contains one or more invalid characters ");
        }
        catch (PathTooLongException pathEx)
        {
            Console.WriteLine(pathEx.Message);
        }
        catch (DirectoryNotFoundException dirEx)
        {
            Console.WriteLine(dirEx.Message);
        }
        catch (UnauthorizedAccessException unauthorizedEx)
        {
            Console.WriteLine(unauthorizedEx.Message);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file was not found!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid path format!");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file. ");
        }
    }
}
