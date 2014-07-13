using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Car : Vehicle
    {
        public int sideWindowsCount { get; set; }

        public Car(int seats, int consumption, int sideWindowsCount)
            : base(seats, consumption)
        {
            this.sideWindowsCount = sideWindowsCount;
        }

        public override void MoveForward()
        {
            throw new NotImplementedException();
        }

        public override void MoveBackward()
        {
            throw new NotImplementedException();
        }
    }
}
