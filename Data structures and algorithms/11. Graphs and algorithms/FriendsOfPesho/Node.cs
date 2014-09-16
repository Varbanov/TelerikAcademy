namespace FriendsOfPesho
{
    using System;

    class Node : IComparable<Node>
    {
        public int Id { get; set; }
        public int DijkstraDistance { get; set; }
        public bool IsHospital { get; set; }


        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int CompareTo(Node other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }
}
