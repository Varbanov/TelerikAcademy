using System;
using System.Text;

class AddIntegersAsArrays
{
    //Write a method that adds two positive integer numbers represented as arrays of digits
    //(each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each
    //of the numbers that will be added could have up to 10 000 digits.
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
        //keep in mind the method works with numbers written
        //as strings in the natural way one would do it,
        //for instance the argument "963" is the number 963, not the number 369
        string sum = AddIntegersAsStrings("99", "99");
        Console.WriteLine(sum);
    }
}
