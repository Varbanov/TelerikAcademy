using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class VehicleDecorator : Vehicle
    {
        private Vehicle Vehicle { get; set; }

        public VehicleDecorator(Vehicle vehicle)
            : base(vehicle.Seats, vehicle.Consumption)
        {
            this.Vehicle = vehicle;
        }

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
