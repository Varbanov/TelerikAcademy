using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public class BukLot : Lot
    {
        public BukLot(LotSize size, int Pieces, decimal price)
            : base(Wood.Buk, size, Pieces, price)
        {
        }

    }
}
