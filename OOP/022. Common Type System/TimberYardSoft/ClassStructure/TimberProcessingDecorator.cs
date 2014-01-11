using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public class TimberProcessingDecorator : TimberRoot
    {
        protected TimberRoot baseTimber;

        public TimberProcessingDecorator(TimberRoot timberInstance)
        {
            this.baseTimber = timberInstance;
        }

        public override string GetDescription()
        {
            throw new NotImplementedException();
        }

        public override decimal GetPrice()
        {
            return baseTimber.GetPrice();
        }

        public override Dimension GetDimension()
        {
            throw new NotImplementedException();
        }
    }
}
