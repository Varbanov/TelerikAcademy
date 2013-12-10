using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimberYardSoft.ClassStructure
{
    public class OrderPiecesException<T> : ApplicationException
    {
        public T MinItemCount { get; set; }
        public T MaxItemCount { get; set; }

        public OrderPiecesException(string msg, T minItemCount, T maxItemCount)
            : base(msg)
        {
            this.MinItemCount = minItemCount;
            this.MaxItemCount = maxItemCount;
        }

        public OrderPiecesException(string msg, Exception innerException, T minItemCount, T maxItemCount)
            : base(msg, innerException)
        {
            this.MinItemCount = minItemCount;
            this.MaxItemCount = maxItemCount;
        }

        public override string Message
        {
            get
            {
                return String.Format("{0} Pieces must be between {1} and {2}", base.Message, this.MinItemCount, this.MaxItemCount);
            }
        }
    }
}
