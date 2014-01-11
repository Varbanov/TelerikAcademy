using System;
using System.Text;
using System.Text.RegularExpressions;

class Brackets
{
    static int identCount = 0;

    static string RemoveEmptySpaceSequences(string input)
    {
        string pattern = @"\s+";
        string removed = Regex.Replace(input, pattern, " ");
        return removed;
    }

    static string FixJoroCode(int n, string identation)
    {
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string inputLine = RemoveEmptySpaceSequences(Console.ReadLine()).Trim();
            int index = 0;
            StringBuilder strInnerLine = new StringBuilder();

            while (index < inputLine.Length)
            {
                if (inputLine[index] == '{')
                {
                    for (int j = 0; j < identCount; j++)
                    {
                        output.Append(identation);
                    }
                    identCount++;
                    output.Append("{\n");
                    index++;
                    strInnerLine.Clear();
                }
                else if (inputLine[index] == '}')
                {
                    identCount--;
                    for (int j = 0; j < identCount; j++)
                    {
                        output.Append(identation);
                    }
                    output.Append("}\n");
                    index++;
                    strInnerLine.Clear();
                }
                else 
                {
                    while (index < inputLine.Length && inputLine[index] != '{' && inputLine[index] != '}')
                    {
                        strInnerLine.Append(inputLine[index]);
                        index++;
                    }

                    string innerLine = strInnerLine.ToString().Trim();
                    if (innerLine != String.Empty)
                    {
                        for (int j = 0; j < identCount; j++)
                        {
                            output.Append(identation);
                        }
                        output.Append(innerLine);
                        output.Append("\n");
                        strInnerLine.Clear();
                    }
                }
            }
        }

        return output.ToString();
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string identation = Console.ReadLine();
        Console.WriteLine(FixJoroCode(n, identation));
    }
}

