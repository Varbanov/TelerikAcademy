using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ImpassableBlock : IndestructibleBlock
    {
        //08.Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces
        //off UnpassableBlocks and will destroy any other block it passes through. 
        //The UnpassableBlock should be indestructible. 
        //Hint: Take a look at the RespondToCollision method, the GetCollisionGroupString method
        //and the CollisionData class.

        public new const char Symbol ='U';
        public new const string CollisionGroupString = "impassableBlock";

        public ImpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ImpassableBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return ImpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
        }
    }
}
