using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        //12.Implement a GiftBlock class. It should be a block, which "drops" a Gift object when it is destroyed. 
        //You must NOT edit any existing .cs file. Test the Gift and GiftBlock classes by adding them through 
        //the AcademyPopcornMain.cs file.

        public const char Symbol = 'G';
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produced = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produced.Add(new Gift(this.GetTopLeft()));
            }

            return produced;
        }
        //END 12
    }
}
