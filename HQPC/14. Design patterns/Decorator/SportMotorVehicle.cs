using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SportVehicle : VehicleDecorator
    {
        public bool sportModeOn { get; set; }

        public SportVehicle(Vehicle vehicle)
            : base(vehicle)
        {
            this.sportModeOn = true;
        }

        public override string Show()
        {
            var baseResult = base.Show();
            return baseResult + string.Format("--from SportMotorCar: sport mode: {0} ", this.sportModeOn);
        }
    }
}
