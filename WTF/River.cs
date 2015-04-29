using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    class River : FieldObject
    {
            
        public River(Vector position) :
            base(position, false, "river")  { }
    }
}
