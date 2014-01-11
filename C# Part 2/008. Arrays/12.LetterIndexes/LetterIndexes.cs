using System;

class LetterIndexes
{
    //Write a program that creates an array containing all letters from the alphabet (A-Z).
    //Read a word from the console and print the index of each of its letters in the array.

    static int BinSearch(char elem, char[] arr, int startIndex, int endIndex)
    {
        int index = endIndex - (endIndex - startIndex) / 2;
        if (startIndex > endIndex)
        {
            return -1;
        }
        else
        {
            if (elem > arr[index])
            {
                return BinSearch(elem, arr, index + 1, endIndex);
            }
            else if (elem < arr[index])
            {
                return BinSearch(elem, arr, startIndex, index - 1);
            }
            else return index;
        }
    }

    static void Main()
    {
        //create an array containing all small and capital letters
        char[] alphabet = new char[52];
        for (int i = 0; i < 25; i++)
        {
            alphabet[i] = (char)(i + 65);
        }
        for (int i = 26; i < 52; i++)
        {
            alphabet[i] = (char)(i + 71);
        }

        //solution
        //Note that I use binary search algorithm (log(2)N) to speed up searching in 
        //the alphabet array, instead of using nested for-loop
        Console.Write("Please enter a word: ");
        string word = Console.ReadLine();
        foreach (var letter in word)
	    {
            int index = BinSearch(letter, alphabet, 0, alphabet.Length);
            Console.WriteLine(index);
        }
    }
}

