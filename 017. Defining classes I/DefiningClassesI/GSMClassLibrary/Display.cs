using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMClassLibrary
{
    public class Display
    {
        //display characteristics (size and number of colors). 

        private int? size;
        private int? numOfColors;

        public Display()
        {
        }

        public Display(int? size, int? numOfColors)
        {
            this.Size = size;
            this.NumOfColors = numOfColors;
        }

        public int? Size
        {
            get { return this.size; }
            set {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The size of the display should be positive!");
                else
                    this.size = value;
                }
        }
        public int? NumOfColors
        {
            get { return this.numOfColors; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The number of colors should be positive!");
                this.numOfColors = value; }
        }
        

    }
}
