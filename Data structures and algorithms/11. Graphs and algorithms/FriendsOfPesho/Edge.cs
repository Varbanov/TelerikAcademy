namespace FriendsOfPesho
{
    class Edge
    {
        public Node Target { get; set; }
        public int Distance { get; set; }

        public Edge(Node target, int distance)
        {
            this.Target = target;
            this.Distance = distance;
        }
    }
}
