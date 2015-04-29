using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    class Firestation : FieldObject
    {
        public Firestation(Vector position) :
            base(position, true, "firestation") { }
    }
}

