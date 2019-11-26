using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
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

        public static string DefaultName => RandomID.Generate(8);

        public ObjectMap(int width, int height) : this(DefaultName, width, height, 0)
        {
            BackColor = Palette.White;
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

        public void Resize(int width, int height)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Resize(width, height);

            Width = width;
            Height = height;
        }

        public void Enlarge(int horizontal, int vertical)
        {
            Resize(Width + horizontal, Height + vertical);
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

        public void FillEmptyCells(GameObject o, int layer)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (Layers[layer].GetCell(x, y).IsEmpty)
                        Layers[layer].SetObject(o, x, y);
                }
            }
        }

        public void SetObject(GameObject o, ObjectPosition pos)
        {
            Layers[pos.Layer].SetObject(o, pos.X, pos.Y);
        }

        public void SetStringOfObjects(string text, ObjectPosition pos, int foreColor, int backColor)
        {
            foreach (char ch in text)
            {
                GameObject o = new GameObject(new Tile(ch, foreColor, backColor));
                SetObject(o, pos);
                pos = pos.East();
            }
        }

        public void CreateNewObject(ObjectPosition pos)
        {
            SetObject(new GameObject(), pos);
        }

        public void DuplicateObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell srcCell = GetCell(srcPos);
            ObjectCell destCell = GetCell(destPos);

            GameObject o = srcCell.Object;
            if (o != null)
                destCell.SetObjectEqual(o);
        }

        public void SwapObjects(ObjectPosition pos1, ObjectPosition pos2)
        {
            ObjectCell cell1 = GetCell(pos1);
            ObjectCell cell2 = GetCell(pos2);

            GameObject o1 = cell1.Object;
            GameObject o2 = cell2.Object;

            if (o1 != null && o2 != null)
            {
                GameObject temp = cell1.Object;
                cell1.SetObjectEqual(o2);
                cell2.SetObjectEqual(temp);
            }
        }

        public void DeleteObject(ObjectPosition pos)
        {
            ObjectCell srcCell = GetCell(pos);
            srcCell.DeleteObject();
        }

        public ObjectCell GetCell(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetCell(pos.X, pos.Y);
        }

        public List<ObjectCell> GetCells(List<ObjectPosition> positions)
        {
            List<ObjectCell> cells = new List<ObjectCell>();

            foreach (ObjectPosition pos in positions)
                cells.Add(GetCell(pos));

            return cells;
        }

        public GameObject GetObject(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetObject(pos.X, pos.Y);
        }

        public List<GameObject> GetObjects(List<ObjectPosition> positions)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectPosition pos in positions)
                objects.Add(GetObject(pos));

            return objects;
        }

        public PositionedObject GetObjectUnder(ObjectPosition pos)
        {
            if (pos.Layer <= 0)
                return null;

            ObjectPosition under = pos.Under();
            ObjectCell cellUnder = GetCell(under);
            PositionedObject po = new PositionedObject(this, cellUnder.Object, under);

            return po;
        }

        public PositionedObject GetObjectAbove(ObjectPosition pos)
        {
            if (pos.Layer >= Layers.Count - 1)
                return null;

            ObjectPosition above = pos.Above();
            ObjectCell cellAbove = GetCell(above);
            PositionedObject po = new PositionedObject(this, cellAbove.Object, above);

            return po;
        }

        public PositionedObject GetObjectAtDistance(ObjectPosition pos, int dx, int dy)
        {
            ObjectPosition atDistance = pos.AtDistance(dx, dy);
            ObjectCell cell = GetCell(atDistance);
            PositionedObject po = new PositionedObject(this, cell.Object, atDistance);

            return po;
        }

        public PositionedObject FindObjectById(string id)
        {
            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Id.Equals(id))
                            return new PositionedObject(this, o, layerIndex, x, y);
                    }
                }
            }

            return null;
        }

        public PositionedObject FindObjectByTag(string tag)
        {
            List<PositionedObject> objects = FindObjectsByTag(tag);

            if (objects.Count > 1)
                throw new TileGameLibException("Multiple objects found with tag " + tag);
            if (objects.Count == 1)
                return objects[0];

            return null;
        }

        public List<PositionedObject> FindObjectsByTag(string tag)
        {
            List<PositionedObject> objects = new List<PositionedObject>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<PositionedObject> layerPositions = new List<PositionedObject>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.HasTag && o.Tag.Equals(tag))
                            layerPositions.Add(new PositionedObject(this, o, layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<PositionedObject> FindObjectsByProperty(string property)
        {
            List<PositionedObject> objects = new List<PositionedObject>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<PositionedObject> layerPositions = new List<PositionedObject>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Properties.Has(property))
                            layerPositions.Add(new PositionedObject(this, o, layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<PositionedObject> FindObjectsByPropertyValue(string property, object value)
        {
            List<PositionedObject> objects = new List<PositionedObject>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<PositionedObject> layerPositions = new List<PositionedObject>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Properties.HasValue(property, value))
                            layerPositions.Add(new PositionedObject(this, o, layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<PositionedObject> FindObjectsEqual(GameObject other)
        {
            List<PositionedObject> objects = new List<PositionedObject>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<PositionedObject> layerPositions = new List<PositionedObject>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Equals(other))
                            layerPositions.Add(new PositionedObject(this, o, layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public void ReplaceObjects(GameObject original, GameObject replacement)
        {
            List<PositionedObject> originalPositions = FindObjectsEqual(original);

            foreach (PositionedObject originalPos in originalPositions)
                originalPos.Object.SetEqual(replacement);
        }

        public void MoveObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            string srcObjectId = GetObject(srcPos).Id;

            DuplicateObject(srcPos, destPos);
            DeleteObject(srcPos);

            GetObject(destPos).Id = srcObjectId;
        }

        public GameObject MoveObjectGetPrevious(ObjectPosition srcPos, ObjectPosition destPos)
        {
            GameObject previousObject = null;
            ObjectCell destCell = GetCell(destPos);
            if (!destCell.IsEmpty)
                previousObject = destCell.Object;

            MoveObject(srcPos, destPos);

            return previousObject;
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

        public bool MoveObjectIfDestinationHasTag(ObjectPosition srcPos, ObjectPosition destPos, string tag)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.Object;

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
                GameObject o = destCell.Object;

                if (o.Properties.Has(property))
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
                GameObject o = destCell.Object;

                if (o.Properties.HasValue(property, value))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public ObjectCollision FindCollisionBetweenIds(string idObject1, string idObject2)
        {
            PositionedObject posObject1 = FindObjectById(idObject1);
            PositionedObject posObject2 = FindObjectById(idObject2);

            if (posObject1.Position.X == posObject2.Position.X &&
                posObject1.Position.Y == posObject2.Position.Y)
            {
                return new ObjectCollision(posObject1, posObject2);
            }

            return null;
        }

        public ObjectCollision FindCollisionBetweenObjects(GameObject object1, GameObject object2)
        {
            return FindCollisionBetweenIds(object1.Id, object2.Id);
        }

        public List<ObjectCollision> FindCollisionsBetweenIdAndTags(string id, string tag)
        {
            PositionedObject objectPos = FindObjectById(id);
            List<PositionedObject> taggedObjectsPos = FindObjectsByTag(tag);
            HashSet<ObjectCollision> collisions = new HashSet<ObjectCollision>();

            foreach (PositionedObject taggedObjectPos in taggedObjectsPos)
            {
                if (objectPos.Position.X == taggedObjectPos.Position.X &&
                    objectPos.Position.Y == taggedObjectPos.Position.Y)
                {
                    collisions.Add(new ObjectCollision(objectPos, taggedObjectPos));
                }
            }

            return collisions.ToList();
        }

        public List<ObjectCollision> FindCollisionsBetweenTags(string tag1, string tag2)
        {
            List<PositionedObject> taggedObjectsPos1 = FindObjectsByTag(tag1);
            List<PositionedObject> taggedObjectsPos2 = FindObjectsByTag(tag2);
            HashSet<ObjectCollision> collisions = new HashSet<ObjectCollision>();

            foreach (PositionedObject pos1 in taggedObjectsPos1)
            {
                foreach (PositionedObject pos2 in taggedObjectsPos2)
                {
                    if (pos1.Position.X == pos2.Position.X &&
                        pos1.Position.Y == pos2.Position.Y)
                    {
                        collisions.Add(new ObjectCollision(pos1, pos2));
                    }
                }
            }

            return collisions.ToList();
        }

        public void CopyObjectBlock(ObjectCellBlock source, ObjectCellBlock dest)
        {
            source.CopyTo(dest);
        }

        public void CopyObjectBlock(string srcTopLeftTag, string destTopLeftTag, string widthPropertyName, string heightPropertyName)
        {
            ObjectCellBlock src = GetCellBlock(srcTopLeftTag, widthPropertyName, heightPropertyName);
            ObjectCellBlock dest = GetCellBlock(destTopLeftTag, widthPropertyName, heightPropertyName);
            src.CopyTo(dest);
        }

        public void MoveObjectBlock(ObjectCellBlock source, ObjectCellBlock dest)
        {
            CopyObjectBlock(source, dest);
            DeleteObjectBlock(source);
        }

        public void MoveObjectBlock(string srcTopLeftTag, string destTopLeftTag, string widthPropertyName, string heightPropertyName)
        {
            ObjectCellBlock src = GetCellBlock(srcTopLeftTag, widthPropertyName, heightPropertyName);
            ObjectCellBlock dest = GetCellBlock(destTopLeftTag, widthPropertyName, heightPropertyName);

            src.MoveTo(dest);
        }

        public void DeleteObjectBlock(ObjectCellBlock block)
        {
            block.DeleteObjects();
        }

        public ObjectCellBlock GetCellBlock(string topLeftTag, string widthPropertyName, string heightPropertyName)
        {
            PositionedObject topLeft = FindObjectByTag(topLeftTag);
            Size srcSize = new Size(
                topLeft.Object.Properties.GetAsNumber(widthPropertyName),
                topLeft.Object.Properties.GetAsNumber(heightPropertyName));

            return new ObjectCellBlock(this, topLeft.Position.Layer, new Rectangle(topLeft.Position.Point, srcSize));
        }
    }
}
