using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        //Define a class BitArray64 to hold 64 bit values inside an ulong value. 
        //Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

        //field
        public ulong Value { get; set; }

        //constructor
        public BitArray64(ulong value)
        {
            this.Value = value;
        }

        //IEnumerable implementation
        public IEnumerator<int> GetEnumerator()
        {
            int[] bitArr = this.Extract64Bits();
            for (int i = 0; i < bitArr.Length; i++)
            {
                yield return bitArr[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= 64 )
                {
                    throw new IndexOutOfRangeException("Index is out of the range [0..63]");
                }
                int[] arr = this.Extract64Bits();
                return arr[index];
            }
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value must be 0 or 1!");
                }
                if (index < 0 || index >=64)
                {
                    throw new IndexOutOfRangeException("Index is out of the range [0..63]");                    
                }

                ulong currValue = this.Value;
                ulong result;
                if (value == 0)
                {
                    ulong mask = (ulong) ~(1 << index);
                    result = (ulong) currValue & mask;
                }
                else
                {
                    ulong mask = (ulong) 1 << index;
                    result = currValue | mask;
                }
            }
        }

        //Equals() overriden
        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                //also, if obj is null, false will be returned
                return false;
            }

            BitArray64 num = obj as BitArray64;

            //using the static method ensures no nullref exception will be thrown
            if (!Object.Equals(this.Value, num.Value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //GetHashCode() overriden
        public override int GetHashCode()
        {
            return this.GetHashCode() ^ this.Value.GetHashCode();
        }

        //operators overriden
        public static bool operator ==(BitArray64 num1, BitArray64 num2)
        {
            return num1.Value.Equals(num2.Value);
        }

        public static bool operator !=(BitArray64 num1, BitArray64 num2)
        {
            return !(num1 == num2);
        }

        //a method to extract all the bits of the field
        public int[] Extract64Bits()
        {
            int[] arr = new int[64];
            ulong num = this.Value;
            for (int i = 0; i < 64; i++)
            {
                arr[63 - i] = (int) (num >> i) & 1;
            }

            return arr;
        }
    }
}
