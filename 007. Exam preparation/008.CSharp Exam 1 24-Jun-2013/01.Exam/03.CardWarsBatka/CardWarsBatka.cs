using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CardWarsBatka
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int totalScores1 = 0;
        int totalScores2 = 0;
        int gamesWon1 = 0;
        int gamesWon2 = 0;


        while (n != 0)
        {
            int currScores1 = 0;
            int currScores2 = 0;
            string first1 = Console.ReadLine();
            string first2 = Console.ReadLine();
            string first3 = Console.ReadLine();
            string second1 = Console.ReadLine();
            string second2 = Console.ReadLine();
            string second3 = Console.ReadLine();
            int xCounter1 = 0;
            int xCounter2 = 0;
            int zCounter1 = 0;
            int yCounter1 = 0;
            int zCounter2 = 0;
            int yCounter2 = 0;

            switch (first1)
            {
                case "2": currScores1 += 10;
                    break;
                case "3": currScores1 += 9;
                    break;
                case "4": currScores1 += 8;
                    break;
                case "5": currScores1 += 7;
                    break;
                case "6": currScores1 += 6;
                    break;
                case "7": currScores1 += 5;
                    break;
                case "8": currScores1 += 4;
                    break;
                case "9": currScores1 += 3;
                    break;
                case "10": currScores1 += 2;
                    break;
                case "A": currScores1 += 1;
                    break;
                case "J": currScores1 += 11;
                    break;
                case "Q": currScores1 += 12;
                    break;
                case "K": currScores1 += 13;
                    break;
                case "Z": zCounter1++;
                    break;
                case "Y": yCounter1++;
                    break;
                case "X": xCounter1++;
                    break;
            }

            switch (first2)
            {
                case "2": currScores1 += 10;
                    break;
                case "3": currScores1 += 9;
                    break;
                case "4": currScores1 += 8;
                    break;
                case "5": currScores1 += 7;
                    break;
                case "6": currScores1 += 6;
                    break;
                case "7": currScores1 += 5;
                    break;
                case "8": currScores1 += 4;
                    break;
                case "9": currScores1 += 3;
                    break;
                case "10": currScores1 += 2;
                    break;
                case "A": currScores1 += 1;
                    break;
                case "J": currScores1 += 11;
                    break;
                case "Q": currScores1 += 12;
                    break;
                case "K": currScores1 += 13;
                    break;
                case "Z": zCounter1++;
                    break;
                case "Y": yCounter1++;
                    break;
                case "X": xCounter1++;
                    break;
            }

            switch (first3)
            {
                case "2": currScores1 += 10;
                    break;
                case "3": currScores1 += 9;
                    break;
                case "4": currScores1 += 8;
                    break;
                case "5": currScores1 += 7;
                    break;
                case "6": currScores1 += 6;
                    break;
                case "7": currScores1 += 5;
                    break;
                case "8": currScores1 += 4;
                    break;
                case "9": currScores1 += 3;
                    break;
                case "10": currScores1 += 2;
                    break;
                case "A": currScores1 += 1;
                    break;
                case "J": currScores1 += 11;
                    break;
                case "Q": currScores1 += 12;
                    break;
                case "K": currScores1 += 13;
                    break;
                case "Z": zCounter1++;
                    break;
                case "Y": yCounter1++;
                    break;
                case "X": xCounter1++;
                    break;
            }

 //SECONDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
            switch (second1)
            {
                case "2": currScores2 += 10;
                    break;
                case "3": currScores2 += 9;
                    break;
                case "4": currScores2 += 8;
                    break;
                case "5": currScores2 += 7;
                    break;
                case "6": currScores2 += 6;
                    break;
                case "7": currScores2 += 5;
                    break;
                case "8": currScores2 += 4;
                    break;
                case "9": currScores2 += 3;
                    break;
                case "10": currScores2 += 2;
                    break;
                case "A": currScores2 += 1;
                    break;
                case "J": currScores2 += 11;
                    break;
                case "Q": currScores2 += 12;
                    break;
                case "K": currScores2 += 13;
                    break;
                case "Z": zCounter2++;
                    break;
                case "Y": yCounter2++;
                    break;
                case "X": xCounter2++;
                    break;
            }

            switch (second2)
            {
                case "2": currScores2 += 10;
                    break;
                case "3": currScores2 += 9;
                    break;
                case "4": currScores2 += 8;
                    break;
                case "5": currScores2 += 7;
                    break;
                case "6": currScores2 += 6;
                    break;
                case "7": currScores2 += 5;
                    break;
                case "8": currScores2 += 4;
                    break;
                case "9": currScores2 += 3;
                    break;
                case "10": currScores2 += 2;
                    break;
                case "A": currScores2 += 1;
                    break;
                case "J": currScores2 += 11;
                    break;
                case "Q": currScores2 += 12;
                    break;
                case "K": currScores2 += 13;
                    break;
                case "Z": zCounter2++;
                    break;
                case "Y": yCounter2++;
                    break;
                case "X": xCounter2++;
                    break;
            }

            switch (second3)
            {
                case "2": currScores2 += 10;
                    break;
                case "3": currScores2 += 9;
                    break;
                case "4": currScores2 += 8;
                    break;
                case "5": currScores2 += 7;
                    break;
                case "6": currScores2 += 6;
                    break;
                case "7": currScores2 += 5;
                    break;
                case "8": currScores2 += 4;
                    break;
                case "9": currScores2 += 3;
                    break;
                case "10": currScores2 += 2;
                    break;
                case "A": currScores2 += 1;
                    break;
                case "J": currScores2 += 11;
                    break;
                case "Q": currScores2 += 12;
                    break;
                case "K": currScores2 += 13;
                    break;
                case "Z": zCounter2++;
                    break;
                case "Y": yCounter2++;
                    break;
                case "X": xCounter2++;
                    break;
            }

//SOLUTIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN

// X card
            if (xCounter1 > 0 && xCounter2 == 0)
            {
                Console.WriteLine("X card drawn! Player one wins the match!"); 
                return;
            }
            else if (xCounter2 > 0 && xCounter1 == 0)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }
            else if (xCounter1 > 0 && xCounter2 > 0)
            {
                totalScores1 += 50;
                totalScores2 += 50;
            }

// Z card
            if (zCounter1 == 1)
                totalScores1 *= 2;
            if (zCounter1 == 2)
                totalScores1 *= 4;
            if (zCounter1 == 3)
                totalScores1 *= 8;
            if (zCounter2 == 1)
                totalScores2 *= 2;
            if (zCounter2 == 2)
                totalScores2 *= 4;
            if (zCounter2 == 3)
                totalScores2 *= 8;

// Y card
            if (yCounter1 == 1)
                totalScores1 -= 200;
            else if (yCounter1 == 2)
                totalScores1 -= 400;
            else if (yCounter1 == 3)
                totalScores1 -= 600;
            if (yCounter2 == 1)
                totalScores2 -= 200;
            else if (yCounter2 == 2)
                totalScores2 -= 400;
            else if (yCounter2 == 3)
                totalScores2 -= 600;



// Export current game scores to total match scores

            if (currScores1 > currScores2)
            {
                totalScores1 += currScores1;
                gamesWon1++;
            }
            else if (currScores2 > currScores1)
            {
                totalScores2 += currScores2;
                gamesWon2++;
            }

            n--;
        }

// Total Scores Solution

        if (totalScores1 > totalScores2)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", totalScores1);
            Console.WriteLine("Games won: {0}", gamesWon1);
        }
        else if (totalScores2 > totalScores1)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", totalScores2);
            Console.WriteLine("Games won: {0}", gamesWon2);
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", totalScores1);
        }


    }
}

