namespace _01.PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        public IList<T> data { get; set; }

        public BinaryHeap()
        {
            this.data = new List<T>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(T element)
        {
            this.data.Add(element);
            CascadeUp(this.Count - 1);
        }

        public T RemoveTop()
        {
            var result = this.data[0];
            this.data[0] = this.data[this.Count - 1];
            this.data.RemoveAt(this.Count - 1);
            this.CascadeDown(0);
            return result;
        }

        public T Peek()
        {
            var result = this.data[0];
            return result;
        }

        public void Clear()
        {
            this.data = new List<T>();
        }

        private void CascadeDown(int startIndex)
        {
            var left = GetLeftChildIndex(startIndex);
            var right = GetRightChildIndex(startIndex);
            var largest = startIndex;

            if (left < this.Count && right < this.Count && this.data[left].CompareTo(this.data[right]) > 0)
            {
                largest = left;
            }

            if (right < this.Count && this.data[right].CompareTo(this.data[left]) > 0)
            {
                largest = right;
            }

            if (largest != startIndex)
            {
                var replacer = this.data[startIndex];
                this.data[startIndex] = this.data[largest];
                this.data[largest] = replacer;
                CascadeDown(largest);
            }

            //int parent = 0;
            //int indexToReplace = -1;

            //while (true)
            //{
            //    int leftChild = GetLeftChildIndex(parent);
            //    int rightChild = GetRightChildIndex(parent);

            //    if (leftChild >= this.Count)
            //    {
            //        // bottom of tree is exceeded
            //        return;
            //    }

            //    if (rightChild >= this.Count)
            //    {
            //        // if only left child is available, take it
            //        indexToReplace = leftChild;
            //    }
            //    else
            //    {
            //        // if both children are available, take the greater one
            //        indexToReplace = leftChild.CompareTo(rightChild) > 0 ? leftChild : rightChild;
            //    }

            //    if (this.data[parent].CompareTo(this.data[indexToReplace]) > 0)
            //    {
            //        // the new root is greater than its children, so it is in the right place
            //        return;
            //    }
            //    else
            //    {
            //        //swap the parent and the child
            //        T replacer = this.data[parent];
            //        this.data[indexToReplace] = this.data[parent];
            //        this.data[parent] = replacer;

            //        parent = indexToReplace;
            //    }
            //}
        }

        private void CascadeUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (parentIndex >= 0 && this.data[index].CompareTo(this.data[parentIndex]) > 0)
            {
                //swap the elements
                T replacer = this.data[parentIndex];
                this.data[parentIndex] = this.data[index];
                this.data[index] = replacer;

                //update positions with one more to the tree root
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private int GetRightChildIndex(int parentIndex)
        {
            int rightChild = parentIndex * 2 + 2;
            return rightChild;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            int leftChild = parentIndex * 2 + 1;
            return leftChild;
        }

        private int GetParentIndex(int childIndex)
        {
            int parentIndex = (childIndex - 1) / 2;
            return parentIndex;
        }
    }
}
