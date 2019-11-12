using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameTest
{
    public static class ObjectAssertion
    {
        public static bool IsDoor(GameObject o, string color = null)
        {
            if (o == null)
                return false;

            bool isDoor = o.HasTag && o.Tag.Equals("door");

            if (color != null)
                return isDoor && o.Properties.HasValue("color", color);

            return isDoor;
        }

        public static bool IsKey(GameObject o, string color = null)
        {
            if (o == null)
                return false;

            bool isKey = o.HasTag && o.Tag.Equals("key");

            if (color != null)
                return isKey && o.Properties.HasValue("color", color);

            return isKey;
        }
    }
}
