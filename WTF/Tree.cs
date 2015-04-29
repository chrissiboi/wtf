using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    class Tree : FieldObject
    {
        public Tree(Vector position, bool isPassable) :
            base(position, false, "tree") { }
       
    }
}
