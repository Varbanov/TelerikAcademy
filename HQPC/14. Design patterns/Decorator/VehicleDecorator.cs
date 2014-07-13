using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class VehicleDecorator : Vehicle
    {
        protected Vehicle Vehicle { get; set; }

        public VehicleDecorator(Vehicle vehicle)
            : base(vehicle.Seats, vehicle.Consumption)
        {
            this.Vehicle = vehicle;
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
