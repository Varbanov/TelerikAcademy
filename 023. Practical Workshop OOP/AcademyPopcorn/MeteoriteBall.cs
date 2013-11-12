using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        //06.Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of TrailObject
        //objects. Each trail objects should last for 3 "turns". Other than that, the Meteorite ball should
        //behave the same way as the normal ball. You must NOT edit any existing .cs file.

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override void Update()
        {
            this.topLeft += Speed;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trail = new List<TrailObject>();
            trail.Add(new TrailObject(this.TopLeft, 3));
            return trail;
        }
        //END 06
    }
}
