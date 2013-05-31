using System;

class DeckOfCards
{
    //Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
    //The cards should be printed with their English names. Use nested for loops and switch-case.
    static void Main()
    {
        // An easier and shorter solution (not corresponding to the recommendations above to use for-loops and switch-case) is:         
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] ranks = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                Console.WriteLine("{0} {1}", suit, rank);
            }
        }

        //A more complex solution corresponding to the recommendations provided in the task:

        //for (int suit = 0; suit < 4; suit++)
        //{
        //    for (int i = 2; i <= 10; i++)
        //    {
        //        switch (suit)
        //        {
        //            case 0: Console.Write("Club ");
        //                break;
        //            case 1: Console.Write("Diamond ");
        //                break;
        //            case 2: Console.Write("Heart ");
        //                break;
        //            case 3: Console.Write("Spade ");
        //                break;
        //        }
        //        Console.WriteLine("{0}", i);
        //    }

        //    for (int i = 0; i < 4; i++)
        //    {
        //        switch (suit)
        //        {
        //            case 0: Console.Write("Club ");
        //                break;
        //            case 1: Console.Write("Diamond ");
        //                break;
        //            case 2: Console.Write("Heart ");
        //                break;
        //            case 3: Console.Write("Spade ");
        //                break;
        //        }
        //        switch (i)
        //        {
        //            case 0: Console.WriteLine("Jack");
        //                break;
        //            case 1: Console.WriteLine("Queen");
        //                break;
        //            case 2: Console.WriteLine("King");
        //                break;
        //            case 3: Console.WriteLine("Ace");
        //                break;
        //        }
        //    }
        //}
    }
}

