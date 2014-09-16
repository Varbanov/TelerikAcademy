namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int pointsNumber = int.Parse(inputNumbers[0]);
            int streetsNumber = int.Parse(inputNumbers[1]);
            int hospitalNumber = int.Parse(inputNumbers[2]);

            string[] allHospitals = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<Node, List<Edge>> graph = new Dictionary<Node, List<Edge>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();


            for (int i = 0; i < streetsNumber; i++)
            {
                string[] currentStreet = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int firstNode = int.Parse(currentStreet[0]);
                int secondNode = int.Parse(currentStreet[1]);
                int distance = int.Parse(currentStreet[2]);

                //if nodes does not exist, add them to the dict of nodes
                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                //get nodes from dict of nodes
                Node firstNodeObject = allNodes[firstNode];
                Node secondNodeObject = allNodes[secondNode];

                //add new nodes to the graph
                if (!graph.ContainsKey(firstNodeObject))
                {
                    graph[firstNodeObject] = new List<Edge>();
                }

                if (!graph.ContainsKey(secondNodeObject))
                {
                    graph[secondNodeObject] = new List<Edge>();
                }

                //add edges in the graph
                graph[firstNodeObject].Add(new Edge(secondNodeObject, distance));
                graph[secondNodeObject].Add(new Edge(firstNodeObject, distance));
            }

            //mark hospitals
            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                allNodes[currentHospital].IsHospital = true;
            }

            //solution
            int result = int.MaxValue;

            for (int i = 0; i < allHospitals.Length; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                Dijkstra(graph, allNodes[currentHospital]);
                int currentSum = 0;

                foreach (var node in graph)
                {
                    if (!node.Key.IsHospital)
                    {
                        currentSum += node.Key.DijkstraDistance;
                    }
                }

                if (currentSum < result)
                {
                    result = currentSum;
                }
            }


            Console.WriteLine(result);
        }

        public static void Dijkstra(Dictionary<Node, List<Edge>> graph, Node source)
        {
            BinaryHeapMin<Node> heap = new BinaryHeapMin<Node>();
            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = int.MaxValue;
            }

            source.DijkstraDistance = 0;
            heap.Add(source);

            while (heap.Count > 0)
            {
                Node currentNode = heap.RemoveTop();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + edge.Distance;
                    if (potDistance < edge.Target.DijkstraDistance)
                    {
                        //first calculate dijkstra and only after that add to heap to avoid the need of heapifying the heap
                        edge.Target.DijkstraDistance = potDistance;
                        heap.Add(edge.Target);
                    }
                }



            }
        }
    }
}
