using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Vehicle : IVehicle
    {
        public int Seats { get; private set; }
        public int Consumption { get; private set; }
        
        public Vehicle(int seats, int consumption) 
        {
            this.Seats = seats;
            this.Consumption = consumption;
        }

        public abstract void MoveForward();
        public abstract void MoveBackward();

        public virtual string Show() 
        {
            return string.Format("--from Vehicle: seats: {0}, consumption: {1} ", this.Seats, this.Consumption);
        }
    }
}
