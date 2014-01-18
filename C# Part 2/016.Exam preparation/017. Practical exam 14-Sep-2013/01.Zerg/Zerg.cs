using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Zerg
{
    static string[] PopulateNums()
    {
        string[] nums = new String[15];
        nums[0] = "Rawr";
        nums[1] = "Rrrr";
        nums[2] = "Hsst";
        nums[3] = "Ssst";
        nums[4] = "Grrr";
        nums[5] = "Rarr";
        nums[6] = "Mrrr";
        nums[7] = "Psst";
        nums[8] = "Uaah";
        nums[9] = "Uaha";
        nums[10] = "Zzzz";
        nums[11] = "Bauu";
        nums[12] = "Djav";
        nums[13] = "Myau";
        nums[14] = "Gruh";

        return nums;
    }

    static Stack<string> SeparateTokens(string input)
    {
        Stack<string> tokens = new Stack<string>();
        int counter = 0;
        StringBuilder tempToken = new StringBuilder();

        while (counter < input.Length)
        {
            tempToken.Append(input[counter]);
            counter++;

            if (counter % 4 == 0)
            {
                tokens.Push(tempToken.ToString());
                tempToken.Clear();
            }
        }
        return tokens;
    }

    static long ConvertZergToDecimal(Stack<string> tokens, string[] nums)
    {
        long num = 0;

        long mult = 15;
        int power = 0;
        for (int i = tokens.Count - 1; i >= 0; i--)
        {
            string currToken = tokens.Peek();
            int decNum = Array.IndexOf(nums, tokens.Pop());
            num += (long) Math.Pow(mult, power) * decNum;
            power++;
        }
        return num;
    }


    static void Main()
    {
        string input = Console.ReadLine();


        string[] nums = PopulateNums();

        Stack<string> tokens = SeparateTokens(input);

        long res = ConvertZergToDecimal(tokens, nums);

        Console.WriteLine(res);
    }
}

