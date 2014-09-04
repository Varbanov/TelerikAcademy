namespace _03.FindSetOfWordsInText
{
    using System;
    using System.Diagnostics;

    public class WordsEntryPoint
    {
        public const int wordsCount = 1000000;
        public const int searchCount = 1000000;

        public static Random rnd = new Random();

        public static void Main()
        {
            var sw = new Stopwatch();
            var trie = new Trie();

            for (int i = 0; i < wordsCount; i++)
            {
                string word = GetWord();
                sw.Start();
                trie.AddWord(word);
                sw.Stop();
            }

            Console.WriteLine("Adding finished, elapsed: {0}", sw.Elapsed);

            sw.Reset();
            for (int i = 0; i < searchCount; i++)
            {
                string word = GetWord();
                sw.Start();
                trie.GetWordCount(word);
                sw.Stop();
            }
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
        }

        public static string GetWord()
        {
            char[] newWord = new char[rnd.Next(4, 17)];
            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = ((char)rnd.Next(65, 91));
            }

            return newWord.ToString();
        }
    }
}

