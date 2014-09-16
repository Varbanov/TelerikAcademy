namespace Salaries
{
    public class Node
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public long Salary { get; set; }

        public bool isCalculated { get; set; }
    }
}
