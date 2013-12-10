using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public class YavorLot : Lot
    {
        public YavorLot(LotSize size, int Pieces, decimal price)
            : base(Wood.Yavor, size, Pieces, price)
        {
        }
    }
}
