using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        //08.Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces
        //off UnpassableBlocks and will destroy any other block it passes through. 
        //The UnpassableBlock should be indestructible. 
        //Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method
        //and the CollisionData class.

        public new const string CollisionGroupString = "unstoppableBall";
        public const char Symbol = 'Z';

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = UnstoppableBall.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return base.CanCollideWith(otherCollisionGroupString) ||
                otherCollisionGroupString == ImpassableBlock.CollisionGroupString ||
                otherCollisionGroupString == IndestructibleBlock.CollisionGroupString;
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var item in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (item == ImpassableBlock.CollisionGroupString || item == Racket.CollisionGroupString
                //NOTE: to be easily checked, the unstoppable ball bounces off sidewalls (indestructible blocks).
                //To prevent it, comment the next line
                    || item == IndestructibleBlock.CollisionGroupString)
                {
                    base.RespondToCollision(collisionData);
                }
            }
        }

        //END 08
    }
}
