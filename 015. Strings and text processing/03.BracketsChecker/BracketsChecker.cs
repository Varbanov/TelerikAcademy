using System;
using System.Text;
using System.Collections.Generic;

class BracketsChecker
{
    //03. Write a program to check if in a given expression the brackets are put correctly.
    //Example of correct expression: ((a+b)/5-d).
    //Example of incorrect expression: )(a+b)).

    static bool CheckBrackets(string expression)
    {
        bool isCorrect = true;
        int leftBracketsCounter = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                leftBracketsCounter++;
            }
            else if (expression[i] == ')')
            {
                if (leftBracketsCounter > 0)
                {
                    leftBracketsCounter--;
                }
                else
                {
                    isCorrect = false;
                }
            }
        }
        return isCorrect;
    }

    static void Main()
    {
        //input
        Console.Write("Please enter a string: ");
        string expression = Console.ReadLine();
        //solution
        Console.WriteLine("The expression entered is valid: {0}!", CheckBrackets(expression));
    }
}

