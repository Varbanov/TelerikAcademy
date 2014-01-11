using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public class Lath : TimberProcessingDecorator
    {

        

        public Lath(TimberRoot timberInstance)
            : base(timberInstance)
        {
            //todo:
        }

        public override string GetDescription()
        {
            //todo:
            return base.GetDescription();
        }

        public override Dimension GetDimension()
        {
            //todo:
            return base.GetDimension();
        }

        public override decimal GetPrice()
        {
            //todo: price should be dependent on dimensions
            return base.GetPrice();
        }
    }
}
