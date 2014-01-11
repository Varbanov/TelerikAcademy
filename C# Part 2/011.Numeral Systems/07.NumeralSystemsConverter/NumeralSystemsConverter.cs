using System;
using System.Text;
    class NumeralSystemsConverter
    {
        //07.Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

        static int ConvertFromSToDecimal(string num, int s)
        {
            //input check
            if (s > 16 || s < 2)
            {
                throw new ArgumentOutOfRangeException("The base s must be in the range [2..16]!");
            }

            //convert to decimal
            int sum = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                char digit = num[i];
                if ((int)digit >= 48 || (int)digit <= 57)
                {
                    sum += int.Parse(digit.ToString()) * Pow(s, num.Length - 1 - i);
                }
                else
                {
                    switch (digit)
                    {
                        case 'A':
                        case 'a':
                            sum += 10 * Pow(s, num.Length - 1 - i);
                            break;
                        case 'B':
                        case 'b':
                            sum += 11 * Pow(s, num.Length - 1 - i);
                            break;
                        case 'C':
                        case 'c':
                            sum += 12 * Pow(s, num.Length - 1 - i);
                            break;
                        case 'D':
                        case 'd':
                            sum += 13 * Pow(s, num.Length - 1 - i);
                            break;
                        case 'E':
                        case 'e':
                            sum += 14 * Pow(s, num.Length - 1 - i);
                            break;
                        case 'F':
                        case 'f':
                            sum += 15 * Pow(s, num.Length - 1 - i);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("The number entered is invalid! It must consist only of [0..9] or [A..F] or [a..f]!");
                    }
                }
            }
            return sum;
        }

        static string ConvertFromDecimalToD(int num, int d)
        {
            StringBuilder reversed = new StringBuilder();
            while (num > 0)
            {
                int digit = num % d;
                switch (digit)
                {
                    case 10: reversed.Append("A");
                        break;
                    case 11: reversed.Append("B");
                        break;
                    case 12: reversed.Append("C");
                        break;
                    case 13: reversed.Append("D");
                        break;
                    case 14: reversed.Append("E");
                        break;
                    case 15: reversed.Append("F");
                        break;
                    default: reversed.Append(digit.ToString());
                        break;
                }
                num /= d;
            }
            //reversing
            StringBuilder result = new StringBuilder();
            for (int i = reversed.Length - 1; i >= 0; i--)
            {
                result.Append(reversed[i]);
            }
            return result.ToString();
        }

        static int Pow(int num, int pow)
        {
            //calculate power of a number
            int result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }

        static void Main()
        {
            //data input
            int s, d;
            do
	        {
                Console.Write("Please enter an input numeral system base \"s\" in the range [2...16]: ");
	                 
	        } while (!int.TryParse(Console.ReadLine(), out s) || s < 2 || s > 16);

            do
            {
                Console.Write("Please enter an output numeral system base \"d\" in the range [2...16]: ");
	        } while (!int.TryParse(Console.ReadLine(), out d) || d < 2 || d > 16);
            
            Console.Write("Please enter the input number in base {0}: ", s);
            string num = Console.ReadLine();
            int toDecimal = ConvertFromSToDecimal(num, s);
            string result = ConvertFromDecimalToD(toDecimal, d);
            Console.WriteLine("Result: {0} \nBase: {1}", result, d);
        }
    }
