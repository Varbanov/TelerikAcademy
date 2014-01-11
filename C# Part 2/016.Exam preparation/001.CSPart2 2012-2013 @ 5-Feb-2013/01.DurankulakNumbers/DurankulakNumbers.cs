using System;
using System.Collections.Generic;
using System.Text;

class DurankulakNumbers
{

    static string[] PopulateDurankulakDigits()
    {
        string[] durankulak = new String[168];
        int capLetter = 65;
        for (int i = 0; i <= 25; i++)
        {
            durankulak[i] = ((char)capLetter).ToString();
            capLetter++;
        }

        int smallLetter = 97;
        capLetter = 65;
        StringBuilder number = new StringBuilder(2);
        int alphabetCounter = 0;

        for (int i = 26; i <= 167; i++)
        {
            number.Clear();
            number.Append(((char)smallLetter).ToString());
            number.Append(((char)capLetter).ToString());
            durankulak[i] = number.ToString();

            capLetter++;
            if (capLetter > 90)
            {
                capLetter = 65;
            }
            alphabetCounter++;
            if (alphabetCounter % 26 == 0)
            {
                alphabetCounter = 0;
                smallLetter++;
            }
        }
        

        return durankulak;
    }

    static Stack<string> SeparateDurankulakDigits(string durankulakNum)
    {
        Stack<string> digits = new Stack<string>();
        StringBuilder currDigit = new StringBuilder();

        for (int i = 0; i < durankulakNum.Length; i++)
        {
            //single capital letter
            if (durankulakNum[i] < (char) 92 && (i == 0 || durankulakNum[i -1] < (char) 92))
            {
                digits.Push(durankulakNum[i].ToString());
            }
            else
            {
                currDigit.Append(durankulakNum[i]);
                currDigit.Append(durankulakNum[i + 1]);
                digits.Push(currDigit.ToString());
                currDigit.Clear();
                i++;
            }

            
        }
        return digits;
    }

    static ulong ConvertDurankulakToDecimal(Stack<string> tokens, string[] durankulakDigits)
    {
        ulong num = 0;
        int mult = 168;
        int power = 0;
        for (int i = tokens.Count -1; i >= 0; i--)
        {
            string currToken = tokens.Peek();
            ulong decNum = (ulong) Array.IndexOf(durankulakDigits, tokens.Pop());
            num += (ulong)Math.Pow(mult, power) * decNum;
            power++;
        }
        return num;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        var tokens = SeparateDurankulakDigits(input);
        string[] durankulak = PopulateDurankulakDigits();

        //for (int i = 0; i < durankulak.Length; i++)
        //{
        //    Console.WriteLine(i + " " + durankulak[i]);
        //}

        Console.WriteLine(ConvertDurankulakToDecimal(tokens, durankulak));
    }
}

