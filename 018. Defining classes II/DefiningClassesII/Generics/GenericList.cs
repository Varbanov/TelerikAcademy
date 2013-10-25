using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Generics
{
    class GenericList<T>
    {
        //Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
        //Keep the elements of the list in an array with fixed capacity which is given as parameter in 
        //the class constructor. 

        //Implement methods for adding element, accessing element by index, removing element by index, 
        //inserting element at given position, clearing the list, finding element by its value and ToString(). 

        //Check all input parameters to avoid accessing elements at invalid positions.

        public int Capacity { get; set; }
        private T[] array;
        private int count;

        //constructor
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.array = new T[capacity];
        }

        //property for Count (needed for Min/Max)
        public int Count
        {
            get { return this.count; }
        }

        //indexer (access by index)
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index {0}!", index));
                }
                return array[index];
            }
        }

        //methods
        public void Add(T element)
        {
            if (count >= array.Length)
            {
                AutoGrow();
            }
            this.array[count] = element;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentException(String.Format("Invalid index {0}!", index));
            }
            else
            {
                for (int i = index; i < this.count - 1; i++)
                {
                    this.array[i] = this.array[i + 1];
                }
                //set to default the last unnecessary element
                this.array[this.count - 1] = default(T);
                //decrease the counter of elements with 1
                this.count--;
            }
        }

        public void InsertAt(int index, T element)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentException(String.Format("Invalid index {0}!", index));
            }
            else
            {
                if (this.count == this.array.Length)
                {
                    AutoGrow();
                }

                for (int i = this.count; i > index; i--)
                {
                    this.array[i] = this.array[i - 1];
                }
                this.array[index] = element;
                this.count++;
            }

        }

        public void Clear()
        {
            //reset elements counter and values
            this.count = 0;
            Array.Clear(this.array, 0, this.array.Length -1);
        }

        public int Find(T element)
        {
            int res = -1; //if no element is found, return -1
            for (int i = 0; i < this.count; i++)
            {
                if (element.Equals(this.array[i]))
                {
                    res = i;
                    break;
                }
            }
            return res;
        }

        //a private method for auto grow functionality
        private void AutoGrow()
        {
            int length = this.array.Length;
            T[] newArr = new T[length * 2];
            for (int i = 0; i < length; i++)
            {
                newArr[i] = this.array[i];
            }
            this.array = newArr;
        }

        //override ToString()
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i <= count; i++)
            {
                res.Append(array[i]);
                res.Append(" ");
            }
            return res.ToString();
        }

    }
}
