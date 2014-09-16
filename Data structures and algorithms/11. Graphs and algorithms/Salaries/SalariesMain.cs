namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class SalariesMain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<Node, List<Node>> graph = new Dictionary<Node, List<Node>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < n; i++)
            {
                string currentLine = Console.ReadLine().Trim();

                if (!allNodes.ContainsKey(i))
                {
                    var node = new Node(i);
                    allNodes.Add(i, node);
                }

                var currentNode = allNodes[i];
                graph[currentNode] = new List<Node>();

                for (int j = 0; j < n; j++)
                {
                    if (currentLine[j] == 'Y')
                    {
                        if (!allNodes.ContainsKey(j))
                        {
                            var second = new Node(j);
                            allNodes.Add(j, second);
                        }

                        var secondNode = allNodes[j];
                        if (!graph.ContainsKey(secondNode))
                        {
                            graph[secondNode] = new List<Node>();
                        }

                        graph[currentNode].Add(secondNode);
                    }
                }
            }

            foreach (var node in allNodes)
            {
                Dfs(graph, node.Value);
            }

            long sum = 0;
            foreach (var node in allNodes)
            {
                sum += node.Value.Salary;
            }

            Console.WriteLine(sum);
        }

        public static void Dfs(Dictionary<Node, List<Node>> graph, Node worker)
        {
            if (worker.isCalculated)
            {
                return;
            }

            if (graph[worker].Count == 0)
            {
                worker.Salary = 1;
                worker.isCalculated = true;
            }

            foreach (var child in graph[worker])
            {
                Dfs(graph, child);
                worker.Salary += child.Salary;
            }

            worker.isCalculated = true;
        }
    }
}
