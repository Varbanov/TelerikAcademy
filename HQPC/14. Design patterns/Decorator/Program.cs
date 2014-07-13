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
            var car = new Car(2, 5, 4);
            var sportCar = new SportMotorCar(car);
        }
    }
}
