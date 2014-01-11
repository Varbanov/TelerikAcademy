using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        //11.Implement a Gift class. It should be a moving object, which always falls down. 
        //The gift shouldn't collide with any ball, but should collide (and be destroyed) with 
        //the racket. You must NOT edit any existing .cs file. 
        public new const string CollisionGroupString = "gift";
        public const char Symbol = '$';

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] {{Symbol}}, new MatrixCoords(1,0))
        {
        }

        public override string GetCollisionGroupString()
        {
            return MovingObject.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();
            if (this.IsDestroyed)
            {
                MatrixCoords newRacketCoords = new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col);
                produced.Add(new ShootingRacket(newRacketCoords, 6));
            }
            return produced;
        }

        //END 11
    }
}
