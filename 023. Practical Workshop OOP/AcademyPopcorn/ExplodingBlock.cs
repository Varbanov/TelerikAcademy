using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        //10.Implement an ExplodingBlock. It should destroy all blocks around it when it is destroyed. 
        //You must NOT edit any existing .cs file. Hint: what does an explosion "produce"?

        public const char Symbol = '@';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

         public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();
            MatrixCoords speed = new MatrixCoords(0, 0);

            if (this.IsDestroyed)
            {
                //upper
                for (int col = -1; col <= 1; col++)
                {
                    MatrixCoords tempTopLeft = new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + col);
                    ExplosionUnit unit = new ExplosionUnit(tempTopLeft, speed);
                    produced.Add(unit);
                }

                //lower
                for (int col = -1; col <= 1; col++)
                {
                    MatrixCoords tempTopLeft = new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col + col);
                    ExplosionUnit unit = new ExplosionUnit(tempTopLeft, speed);
                    produced.Add(unit);
                }

                //left
                MatrixCoords leftTopLeft = new MatrixCoords(this.topLeft.Row, this.topLeft.Col - 1);
                ExplosionUnit leftUnit = new ExplosionUnit(leftTopLeft, speed);
                produced.Add(leftUnit);

                //right
                MatrixCoords rightTopLeft = new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 1);
                ExplosionUnit rightUnit = new ExplosionUnit(rightTopLeft, speed);
                produced.Add(rightUnit);
            }

            return produced;
        }

    }
}
