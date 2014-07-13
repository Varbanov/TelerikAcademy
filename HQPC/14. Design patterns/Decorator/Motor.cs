using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Motor : Vehicle
    {
        public int SaddleBagsVolume { get; set; }

        public Motor(int saddlebagsVolume, int consumption)
            : base(2, consumption)
        {
            this.SaddleBagsVolume = saddlebagsVolume;
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
