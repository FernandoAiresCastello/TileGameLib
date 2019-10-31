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
        public string MusicFile { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ImageWidth => Width * TilePixels.RowLength;
        public int ImageHeight => Height * TilePixels.RowCount;
        public bool HasMusic => !string.IsNullOrWhiteSpace(MusicFile);

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
            MusicFile = other.MusicFile;
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

        public GameObject GetObject(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetObject(pos.X, pos.Y);
        }

        public GameObject GetObjectCopy(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetObjectCopy(pos.X, pos.Y);
        }

        public GameObject GetObjectUnder(ObjectPosition pos)
        {
            if (pos.Layer <= 0)
                return null;

            ObjectCell cellUnder = GetCell(new ObjectPosition(pos.Layer - 1, pos.X, pos.Y));

            return cellUnder.IsEmpty ? null : cellUnder.GetObject();
        }

        public GameObject GetObjectAbove(ObjectPosition pos)
        {
            if (pos.Layer >= Layers.Count - 1)
                return null;

            ObjectCell cellAbove = GetCell(new ObjectPosition(pos.Layer + 1, pos.X, pos.Y));

            return cellAbove.IsEmpty ? null : cellAbove.GetObject();
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

        public void DuplicateObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell srcCell = GetCell(srcPos);
            ObjectCell destCell = GetCell(destPos);

            GameObject o = srcCell.GetObject();
            if (o != null)
                destCell.SetObjectEqual(o);
        }

        public void SwapObjects(ObjectPosition pos1, ObjectPosition pos2)
        {
            ObjectCell cell1 = GetCell(pos1);
            ObjectCell cell2 = GetCell(pos2);

            GameObject o1 = cell1.GetObject();
            GameObject o2 = cell2.GetObject();

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

        public List<GameObject> FindObjectsByTag(string tag)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectLayer layer in Layers)
            {
                List<GameObject> layerObjects = layer.FindObjectsByTag(tag);
                objects.AddRange(layerObjects);
            }

            return objects;
        }

        public GameObject FindObjectByTag(string tag)
        {
            foreach (ObjectLayer layer in Layers)
            {
                GameObject o = layer.FindObjectByTag(tag);
                if (o != null)
                    return o;
            }

            return null;
        }

        public List<ObjectPosition> FindObjectPositionsByTag(string tag)
        {
            List<ObjectPosition> positionsToReturn = new List<ObjectPosition>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<Point> layerPositions = layer.FindObjectPositionsByTag(tag);
                List<ObjectPosition> positionsToAdd = new List<ObjectPosition>();

                foreach (Point p in layerPositions)
                    positionsToAdd.Add(new ObjectPosition(layerIndex, p.X, p.Y));

                positionsToReturn.AddRange(positionsToAdd);
            }

            return positionsToReturn;
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

        public List<GameObject> FindObjectsByProperty(string property)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectLayer layer in Layers)
            {
                List<GameObject> layerObjects = layer.FindObjectsByProperty(property);
                objects.AddRange(layerObjects);
            }

            return objects;
        }

        public List<GameObject> FindObjectsByPropertyValue(string property, object value)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectLayer layer in Layers)
            {
                List<GameObject> layerObjects = layer.FindObjectsByPropertyValue(property, value.ToString());
                objects.AddRange(layerObjects);
            }

            return objects;
        }

        public GameObject GetObjectAtDistance(ObjectPosition pos, int dx, int dy)
        {
            ObjectCell cell = GetCell(ObjectPosition.AtDistance(pos, dx, dy));

            return cell.IsEmpty ? null : cell.GetObject();
        }

        public List<GameObject> FindObjectsEqual(GameObject o)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectLayer layer in Layers)
            {
                List<GameObject> layerObjects = layer.FindObjectsEqual(o);
                objects.AddRange(layerObjects);
            }

            return objects;
        }

        public void ReplaceObjects(GameObject original, GameObject replacement)
        {
            List<GameObject> originals = FindObjectsEqual(original);

            foreach (GameObject o in originals)
                o.SetEqual(replacement);
        }

        public void MoveObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            DuplicateObject(srcPos, destPos);
            DeleteObject(srcPos);
        }

        public void MoveObjectWithTag(ObjectPosition destPos, string tag)
        {
            ObjectPosition pos = FindObjectPositionByTag(tag);
            if (pos != null)
                MoveObject(pos, destPos);
        }

        public bool MoveObjectIfDestinationIsEmpty(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell destCell = GetCell(destPos);

            if (destCell.IsEmpty)
            {
                MoveObject(srcPos, destPos);
                return true;
            }

            return false;
        }

        public GameObject MoveObjectGetPrevious(ObjectPosition srcPos, ObjectPosition destPos)
        {
            GameObject previousObject = null;
            ObjectCell destCell = GetCell(destPos);
            if (!destCell.IsEmpty)
                previousObject = destCell.GetObjectCopy();

            MoveObject(srcPos, destPos);

            return previousObject;
        }

        public bool MoveObjectIfDestinationHasTag(ObjectPosition srcPos, ObjectPosition destPos, string tag)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.HasTag && o.Tag.Equals(tag))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public bool MoveObjectIfDestinationHasProperty(ObjectPosition srcPos, ObjectPosition destPos, string property)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.HasProperty(property))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public bool MoveObjectIfDestinationHasPropertyValue(ObjectPosition srcPos, ObjectPosition destPos, string property, object value)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.HasProperty(property) && o.GetProperty(property).Equals(value.ToString()))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }
    }
}
