using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        //05.Implement a TrailObject class. It should inherit the GameObject class and should have a 
        //constructor which takes an additional "lifetime" integer. The TrailObject should disappear
        //after a "lifetime" amount of turns. You must NOT edit any existing .cs file. Then test the
        //TrailObject by adding an instance of it in the engine through the AcademyPopcornMain.cs file.

        private int lifeTime;
        public const char Symbol = '*';

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] {{Symbol}})
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.lifeTime > 1)
            {
                this.lifeTime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
        //END 05
    }
}
