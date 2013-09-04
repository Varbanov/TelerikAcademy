using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceHTMLTags
{
    //15. Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> 
    //with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
    //
    //<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. 
    //Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    //
    //<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
    //Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

    static void ReplaceTags(string inputHtml)
    {
        //use string.Replace to replace opening tags, closing tags and ">" of the opening tags
        string res = inputHtml.Replace(@"<a href=""", "[URL=");
        res = res.Replace(@"</a>", "[/URL]");
        res = res.Replace(@""">", "]");
        Console.WriteLine(res);
    }

    static void Main()
    {
        string input = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        ReplaceTags(input);
    }
}

