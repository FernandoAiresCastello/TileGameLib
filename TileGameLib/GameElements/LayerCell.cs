using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class LayerCell
    {
        private GameObject Object;

        public LayerCell()
        {
            Object = null;
        }

        public LayerCell(LayerCell other)
        {
            SetEqual(other);
        }

        public ref GameObject GetObject()
        {
            return ref Object;
        }

        public void SetEqual(LayerCell other)
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

        public GameObject CopyObject()
        {
            return Object.Copy();
        }

        public void DeleteObject()
        {
            Object = null;
        }

        public bool IsEmpty()
        {
            return Object == null;
        }
    }
}
