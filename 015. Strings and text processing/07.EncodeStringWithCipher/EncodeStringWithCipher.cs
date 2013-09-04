using System;
using System.Text;

class EncodeStringWithCipher
{
    //07. Write a program that encodes and decodes a string using given encryption key (cipher). The key consists
    //of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation 
    //over the first letter of the string with the first of the key, the second – with the second, etc. 
    //When the last key character is reached, the next is the first

    static string EncodeDecodeString(string str, string cipher)
    {
        int strCounter = 0;
        int cipherCounter = 0;
        StringBuilder encoded = new StringBuilder();

        while (strCounter < str.Length)
        {
            if (cipherCounter < cipher.Length)
            {
                encoded.Append((char)(str[strCounter] ^ cipher[cipherCounter]));
            }
            else
            {
                cipherCounter = 0;
                encoded.Append((char)(str[strCounter] ^ cipher[cipherCounter]));
            }
            strCounter++;
            cipherCounter++;
        }

        return encoded.ToString();
    }


    static void Main()
    {
        //input
        string input = "ABCD"; //Console.ReadLine();
        string cipher = "ab"; //Console.ReadLine();
        var encoded = EncodeDecodeString(input, cipher);
        //output
        Console.WriteLine("Original: " + input);
        Console.WriteLine("Encoded: " + encoded);
        Console.WriteLine("Decoded: " + EncodeDecodeString(encoded, cipher));
    }
}

