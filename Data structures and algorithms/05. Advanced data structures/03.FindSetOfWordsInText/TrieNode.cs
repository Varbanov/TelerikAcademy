using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindSetOfWordsInText
{
    public class TrieNode
    {
        public char Value { get; set; }
        public int Count { get; set; }

        public TrieNode(char value)
        {
            this.Value = value;
            this.Count = 1;
            this.Children = new Dictionary<char, TrieNode>();
        }

        public Dictionary<char, TrieNode> Children { get; set; }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = (TrieNode) obj;
            return this.Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return string.Format("{0, 15} - {1}", this.Value, this.Count);
        }
    }

}
