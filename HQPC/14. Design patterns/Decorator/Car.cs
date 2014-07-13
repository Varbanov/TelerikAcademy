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
            Console.WriteLine("The car moved forward");
        }

        public override void MoveBackward()
        {
            Console.WriteLine("The car moved backward");
        }

        public override string Show()
        {
            var baseResult = base.Show();
            return baseResult + string.Format("--from Car: side windows: {0} ", sideWindowsCount);
        }

    }
}
