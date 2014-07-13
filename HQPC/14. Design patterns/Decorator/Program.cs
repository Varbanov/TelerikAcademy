using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            var car = new Car(4, 7, 4);
            var motor = new Motor(70, 5);
            var sportCar = new SportVehicle(new Car(2, 17, 0));
            var sportMotor = new SportVehicle(new Motor(0, 13));

            Console.WriteLine("car: " + car.Show());
            Console.WriteLine("-----------------");
            Console.WriteLine("motor: " + motor.Show());
            Console.WriteLine("-----------------");
            Console.WriteLine("sport car: " + sportCar.Show());
            Console.WriteLine("-----------------");
            Console.WriteLine("sport motor: " + sportMotor.Show());
            Console.WriteLine("-----------------");

            sportCar.MoveForward();
            sportMotor.MoveBackward();

            car.MoveForward();
            motor.MoveBackward();

            Console.WriteLine("-----------------------------------------");



        }
    }
}
