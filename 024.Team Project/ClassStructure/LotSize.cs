using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public struct LotSize
    {
        //in milimeters
        private int width;
        private int length;
        private int height;

        public int Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width must be positive!");
                }
                width = value;
            }
        }

        public int Height
        {
            get { return height; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be positive!");
                }
                height = value;
            }
        }

        public int Length
        {
            get { return length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length must be positive!");
                }
                length = value;
            }
        }


        public LotSize(int width, int height, int length)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }

        public override string ToString()
        {
            string pattern = String.Format("Size[{0} x {1} x {2}]", this.Width, this.Height, this.Length);
            return String.Format("{0,30}", pattern);
        }
        
    }
}
