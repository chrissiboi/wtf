using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    public class Vector
    {
        int x;
        int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getPositonX()
        {
            return x;
        }
        public int getPositonY()
        {
            return y;
        }
    }
}
