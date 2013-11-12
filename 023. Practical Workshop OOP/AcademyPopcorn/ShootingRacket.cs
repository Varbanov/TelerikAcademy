using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        ////13.Implement a shoot ability for the player racket. The ability should only be activated when
        //a Gift object falls on the racket. The shot objects should be a new class (e.g. Bullet) and 
        //should destroy normal Block objects (and be destroyed on collision with any block). Use the 
        //engine and ShootPlayerRacket method you implemented in task 4, but don't add items in any of 
        //the engine lists through the ShootPlayerRacket method. Also don't edit the Racket.cs file. 
        //Hint: you should have a ShootingRacket class and override its ProduceObjects method.

        private bool shotLoaded;

        public ShootingRacket(MatrixCoords topLeft, int width) 
            : base(topLeft, width)
        {
        }

        public void Shoot()
        {
            shotLoaded = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Bullet> produced = new List<Bullet>();
            if (this.shotLoaded)
            {
                Bullet bullet = new Bullet(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col + this.Width / 2));
                produced.Add(bullet);
                this.shotLoaded = false;
            }
            return produced;
        }
    }
}
