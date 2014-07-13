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
        public int Consumption { get; set; }
        protected Position position;
        
        public Vehicle(int seats, int consumption) 
        {
            this.Seats = seats;
            this.Consumption = consumption;
            this.position = new Position(0, 0);
        }

        public abstract void MoveForward();
        public abstract void MoveBackward();

        public virtual string Show() 
        {
            return string.Format("seats: {0}, consumption: {1}, position X: {2}, position Y: {3}");
        }
    }
}
