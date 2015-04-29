using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    class Street : FieldObject
    {

        public Street(FieldObject[,] map, Vector position) :
            base(map, position, true, "street")
        {

        }

    }

}
