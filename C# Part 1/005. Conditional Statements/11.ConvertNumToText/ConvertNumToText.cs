using System;

class ConvertNumToText
{
    /* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven"
    */
    static void Main()
    {
        //input
        int num;
        do
        {
            Console.Write("Please an integer [0..999]: ");
        } while (!int.TryParse(Console.ReadLine(), out num) || num < 0);

        //solution
        int thirdDigit = num / 100;
        int secondDigit = (num % 100) / 10;
        int firstdigit = num % 10;

        if (num == 0)
        {
            Console.Write("zero");
        }

        if (thirdDigit != 0) //100-999
        {
            switch (thirdDigit)
            {
                case 1: Console.Write("one hundred ");
                    break;
                case 2: Console.Write("two hundred ");
                    break;
                case 3: Console.Write("three hundred ");
                    break;
                case 4: Console.Write("four hundred ");
                    break;
                case 5: Console.Write("five hundred ");
                    break;
                case 6: Console.Write("six hundred ");
                    break;
                case 7: Console.Write("seven hundred ");
                    break;
                case 8: Console.Write("eight hundred ");
                    break;
                case 9: Console.Write("nine hundred ");
                    break;
            }
        }

        switch (secondDigit)
        {
            case 0:
                if (thirdDigit != 0) //101-109, 201 - 209, 301 - 309 etc.
                {
                    switch (firstdigit)
                    {
                        case 1: Console.Write("and one");
                            break;
                        case 2: Console.Write("and two");
                            break;
                        case 3: Console.Write("and three");
                            break;
                        case 4: Console.Write("and four");
                            break;
                        case 5: Console.Write("and five");
                            break;
                        case 6: Console.Write("and six");
                            break;
                        case 7: Console.Write("and seven");
                            break;
                        case 8: Console.Write("and eight");
                            break;
                        case 9: Console.Write("and nine");
                            break;
                    }
                }
                break;
            case 1: 
                switch (firstdigit) // 110-119, 210-219 etc.
                {
                    case 0: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("ten");
                        break;
                    case 1: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.WriteLine("eleven");
                        break;
                    case 2: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("twelve");
                        break;
                    case 3: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("thirteen");
                        break;
                    case 4: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("fourteen");
                        break;
                    case 5: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("fifteen");
                        break;
                    case 6: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("sixteen");
                        break;
                    case 7: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("seventeen");
                        break;
                    case 8: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.Write("eighteen");
                        break;
                    case 9: 
                        if (num > 19)
                        {
                            Console.Write("and ");
                        }
                        Console.WriteLine("nineteen");
                        break;
                }
                break;
            case 2: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("twenty ");
                break;
            case 3: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("thirty ");
                break;
            case 4: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("fourty ");
                break;
            case 5: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("fifty ");
                break;
            case 6: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("sixty ");
                break;
            case 7: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("seventy ");
                break;
            case 8: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("eighty ");
                break;
            case 9: 
                if (thirdDigit != 0)
                {
                    Console.Write("and ");
                } 
                Console.Write("ninety ");
                break;
        }

        if ((secondDigit == 0 && thirdDigit ==0) || (firstdigit != 0 && secondDigit >= 2)) //1-9 && 120-199, 220-299, 320-399 etc.
        {
            switch (firstdigit)
            {
                case 1: Console.Write("one");
                    break;
                case 2: Console.Write("two");
                    break;
                case 3: Console.Write("three");
                    break;
                case 4: Console.Write("four");
                    break;
                case 5: Console.Write("five");
                    break;
                case 6: Console.Write("six");
                    break;
                case 7: Console.Write("seven");
                    break;
                case 8: Console.Write("eight");
                    break;
                case 9: Console.Write("nine");
                    break;
            }
        }

        Console.WriteLine();
    }
}

