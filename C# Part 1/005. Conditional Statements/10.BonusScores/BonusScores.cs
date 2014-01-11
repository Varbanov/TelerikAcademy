using System;

class BonusScores
{
    /*Write a program that applies bonus scores to given scores in the range [1..9]. The program
     * reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10;
     * if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000.
     * If it is zero or if the value is not a digit, the program must report an error.
		Use a switch statement and at the end print the calculated new value in the console.
    */
    static void Main()
    {
        //data input
        int scores = 0;
        Console.Write("Please enter scores [1..9]: ");
        bool isNumber = int.TryParse(Console.ReadLine(), out scores);
        

        //solution
        if (isNumber)
        {
            switch (scores)
            {
                case 1:
                case 2:
                case 3:
                    scores *= 10;
                    Console.WriteLine("Your new scores are: {0}", scores);
                    break;
                case 4:
                case 5:
                case 6:
                    scores *= 100;
                    Console.WriteLine("Your new scores are: {0}", scores);
                    break;
                case 7:
                case 8:
                case 9:
                    scores *= 1000;
                    Console.WriteLine("Your new scores are: {0}", scores);
                    break;
                default:
                    Console.WriteLine("Error! The scores must be between 1 and 9!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Error! The scores must be a number!");
        }
    }
}

