using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public class YardChangedEventArgs : EventArgs
    {
        private Lot lot;
        private ChangeType type;

        public YardChangedEventArgs(Lot lot, ChangeType type)
        {
            this.lot = lot;
            this.type = type;
        }

        public Lot Lot
        {
            get { return this.lot; }
        }

        public ChangeType Type
        {
            get { return this.type; }
        }
    }
}
