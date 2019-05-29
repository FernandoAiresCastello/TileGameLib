using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.Core
{
    public class ObjectMap
    {
        public string Name { set; get; }
        public List<ObjectLayer> Layers { set; get; } = new List<ObjectLayer>();
        public Charset Charset { get; set; } = new Charset();
        public Palette Palette { get; set; } = new Palette();
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObjectLayer this[int layer]
        {
            get
            {
                return Layers[layer];
            }
        }

        public ObjectMap(int width, int height)
        {
            Name = "Undefined";
            Width = width;
            Height = height;
            AddLayer();
        }

        public void AddLayer()
        {
            Layers.Add(new ObjectLayer(Width, Height));
        }

        public void Clear()
        {
            foreach (ObjectLayer layer in Layers)
                layer.Clear();
        }

        public void SetObject(GameObject o, int layer, int x, int y)
        {
            Layers[layer].SetObject(o, x, y);
        }

        public ref GameObject GetObject(int layer, int x, int y)
        {
            return ref Layers[layer].GetObject(x, y);
        }

        public GameObject CopyObject(int layer, int x, int y)
        {
            return Layers[layer].CopyObject(x, y);
        }
    }
}
