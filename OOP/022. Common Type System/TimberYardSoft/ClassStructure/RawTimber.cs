using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    // a class to hold raw input timber
    class RawTimber : TimberRoot
    {
        static readonly decimal PRICE = 50m;

        //todo: constructor

        public override string GetDescription()
        {
            //todo:
            return this.Name;
        }

        public override decimal GetPrice()
        {
            return RawTimber.PRICE;
        }

        public override Dimension GetDimension()
        {
            //todo:
            throw new NotImplementedException();
        }
    }
}
