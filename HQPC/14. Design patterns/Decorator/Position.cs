using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    public struct Position
    {
        public int X;
        public int Y;


        public Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}
