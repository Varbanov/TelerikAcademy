namespace Decorator
{
    using System;

    public class Car : Vehicle
    {
        public Car(int seats, int consumption, int sideWindowsCount)
            : base(seats, consumption)
        {
            this.SideWindowsCount = sideWindowsCount;
        }

        public int SideWindowsCount { get; set; }

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
            return baseResult + string.Format("--from Car: side windows: {0} ", this.SideWindowsCount);
        }
    }
}
