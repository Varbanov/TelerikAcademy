using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    class DubLot : Lot
    {
        public DubLot(LotSize size, int Pieces, decimal price)
            : base(Wood.Dub, size, Pieces, price)
        {
        }

    }
}
