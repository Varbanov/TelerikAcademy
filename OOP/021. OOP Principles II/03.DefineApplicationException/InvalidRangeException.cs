using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DefineApplicationException
{
    class InvalidRangeException<T> : ApplicationException
    {
        //fields
        public T MinOfRange { get; set; }
        public T MaxOfRange { get; set; }

        //constructors
        public InvalidRangeException(string msg, T minOfRange, T maxOfRange)
            : base(msg)
        {
            this.MinOfRange = minOfRange;
            this.MaxOfRange = maxOfRange;
        }

        public InvalidRangeException(string msg, Exception innerException, T minOfRange, T maxOfRange)
            : base(msg, innerException)
        {
            this.MinOfRange = minOfRange;
            this.MaxOfRange = maxOfRange;
        }

        //message property overriden to show range
        public override string Message
        {
            get
            {
                string message = String.Format("{0} Acceptable range: from {1} to {2}.", base.Message, this.MinOfRange, this.MaxOfRange);
                return message;
            }
        }
    }
}
