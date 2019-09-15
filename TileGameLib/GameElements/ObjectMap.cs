using System;
using System.Collections.Generic;
using System.Drawing;
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
        public int BackColor { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ImageWidth => Width * TilePixels.RowLength;
        public int ImageHeight => Height * TilePixels.RowCount;

        private static readonly string UndefinedMapName = "Undefined";

        public ObjectMap(int width, int height) : this(UndefinedMapName, width, height, 0)
        {
            BackColor = Palette.Size - 1;
        }

        public ObjectMap(string name, int width, int height, int backColor)
        {
            Name = name;
            Width = width;
            Height = height;
            BackColor = backColor;

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
            BackColor = other.BackColor;
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

        public ObjectCell GetCell(ObjectPosition pos)
        {
            return Layers[pos.Layer].Cells[pos.X, pos.Y];
        }

        public void SetObject(GameObject o, ObjectPosition pos)
        {
            Layers[pos.Layer].SetObject(o, pos.X, pos.Y);
        }

        public ref GameObject GetObjectRef(ObjectPosition pos)
        {
            return ref Layers[pos.Layer].GetObjectRef(pos.X, pos.Y);
        }

        public GameObject GetObjectCopy(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetObjectCopy(pos.X, pos.Y);
        }

        public void Resize(int width, int height)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Resize(width, height);

            Width = width;
            Height = height;
        }

        public void CreateNewObject(ObjectPosition pos)
        {
            SetObject(new GameObject(), pos);
        }

        public void MoveObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            DuplicateObject(srcPos, destPos);
            DeleteObject(srcPos);
        }

        public void MoveObject(ObjectPosition srcPos, int dx, int dy)
        {
            DuplicateObject(srcPos, new ObjectPosition(srcPos.Layer, srcPos.X + dx, srcPos.Y + dy));
            DeleteObject(srcPos);
        }

        public void DuplicateObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell srcCell = GetCell(srcPos);
            ObjectCell destCell = GetCell(destPos);

            GameObject o = srcCell.GetObjectRef();
            if (o != null)
                destCell.SetObjectEqual(o);
        }

        public void SwapObjects(ObjectPosition pos1, ObjectPosition pos2)
        {
            ObjectCell cell1 = GetCell(pos1);
            ObjectCell cell2 = GetCell(pos2);

            GameObject o1 = cell1.GetObjectRef();
            GameObject o2 = cell2.GetObjectRef();

            if (o1 != null && o2 != null)
            {
                GameObject temp = cell1.GetObjectCopy();
                cell1.SetObjectEqual(o2);
                cell2.SetObjectEqual(temp);
            }
        }

        public void DeleteObject(ObjectPosition pos)
        {
            ObjectCell srcCell = GetCell(pos);
            srcCell.DeleteObject();
        }

        public GameObject FindObjectByTag(string tag)
        {
            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                GameObject o = layer.FindObjectByTag(tag);
                if (o != null)
                    return o;
            }

            return null;
        }

        public ObjectPosition FindObjectPositionByTag(string tag)
        {
            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                Point? layerXY = layer.FindObjectPositionByTag(tag);

                if (layerXY.HasValue)
                    return new ObjectPosition(layerIndex, layerXY.Value.X, layerXY.Value.Y);
            }

            return null;
        }
    }
}
