using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TreesEntry
    {

        static void Main()
        {
            Console.WriteLine("Please paste the input:");
            var N = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= N - 1; i++)
            {
                string line = Console.ReadLine();
                var lineParts = line.Split(' ');

                int parentValue = int.Parse(lineParts[0]);
                int childValue = int.Parse(lineParts[1]);

                nodes[parentValue].Children.Add(nodes[childValue]);
                nodes[childValue].HasParent = true;
            }

            // Root
            var root = FindRoot(nodes);
            Console.WriteLine("The rootis: {0}", root.Value);

            // Leafs
            var leafs = GetLeafs(nodes);
            Console.Write("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }

            Console.WriteLine();

            // Middle nodes
            var middleNodes = GetMiddleNodes(nodes);
            Console.Write("Middle nodes: ");
            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }
            Console.WriteLine();

            // Longest path
            var longestPath = GetLongestPath(FindRoot(nodes));
            Console.WriteLine("Number of levels: {0}", longestPath + 1);
        }

        static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("No root in the tree!");
        }

        private static int GetLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, GetLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> GetMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> GetLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }
    }
}
