﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class ObjectMap
    {
        public string Name { set; get; }
        public List<ObjectLayer> Layers { set; get; } = new List<ObjectLayer>();
        public Tileset Tileset { get; set; } = new Tileset();
        public Palette Palette { get; set; } = new Palette();
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ImageWidth => Width * TilePixels.RowLength;
        public int ImageHeight => Height * TilePixels.RowCount;

        public ObjectMap(int width, int height) : this("Undefined", width, height)
        {
        }

        public ObjectMap(int width, int height, GameObject defaultObject) : this("Undefined", width, height)
        {
            Layers[0].Fill(defaultObject);
        }

        public ObjectMap(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            AddLayer();
        }

        public ObjectMap(ObjectMap other)
        {
            SetEqual(other);
        }

        public void SetEqual(ObjectMap other)
        {
            Name = other.Name;
            Width = other.Width;
            Height = other.Height;
            Tileset.SetEqual(other.Tileset);
            Palette.SetEqual(other.Palette);
            Layers.Clear();

            foreach (ObjectLayer layer in other.Layers)
            {
                ObjectLayer newLayer = new ObjectLayer(Width, Height);
                newLayer.SetEqual(layer);
                Layers.Add(newLayer);
            }
        }

        public void AddLayer()
        {
            Layers.Add(new ObjectLayer(Width, Height));
        }

        public void AddLayer(GameObject defaultObject)
        {
            Layers.Add(new ObjectLayer(Width, Height, defaultObject));
        }

        public void RemoveLayer(int layer)
        {
            Layers.RemoveAt(layer);
        }

        public void AddLayers(int count)
        {
            for (int i = 0; i < count; i++)
                AddLayer();
        }

        public void Clear()
        {
            foreach (ObjectLayer layer in Layers)
                layer.Clear();
        }

        public void Clear(int layer)
        {
            Layers[layer].Clear();
        }

        public void Fill(GameObject o)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Fill(o);
        }

        public void Fill(GameObject o, int layer)
        {
            Layers[layer].Fill(o);
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

        public void Resize(int width, int height)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Resize(width, height);

            Width = width;
            Height = height;
        }
    }
}
