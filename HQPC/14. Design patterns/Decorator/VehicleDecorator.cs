namespace Decorator
{
    using System;

    public abstract class VehicleDecorator : Vehicle
    {
        public VehicleDecorator(Vehicle vehicle)
            : base(vehicle.Seats, vehicle.Consumption)
        {
            this.Vehicle = vehicle;
        }

        private Vehicle Vehicle { get; set; }

        public override void MoveForward()
        {
            this.Vehicle.MoveForward();
        }

        public override void MoveBackward()
        {
            this.Vehicle.MoveBackward();
        }

        public override string Show()
        {
            return this.Vehicle.Show();
        }
    }
}
