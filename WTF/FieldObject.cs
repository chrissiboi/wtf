using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF
{
    class FieldObject
    {

        public Vector positon;
        String objectType;
        bool isPassable;
        bool houseStreet;
        bool firestationStreet;

        public FieldObject(Vector position, bool isPassable, String objectType, bool houseStreet, bool firestationStreet)
        {

            this.positon = position;
            this.isPassable = isPassable;
            this.objectType = objectType;
            this.houseStreet = houseStreet;
            this.firestationStreet = firestationStreet;

        }

        public FieldObject(FieldObject[,] map, Vector position, bool isPassable, String objectType)
        {

            this.positon = position;
            this.isPassable = isPassable;
            this.objectType = objectType;

        }

        public FieldObject(Vector position, bool isPassable, String objectType)
        {

            this.positon = position;
            this.isPassable = isPassable;
            this.objectType = objectType;

        }

        public String getObjectType()
        {

            return this.objectType;

        }

    }
}
