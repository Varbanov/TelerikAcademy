using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    [Serializable]
    public class YasenLot : Lot
    {
        public YasenLot(LotSize size, int Pieces, decimal price)
            : base(Wood.Yasen, size, Pieces, price)
        {
        }
    }
}
