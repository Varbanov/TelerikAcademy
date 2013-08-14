using System;
using System.Collections.Generic;
using System.Text;

class ShuntingYardMathExpression
{
    /*07. Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
    Real numbers, e.g. 5, 18.33, 3.14159, 12.6
    Arithmetic operators: +, -, *, / (standard priorities)
    Mathematical functions: ln(x), sqrt(x), pow(x,y)
    Brackets (for changing the default priorities)
	Examples:
     
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
     
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
     
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".*/

    static List<char> digits = new List<char> {'0','1','2','3','4','5','6','7','8', '9', '0'};
    static List<char> operators = new List<char> { '+', '-', '/', '*'};

    static List<string> SeparateTokens(string input)
    {
        input = input.Replace(" ", String.Empty);
        List<string> result = new List<string>();
        StringBuilder currToken = new StringBuilder();

        // (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
        for (int i = 0; i < input.Length; i++)
        {
            //if "minus" is an unary oprator, then append it to currToken
            if (input[i] == '-' && (i == 0 || input[i-1] == '(' || input[i - 1] == ','))
            {
                currToken.Append(input[i]);
            }
            else if (digits.Contains(input[i]))
            {
                currToken.Append(input[i]);
            }
            else if (input[i] == '.')
            {
                currToken.Append(".");
            }
            //if a whole number is finished, add it to result and clear currToken to proceed with next number
            else if (currToken.Length > 0)
            {
                result.Add(currToken.ToString());
                currToken.Clear();
                i--;
            }
            else if (input[i] == '(' || input[i] == ')')
            {
                result.Add(input[i].ToString());
            }
            else if (operators.Contains(input[i]))
            {
                result.Add(input[i].ToString());
            }
            //if digit of a function is reached
            else if (i + 1 < input.Length && input.Substring(i, 2).ToLower() == "ln")
            {
                result.Add("ln");
                i++;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                result.Add("pow");
                i += 2;
            }
            else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                result.Add("sqrt");
                i += 3;
            }
            else if (input[i] == ',')
            {
                result.Add(",");
            }
            else
            {
                throw new ArgumentException("Invalid expression!");
            }
        }
            //if input[input.length-1] == number, then add the last number
            if (currToken.Length != 0)
            {
                result.Add(currToken.ToString());
            }
            return result;
    }

    static int PrecedenceOfOperators(string arithmeticOper)
    {
        if (arithmeticOper == "+" || arithmeticOper == "-")
        {
            return 1;
        }
        else if (arithmeticOper == "*" || arithmeticOper == "/")
        {
            return 2;
        }
        else
        {
            throw new ArgumentException("Invalid input operator");
        }
    }

    static Queue<string> ShuntingYardConvertToRPN(List<string> input)
    {
        Queue<string> outputQueue = new Queue<string>();
        Stack<string> outputStack = new Stack<string>();

        for (int i = 0; i < input.Count; i++)
        {
            string currToken = input[i];
            double d;
            if (double.TryParse(currToken, out d))
            {
                //If the token is a number, then add it to the output queue.
                outputQueue.Enqueue(currToken);
            }
            else if (currToken.ToLower() == "ln" || currToken == "sqrt" || currToken.ToLower() == "pow")
            {
                //If the token is a function token, then push it onto the stack.
                outputStack.Push(currToken);
            }
            else if (currToken == ",")
            {
                //If the token is a function argument separator (e.g., a comma):
                if (outputStack.Contains("("))
                {
                    while (outputStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(outputStack.Pop());

                    }
                }
                else
                {
                    throw new ArgumentException("Invalid expression! Parathesis mismatch or function misspelled!");
                }
            }
            else if (currToken == "+" || currToken == "-" || currToken == "*" || currToken == "/")
            {
                //If the token is an operator, o1, then:
                while (outputStack.Count != 0 && (outputStack.Peek() == "-" || outputStack.Peek() == "+" || outputStack.Peek() == "*" || outputStack.Peek() == "/")
                    && PrecedenceOfOperators(currToken) <= PrecedenceOfOperators(outputStack.Peek()))
                {
                    outputQueue.Enqueue(outputStack.Pop());
                }
                outputStack.Push(currToken);



            }
            else if (currToken == "(")
            {
                outputStack.Push(currToken);
            }
            else if (currToken == ")")
            {
                if (!outputStack.Contains("(") || outputStack.Count == 0)
                {
                    throw new ArgumentException("Error! Mismatched brackets!");
                }
                else
                {
                    while (outputStack.Peek() != "(")
                    {
                        outputQueue.Enqueue(outputStack.Pop());
                    }
                    outputStack.Pop();
                    if (outputStack.Count != 0 && (outputStack.Peek() == "ln" || outputStack.Peek() == "pow" || outputStack.Peek() == "sqrt"))
                    {
                        outputQueue.Enqueue(outputStack.Pop());
                    }
                }
            }
            if (i == input.Count - 1)
            {
                while (outputStack.Contains("+") || outputStack.Contains("-") || outputStack.Contains("*") || outputStack.Contains("/"))
                {
                    if (outputStack.Peek() == "(" || outputStack.Peek() == ")")
                    {
                        throw new ArgumentException("Error! Mismatched paratheses!");
                    }
                    else
                    {
                        outputQueue.Enqueue(outputStack.Pop());
                    }
                }
            }
        }
        return outputQueue;
    }

    static double CalculateRPN(Queue<string> rpnInput)
    {
        Stack<double> outputStack = new Stack<double>();

        double d;
        while (rpnInput.Count != 0)
        {
            string currToken = rpnInput.Dequeue();

            if (double.TryParse(currToken, out d))
            {
                outputStack.Push(d);
            }
            else
            {
                if (currToken == "-")
                {
                    if (outputStack.Count < 2)
                    {
                        throw new ArgumentException("Insufficient values for operator \"-\" ");
                    }

                    double substr = -outputStack.Pop();
                    substr += outputStack.Pop();
                    outputStack.Push(substr);
                }
                else if (currToken == "+")
                {
                    if (outputStack.Count < 2)
                    {
                        throw new ArgumentException("Insufficient values for operator \"+\" ");
                    }
                    double sum = outputStack.Pop();
                    sum += outputStack.Pop();
                    outputStack.Push(sum);
                }
                else if (currToken == "*")
                {
                    if (outputStack.Count < 2)
                    {
                        throw new ArgumentException("Insufficient values for operator \"*\" ");
                    }
                    double mult = outputStack.Pop();
                    mult *= outputStack.Pop();
                    outputStack.Push(mult);
                }
                else if (currToken == "/")
                {
                    if (outputStack.Count < 2)
                    {
                        throw new ArgumentException("Insufficient values for operator \"/\" ");
                    }
                    double secondNum = outputStack.Pop();
                    double div = outputStack.Pop() / secondNum;
                    outputStack.Push(div);
                }
                else if (currToken == "ln")
                {
                    if (outputStack.Count < 1)
                    {
                        throw new ArgumentException("Insufficient values for operator \"/\" ");
                    }
                    double num = outputStack.Pop();
                    double res = Math.Log(num);
                    outputStack.Push(res);
                }
                else if (currToken == "pow")
                {
                    if (outputStack.Count < 2)
                    {
                        throw new ArgumentException("Insufficient values for operator \"/\" ");
                    }
                    double second = outputStack.Pop();
                    double first = outputStack.Pop();
                    double res = Math.Pow(first, second);
                    outputStack.Push(res);
                }
                else if (currToken == "sqrt")
                {
                    if (outputStack.Count < 1)
                    {
                        throw new ArgumentException("Insufficient values for operator \"/\" ");
                    }

                    double res = Math.Sqrt(outputStack.Pop());
                    outputStack.Push(res);
                }
            }
        }

        if (outputStack.Count == 1)
        {
            return outputStack.Pop();
        }
        else
        {
            throw new ArgumentException("The input has excessive values!");
        }


    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter a mathematical expression:");
            string input = Console.ReadLine();
            List<string> inputTokens = SeparateTokens(input);
            Queue<string> rpn = ShuntingYardConvertToRPN(inputTokens);
            double res = CalculateRPN(rpn);
            Console.WriteLine("Result: {0}", res);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}

