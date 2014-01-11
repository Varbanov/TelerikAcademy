using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public struct Dimension
    {
        //in milimeters
        private int width;

        public int Width
        {
            get { return width; }
            set
            {
                //todo: check set
                this.width = value;
            }
        }

        private int height;

        public int Height
        {
            get { return height; }

            //todo: check set
            set { this.height = value; }
        }

        private int length;

        public int Length
        {
            get { return length; }

            //todo: check set
            set { this.length = value; }
        }
        
        //todo: constructor
        
    }
}
