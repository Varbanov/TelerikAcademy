using System;

class IsThirdDigitSeven
{
    /*Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true
    */
    static void Main()
    {
        int num;

        //integer input
        do
        {
            Console.Write("Please enter an integer to check: ");
        }
        while (!int.TryParse(Console.ReadLine(), out num));

        bool thirdDigitIsSeven = false;

        //expression
        if ((num / 100) % 10 == 7)
        {
            thirdDigitIsSeven = true;
        }

        Console.WriteLine(thirdDigitIsSeven);
    }
}

