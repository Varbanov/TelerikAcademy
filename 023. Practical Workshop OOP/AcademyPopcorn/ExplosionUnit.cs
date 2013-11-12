using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplosionUnit : MovingObject
    {

        public const char Symbol = ' ';

        public ExplosionUnit(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,]{{Symbol}}, speed)
        {
        }

        public override void Update()
        {
            //after killing the block, the object is needed no more
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }
    }
}
