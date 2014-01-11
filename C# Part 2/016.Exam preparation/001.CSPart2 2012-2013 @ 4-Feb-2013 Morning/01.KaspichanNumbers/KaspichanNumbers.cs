using System;
using System.Collections.Generic;
using System.Text;

class KaspichanNumbers
{
    private static string[] PopulateKaspichanNumSystem()
    {
        string[] nums = new String[256];
        StringBuilder str = new StringBuilder();

        //populate single-letter numbers
        for (int i = 0; i <= 25; i++)
        {
            nums[i] = ((char)(65 + i)).ToString();
        }

        //populate single-letter array with small letters (for convenience)
        string[] smallLetters = new String[26];
        for (int i = 0; i < 26; i++)
        {
            smallLetters[i] = ((char)(97 + i)).ToString();
        }

        //populate Kaspichan numeral system numbers
        for (int i = 26; i <= 255; i++)
        {
            str.Clear();
            int tempNum = i;

            string left = smallLetters[(tempNum / 26) - 1];
            string right = nums[tempNum % 26];
            str.Append(left);
            str.Append(right);
            nums[i] = str.ToString();
        }

        return nums;
    }

    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());

        //special case when the number is 0
        if (input == 0)
        {
            Console.WriteLine("A");
            return;
        }

        string[] nums = PopulateKaspichanNumSystem();

        //solution
        StringBuilder str = new StringBuilder();
        List<String> listOfCurrNumSymbols = new List<string>();

        while (input > 0)
        {

            listOfCurrNumSymbols.Add(nums[input % 256]);
            input = input / 256;
        }

        listOfCurrNumSymbols.Reverse();

        foreach (var numSymbol in listOfCurrNumSymbols)
        {
            str.Append(numSymbol);
        }

        //output
        Console.WriteLine(str);
    }
}

