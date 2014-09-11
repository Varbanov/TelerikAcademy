using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubarraysSums
{
    public class SubarraysCombinator : CombinatorWithoutRepetition<int>
    {
        public int SumOfAllSubarrays { get; set; }

        public SubarraysCombinator(int k, int[] inputArray)
            : base(k, inputArray)
        {
        }

        public override void Action(int[] arr)
        {
            foreach (var item in arr)
            {
                this.SumOfAllSubarrays += item;
            }
        }
    }
}
