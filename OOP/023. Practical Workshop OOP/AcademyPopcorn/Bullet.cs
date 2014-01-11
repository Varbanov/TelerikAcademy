using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        //13.Implement a shoot ability for the player racket. The ability should only be activated when
        //a Gift object falls on the racket. The shot objects should be a new class (e.g. Bullet) and 
        //should destroy normal Block objects (and be destroyed on collision with any block). Use the 
        //engine and ShootPlayerRacket method you implemented in task 4, but don't add items in any of 
        //the engine lists through the ShootPlayerRacket method. Also don't edit the Racket.cs file. 
        //Hint: you should have a ShootingRacket class and override its ProduceObjects method.
        public const char Symbol = '^';

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] {{Bullet.Symbol}}, new MatrixCoords(-1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString ||
                otherCollisionGroupString == ImpassableBlock.CollisionGroupString ||
                otherCollisionGroupString == IndestructibleBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
