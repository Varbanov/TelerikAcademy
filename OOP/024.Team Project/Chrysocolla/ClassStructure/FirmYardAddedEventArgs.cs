using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public class FirmYardAddedEventArgs : EventArgs
    {
        public TimberYard Yard { get; private set; }

        public FirmYardAddedEventArgs(TimberYard yard)
        {
            this.Yard = yard;
        }
    }
}
