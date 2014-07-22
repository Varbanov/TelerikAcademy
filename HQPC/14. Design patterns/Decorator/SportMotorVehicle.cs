namespace Decorator
{
    using System;

    public class SportVehicle : VehicleDecorator
    {
        public SportVehicle(Vehicle vehicle)
            : base(vehicle)
        {
            this.SportModeOn = true;
        }

        public bool SportModeOn { get; set; }

        public override string Show()
        {
            var baseResult = base.Show();
            return baseResult + string.Format("--from SportMotorCar: sport mode: {0} ", this.SportModeOn);
        }
    }
}
