namespace _03.CountWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountWordsInText
    {
        static void Main()
        {
            string input = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            CountWords(input);
        }

        private static void CountWords(string inputText)
        {
            inputText = inputText.ToLower();
            var words = inputText.Split(new char[] { '.', ',', ' ', '!', '?', ';', '–' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }

            var orderedResult = dict.OrderBy(x => x.Value);

            foreach (var word in orderedResult)
            {
                Console.WriteLine("{0,5} {1,5}", word.Key, word.Value);
            }
        }
    }
}
