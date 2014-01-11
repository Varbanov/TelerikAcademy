using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public struct Size
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


        public Size(int width, int height, int length)
            : this()
        {
            this.Width = width;
            this.Height = height;
            this.Length = length;
        }
        
    }
}
