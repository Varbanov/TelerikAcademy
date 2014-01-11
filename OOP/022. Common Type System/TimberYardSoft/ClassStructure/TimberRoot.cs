using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    //root class for all timber items
    public abstract class TimberRoot
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Dimension Dimensions { get; set; }

        public abstract string GetDescription();
        public abstract decimal GetPrice();
        public abstract Dimension GetDimension();
    }
}
