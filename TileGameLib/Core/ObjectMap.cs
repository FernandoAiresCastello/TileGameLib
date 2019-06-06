using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.Core
{
    public class ObjectMap
    {
        public string Name { set; get; }
        public List<ObjectLayer> Layers { set; get; } = new List<ObjectLayer>();
        public Tileset Tileset { get; set; } = new Tileset();
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

        public void Fill(GameObject o)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Fill(o);
        }

        public void SetObject(GameObject o, int layer, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                Layers[layer].SetObject(o, x, y);
            }
            else
            {
                Alert.Error(
                    "Invalid object layer index on SetObject\n" +
                    "X: " + x + " Y: " + y + "\n" +
                    "Object layer size: " + Width + "x" + Height
                );
            }
        }

        public GameObject GetObject(int layer, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Layers[layer].GetObject(x, y);

            Alert.Error(
                "Invalid object layer index on GetObject\n" +
                "X: " + x + " Y: " + y + "\n" +
                "Object layer size: " + Width + "x" + Height
            );

            return null;
        }

        public GameObject CopyObject(int layer, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Layers[layer].CopyObject(x, y);

            Alert.Error(
                "Invalid object layer index on CopyObject\n" +
                "X: " + x + " Y: " + y + "\n" +
                "Object layer size: " + Width + "x" + Height
            );

            return null;
        }
    }
}
