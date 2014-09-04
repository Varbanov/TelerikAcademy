namespace _03.FindSetOfWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        private readonly TrieNode root;

        public Trie()
        {
            this.root = new TrieNode(' ');
        }

        public void AddWord(string word)
        {
            var i = 0;
            var currentNode = this.root;

            while (i < word.Length)
            {
                if (currentNode.Children.Count == 0)
                {
                    //no characters can be matched to the bottom of the tree, so add the new word
                    foreach (var character in word.Substring(i))
                    {
                        currentNode.Children.Add(character, new TrieNode(character));
                        currentNode = currentNode.Children[character];
                    }

                    break;
                }

                if (currentNode.Children.ContainsKey(word[i]))
                {
                    currentNode = currentNode.Children[word[i]];
                    currentNode.Count++;
                }
                else
                {
                    currentNode.Children.Add(word[i], new TrieNode(word[i]));
                    currentNode = currentNode.Children[word[i]];
                }

                i++;
            }
        }

        public int GetWordCount(string word)
        {
            var currentNode = this.root;

            var i = 0;

            while (true)
            {
                if (i == word.Length)
                {
                    if (currentNode.Children.Count == 0)
                    {
                        return currentNode.Count;
                    }
                    else
                    {
                        var childrenOcurences = 0;

                        foreach (var node in currentNode.Children)
                        {
                            childrenOcurences += node.Value.Count;
                        }

                        return currentNode.Count - childrenOcurences;
                    }
                }

                if (currentNode.Children.ContainsKey(word[i]))
                {
                    currentNode = currentNode.Children[word[i]];
                    i++;
                }
                else
                {
                    break;
                }
            }

            return 0;
        }

        public int WordsCount
        {
            get
            {
                int result = 0;

                foreach (var child in this.root.Children)
                {
                    result += child.Value.Count;
                }

                return result;
            }
        }
    }
}

