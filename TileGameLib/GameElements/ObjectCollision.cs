using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class ObjectCollision
    {
        public GameObject Object1 { set; get; }
        public GameObject Object2 { set; get; }

        public ObjectCollision(GameObject o1, GameObject o2)
        {
            Object1 = o1;
            Object2 = o2;
        }

        public override string ToString()
        {
            return $"Object1: {Object1} Object2: {Object2}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ObjectCollision other = (ObjectCollision)obj;

            return 
                Object1.StrictEquals(other.Object1) && 
                Object2.StrictEquals(other.Object2);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Object1, Object2).GetHashCode();
        }
    }
}
