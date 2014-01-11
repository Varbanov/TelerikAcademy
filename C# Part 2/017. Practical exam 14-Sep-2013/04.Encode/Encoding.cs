using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Encoding
{

    static string Encrypt(string message, string cypher)
    {
        StringBuilder encrypted = new StringBuilder();
        if (message.Length == cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                int messageCode = (int) message[i] - 65;
                int cypherCode = (int)cypher[i] - 65;

                int xor = messageCode ^ cypherCode;
                xor += 65;
                char newChar = (char) xor;
                encrypted.Append(newChar);
            }
        }
        else if (message.Length > cypher.Length)
        {
            int cypherIndex = 0;
            for (int i = 0; i < message.Length; i++)
            {
                int messageCode = (int)message[i] - 65;
                int cypherCode = (int)cypher[cypherIndex] - 65;
                
                cypherIndex++;
                if (cypherIndex == cypher.Length)
                {
                    cypherIndex = 0;
                }

                int xor = messageCode ^ cypherCode;
                xor += 65;
                char newChar = (char)xor;
                encrypted.Append(newChar);
            }
        }
        //kofti sluchai
        else 
        {
            int lastIndex = cypher.Length - (cypher.Length - message.Length);
            int excessiveLength = cypher.Length - message.Length;

            for (int i = 0; i < excessiveLength; i++)
            {
                int messageCode = (int)message[i] - 65;
                int cypherCode = (int)cypher[i] - 65;
                int lasIndexCypherCode = (int)cypher[lastIndex] - 65;

                int xor = (messageCode ^ cypherCode) ^ lasIndexCypherCode;
                lastIndex++;
                xor += 65;
                char newChar = (char)xor;
                encrypted.Append(newChar);
            }

            for (int i = excessiveLength; i < message.Length; i++)
            {
                int messageCode = (int)message[i] - 65;
                int cypherCode = (int)cypher[i] - 65;

                int xor = (messageCode ^ cypherCode);
                xor += 65;
                char newChar = (char)xor;
                encrypted.Append(newChar);
                
            }

            //return Encrypt(encrypted.ToString(), newCypher.ToString());
        }

        return encrypted.ToString();
    }

    static string Encode(string input)
    {
        StringBuilder result = new StringBuilder();
        int counter = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                counter++;
            }
            else
            {
                if (counter > 2)
                {
                    result.Append(counter);
                    result.Append(input[i - 1]);
                }
                else
                {
                    string str = new String(input[i - 1], counter);
                    result.Append(str);
                }
                counter = 1;
            }
        }

        if (counter > 2)
        {
            result.Append(counter);
            result.Append(input[input.Length - 1]);
        }
        else
        {
            string str = new String(input[input.Length -1], counter);
            result.Append(str);
        }


        return result.ToString();
    }

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        string encrypted = Encrypt(message, cypher);

        string toEncode = encrypted + cypher;
        string encoded = Encode(toEncode) + cypher.Length;
        Console.WriteLine(encoded);


        //Console.WriteLine(encrypted);


    }
}

