using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class ObjectCollision
    {
        public PositionedObject PositionedObject1 { set; get; }
        public PositionedObject PositionedObject2 { set; get; }

        public ObjectCollision(PositionedObject o1, PositionedObject o2)
        {
            PositionedObject1 = o1;
            PositionedObject2 = o2;
        }

        public override string ToString()
        {
            return $"PositionedObject1: {PositionedObject1} PositionedObject2: {PositionedObject2}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ObjectCollision other = (ObjectCollision)obj;

            return 
                PositionedObject1.Object.StrictEquals(other.PositionedObject1) &&
                PositionedObject2.Object.StrictEquals(other.PositionedObject2);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(PositionedObject1, PositionedObject2).GetHashCode();
        }
    }
}
