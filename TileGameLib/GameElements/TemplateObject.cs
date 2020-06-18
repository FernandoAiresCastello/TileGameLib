using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class TemplateObject
    {
        public string Name { set; get; }
        public GameObject Object { set; get; }

        public TemplateObject(string name, GameObject srcObject)
        {
            Name = name;
            Object = new GameObject(srcObject);
        }

        public GameObject Instantiate()
        {
            return new GameObject(Object);
        }
    }
}
