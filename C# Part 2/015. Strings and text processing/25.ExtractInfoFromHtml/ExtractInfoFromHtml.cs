using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

class ExtractInfoFromHtml
{
    //25. Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
    /*<html>
      <head><title>News</title></head>
      <body><p><a href="http://academy.telerik.com">Telerik
        Academy</a>aims to provide free real-world practical
        training for young people who want to turn into
        skillful .NET software engineers.</p></body>
      </html>
    */

    static string ExtractTitleAndBody(string path)
    {
        StreamReader reader = new StreamReader(path, Encoding.UTF8);
        string text;
        string title;

        //extract html document
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        //extract title
        Regex titleRegex = new Regex(@"title\s*>(.+?)<\s*/title");
        Match titleMatch = titleRegex.Match(text);
        if (titleMatch.Success)
            title = titleMatch.Groups[1].Value;
        else
            title = "n/a";
        
        //extract body
        Regex bodyRegex = new Regex(@"body\s*>(.*?)<\s*/body", RegexOptions.Singleline);
        Match bodyMatch = bodyRegex.Match(text);
        string body = bodyMatch.Groups[1].Value;

        StringBuilder bodyText = new StringBuilder();
        bool open = false;
        int index = 0;

        while (index < body.Length)
        {
            //scan all symbols and extract only those tha are outside tags (>symbols to extract<)
            if (!open)
            {
                while (index < body.Length && body[index] != '<' && body[index] != '>')
                {
                    bodyText.Append(body[index]);
                    index++;
                }
            }
            if (index < body.Length && body[index] == '<')
            {
                open = true;
                bodyText.Append(" ");
            }

            if (index < body.Length && body[index] == '>')
            {
                open = false;
            }

            index++;
        }
        //output
        return String.Format("Title: {0}\nBody: {1}", title, bodyText);
    }

    static void ConsoleSettings()
    {
        Console.BufferHeight = 1500;
        Console.BufferWidth = 200;
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void Main()
    {
        ConsoleSettings();
       
        //keep in mind the html file is located in the main directory of the current project
        string path = @"..\..\telerik.htm"; //this is the up-to-date html file of http://academy.telerik.com/
        Console.WriteLine(ExtractTitleAndBody(path));
    }

    
}
