using System;

class ReturnLastDigitClass
{
    //Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".
    static string ReturnLastDigit(int num)
    {
        int digit = num % 10;
        switch (digit)
        {
            case 1: return "one";
                break;
            case 2: return "two";
                break;
            case 3: return "three";
                break;
            case 4: return "four";
                break;
            case 5: return "five";
                break;
            case 6: return "six";
                break;
            case 7: return "seven";
                break;
            case 8: return "eight";
                break;
            case 9: return "nine";
                break;
            default: return "zero";
                break;
        }
    }

    static void Main()
    {
        string result = ReturnLastDigit(12309);
        Console.WriteLine(result);
    }
}