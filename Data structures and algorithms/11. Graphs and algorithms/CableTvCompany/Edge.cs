using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTvCompany
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.FromCity = startNode;
            this.ToCity = endNode;
            this.Distance = weight;
        }

        public int FromCity { get; set; }

        public int ToCity { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Edge other)
        {
            int distance = this.Distance.CompareTo(other.Distance);

            if (distance == 0)
            {
                return this.FromCity.CompareTo(other.FromCity);
            }

            return distance;
        }

        public override string ToString()
        {
            return string.Format("city {0} to city {1} -> Cable of length {2}", this.FromCity, this.ToCity, this.Distance);
        }
    }
}
