using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecodeAndDecrypt
{
    static void Main()
    {
        string input = Console.ReadLine();
        int cypherLength = ExtractCypherLength(input);
        string messageAndCypher = input.Substring(0, input.Length - cypherLength.ToString().Length);
        string decoded = Decode(messageAndCypher);
        string message = decoded.Substring(0, decoded.Length - cypherLength);
        string cypher = decoded.Substring(message.Length);
        string decrypted = Decrypt(message, cypher);
        Console.WriteLine(decrypted);
    }

    static string Decrypt(string message, string cypher)
    {
        StringBuilder result = new StringBuilder();

        if (cypher.Length < message.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                int m = (int)message[i] - 65;
                int c = (int)cypher[i % cypher.Length] - 65;
                int xor = m ^ c;
                result.Append((char)(xor + 65));
            }
        }
        else
        {
            int excessivePassCount = cypher.Length - message.Length;
            int position = 0;
            for (int i = 0; i < message.Length; i++)
            {
                int m = (int)message[i] - 65;
                int c = (int)cypher[i] - 65;
                if (excessivePassCount > 0)
                {
                    int excesive = cypher[message.Length + position] - 65;
                    int xor = (m ^ c) ^ excesive;
                    position++;
                    excessivePassCount--;
                    result.Append((char)(xor + 65));
                }
                else
                {
                    int xor = m ^ c;
                    result.Append((char)(xor + 65));
                }
            }
        }

        return result.ToString();
    }

    private static int ExtractCypherLength(string input)
    {
        int counter = input.Length - 1;
        while (char.IsDigit(input[counter]))
        {
            counter--;
        }
        int result = int.Parse(input.Substring(counter + 1));
        return result;
    }

    private static string Decode(string input)
    {
        StringBuilder decoded = new StringBuilder();
        int position = 0;
        while (position < input.Length)
        {
            if (!char.IsDigit(input[position]))
            {
                decoded.Append(input[position]);
                position++;
            }
            else
            {
                StringBuilder tempDigits = new StringBuilder();
                while (position < input.Length && char.IsDigit(input[position]))
                {
                    tempDigits.Append(input[position]);
                    position++;
                }

                int count = int.Parse(tempDigits.ToString());

                if (count > 2)
                {
                    string str = new String(input[position], count);
                    decoded.Append(str);
                    position++;
                }
                else
                {
                    decoded.Append(tempDigits);
                }
            }
        }
        return decoded.ToString();
    }
}

