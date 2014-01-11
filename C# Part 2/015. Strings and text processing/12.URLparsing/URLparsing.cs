using System;
using System.Text;
using System.Text.RegularExpressions;

class URLparsing
{
    //12. Write a program that parses an URL address given in the format:
    //[protocol]://[server]/[resource]
    //and extracts from it the [protocol], [server] and [resource] elements. 
    //For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
	//[protocol] = "http"
	//[server] = "www.devbg.org"
	//[resource] = "/forum/index.php"

    static void ParseURL(string url)
    {
        //extraxt protocol
        Regex regexProtocol = new Regex(@"(\S*)://");
        Match matchProtocol = regexProtocol.Match(url);
        if (!matchProtocol.Success)
        {
            throw new ArgumentException("Invalid URL (check the protocol name)!");
        }

        string protocol = matchProtocol.Groups[1].ToString();
        //extract server
        Regex regexServer = new Regex(@"://(\S*?)/");
        Match matchServer = regexServer.Match(url);
        if (!matchServer.Success)
        {
            throw new ArgumentException("Invalid URL (check the server name)!");
        }

        string server = matchServer.Groups[1].ToString();
        //extract resource
        Regex regexResource = new Regex(@"[^/](/{1}[^/]\S*)", RegexOptions.RightToLeft);
        Match matchResource = regexResource.Match(url);
        if (!matchResource.Success)
        {
            throw new ArgumentException("Invalid URL (check the resource name)!");
        }

        string resource = matchResource.Groups[1].ToString();
        Console.WriteLine("[protocol] {0} \n[server] {1} \n[resource] {2}\n", protocol, server, resource);
    }

    static void Main()
    {
        //Console.Write("Please enter an url address:");
        string url = "http://www.devbg.org/forum/index.php"; //Console.ReadLine();
        ParseURL(url);
    }
}

