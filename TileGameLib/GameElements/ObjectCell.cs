using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class ObjectCell
    {
        public bool IsEmpty => Object == null;

        private GameObject Object;

        public ObjectCell()
        {
            Object = null;
        }

        public ObjectCell(ObjectCell other)
        {
            SetEqual(other);
        }

        public GameObject GetObject()
        {
            return Object;
        }

        public GameObject GetObjectCopy()
        {
            return Object.Copy();
        }

        public void SetEqual(ObjectCell other)
        {
            if (other.Object == null)
            {
                Object = null;
            }
            else
            {
                if (Object == null)
                    Object = new GameObject();

                Object.SetEqual(other.Object);
            }
        }

        public void SetObjectEqual(GameObject other)
        {
            if (Object == null)
                Object = new GameObject();

            Object.SetEqual(other);
        }

        public void DeleteObject()
        {
            Object = null;
        }
    }
}
