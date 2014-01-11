using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootEngine : Engine
    {
        //04.Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.
        //13. (Shooting racket functionalities implemented)
        public ShootEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public ShootEngine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }

        //END 04
        //END 13
    }
}
