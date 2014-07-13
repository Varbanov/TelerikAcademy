using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SportMotorCar : VehicleDecorator
    {
        public bool sportModeOn { get; set; }

        public SportMotorCar(Vehicle vehicle)
            : base(vehicle)
        {
            this.sportModeOn = true;
        }
    }
}
