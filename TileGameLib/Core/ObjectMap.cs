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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Charset Charset { get; set; }
        public Palette Palette { get; set; }

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
    }
}
