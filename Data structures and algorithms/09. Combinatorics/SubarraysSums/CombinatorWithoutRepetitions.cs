namespace SubarraysSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class CombinatorWithoutRepetition<T> : ICombinationsGenerator<T>
    {
        protected T[] inputCollection;
        private int n;
        private int lengthOfCombination;

        public CombinatorWithoutRepetition(int k, T[] inputCollection)
        {
            this.lengthOfCombination = k;
            this.inputCollection = inputCollection;
            this.n = this.inputCollection.Length;
        }

        public int LengthOfCombination
        {
            get
            {
                return lengthOfCombination;
            }
            set
            {
                if (lengthOfCombination > this.inputCollection.Length)
                {
                    throw new ArgumentException("The input parameter k must be less than or equal to the input array length");
                }

                lengthOfCombination = value;
            }
        }

        public abstract void Action(T[] arr);

        public void Generate()
        {
            var result = new T[lengthOfCombination];
            this.GenerateCombinations(this.lengthOfCombination - 1, this.n, result);
        }

        private void GenerateCombinations(int k, int n, T[] resultArr, int next = 0)
        {
            if (k == -1)
            {
                Action(resultArr);
            }
            else
            {
                for (int num = next; num < n; num++)
                {
                    //from k to 0, for each current combination element recursively generate all possible values for every next element to the left
                    resultArr[k] = this.inputCollection[num];
                    GenerateCombinations(k - 1, n, resultArr, num + 1);
                }
            }
        }
    }
}
