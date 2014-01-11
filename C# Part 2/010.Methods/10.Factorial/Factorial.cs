using System;
using System.Text;

class Factorial
{
    //Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method
    //that multiplies a number represented as array of digits by given integer number. 

    static string MultiplyIntsAsStrings(string num1, string num2)
    {
        string str1 = ReverseString(num1);
        string str2 = ReverseString(num2);
        string sum = "0";
        string operand1 = "0";


        int mind = 0;
        for (int i = 0; i < str2.Length; i++)
        {
            StringBuilder tempSum = new StringBuilder();
            //move every next sum operand a step more to the left
            for (int stepLeft = 1; stepLeft <= i; stepLeft++)
            {
                tempSum.Append("0");
            }

            for (int j = 0; j < str1.Length; j++)
            {
                //calculate current sum operand
                int currSum = Convert.ToInt32(str2[i].ToString()) * Convert.ToInt32(str1[j].ToString()) + mind;
                tempSum.Append(currSum % 10).ToString();
                if (currSum > 9)
                {
                    mind = currSum / 10;
                }
                else
                {
                    mind = 0;
                }
            }

            if (mind != 0)
            {
                tempSum.Append(mind);
                mind = 0;
            }
            operand1 = ReverseString(tempSum.ToString());
            sum = AddIntegersAsStrings(sum, operand1);
        }
        return sum;
    }

    static string ReverseString(string str)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversed.Append(str[i]);
        }
        return reversed.ToString();
    }

    static string AddIntegersAsStrings(string num1, string num2)
    {
        //reverse numbers
        string str1 = ReverseString(num1);
        string str2 = ReverseString(num2);
        //solution (now we work with str1 and str2 only)
        StringBuilder sum = new StringBuilder();
        int shorterLength = str2.Length < str1.Length ? str2.Length : str1.Length;
        int mind = 0;
        for (int i = 0; i < shorterLength; i++)
        {
            //sum each two adjacent digits and process their sum
            int currSum = Convert.ToInt32(str1[i].ToString()) + Convert.ToInt32(str2[i].ToString()) + mind;
            sum.Append((currSum % 10).ToString());
            if (currSum > 9)
            {
                mind = currSum / 10;
            }
            else
            {
                mind = 0;
            }
        }
        //process the remaining digits of the longer number if any
        int longerLength = str2.Length > str1.Length ? str2.Length : str1.Length;
        bool firstIsLonger = str1.Length > str2.Length;
        bool secondIsLonger = str1.Length < str2.Length;
        if (firstIsLonger)
        {
            for (int i = shorterLength; i < longerLength; i++)
            {
                int currSum = Convert.ToInt32(str1[i].ToString()) + mind;
                sum.Append((currSum % 10).ToString());
                if (currSum > 9)
                {
                    mind = currSum / 10;
                }
                else
                {
                    mind = 0;
                }
            }
        }
        else if (secondIsLonger)
        {
            for (int i = shorterLength; i < longerLength; i++)
            {
                int currSum = Convert.ToInt32(str2[i].ToString()) + mind;
                sum.Append((currSum % 10).ToString());
                if (currSum > 9)
                {
                    mind = currSum / 10;
                }
                else
                {
                    mind = 0;
                }
            }
        }

        //if the sum is longer than any of the operands
        if (mind != 0)
        {
            sum.Append(mind);
        }

        return ReverseString(sum.ToString());
    }

    static void Main()
    {
        string factorial = "1";
        for (int i = 1; i <= 100; i++)
        {
            factorial = MultiplyIntsAsStrings(factorial, i.ToString());
        }
        Console.WriteLine("100! =\n{0}\n", factorial);
        //check if 100! is correct
        Console.WriteLine("Check: {0}", factorial == "93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000");

    }
}
