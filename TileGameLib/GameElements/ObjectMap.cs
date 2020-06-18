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
        public string Id { set; get; }
        public string Name { set; get; }
        public List<ObjectLayer> Layers { set; get; } = new List<ObjectLayer>();
        public Tileset Tileset { get; set; } = new Tileset();
        public Palette Palette { get; set; } = new Palette();
        public int BackColor { set; get; }
        public string MusicFile { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string ScriptFile { get; set; }
        public int ImageWidth => Width * TilePixels.RowLength;
        public int ImageHeight => Height * TilePixels.RowCount;
        public bool HasMusic => !string.IsNullOrWhiteSpace(MusicFile);

        public const string DefaultName = "Untitled";

        public ObjectMap(int width, int height) : this(DefaultName, width, height, 0)
        {
            GenerateId();
            BackColor = Palette.White;
        }

        public ObjectMap(string name, int width, int height, int backColor)
        {
            GenerateId();

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

        public void GenerateId()
        {
            Id = RandomID.Generate(8);
        }

        public void SetEqual(ObjectMap other)
        {
            Id = other.Id;
            Name = other.Name;
            Width = other.Width;
            Height = other.Height;
            BackColor = other.BackColor;
            MusicFile = other.MusicFile;
            ScriptFile = other.ScriptFile;
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

        public void PutObject(GameObject o, ObjectPosition pos)
        {
            Layers[pos.Layer].PutObject(o, pos.X, pos.Y);
        }

        public void SetObject(GameObject o, ObjectPosition pos)
        {
            Layers[pos.Layer].SetObject(o, pos.X, pos.Y);
        }

        public void SetObjects(GameObject o, List<ObjectPosition> positions)
        {
            foreach (ObjectPosition pos in positions)
                SetObject(o, pos);
        }

        public void SetHorizontalStringOfObjects(string text, ObjectPosition pos, int foreColor, int backColor)
        {
            int initialX = pos.X;
            text = text.Replace("\r", "");

            foreach (char ch in text)
            {
                if (ch == '\n')
                {
                    pos = pos.South();
                    pos.MoveTo(initialX, pos.Y);
                }
                else
                {
                    if (IsWithinBounds(pos))
                    {
                        GameObject o = new GameObject(new Tile(ch, foreColor, backColor));
                        SetObject(o, pos);
                        pos = pos.East();
                    }
                }
            }
        }

        public void SetVerticalStringOfObjects(string text, ObjectPosition pos, int foreColor, int backColor)
        {
            int initialY = pos.Y;
            text = text.Replace("\r", "");

            foreach (char ch in text)
            {
                if (ch == '\n')
                {
                    pos = pos.East();
                    pos.MoveTo(pos.X, initialY);
                }
                else
                {
                    if (IsWithinBounds(pos))
                    {
                        GameObject o = new GameObject(new Tile(ch, foreColor, backColor));
                        SetObject(o, pos);
                        pos = pos.South();
                    }
                }
            }
        }

        public bool IsOutOfBounds(ObjectPosition pos)
        {
            return !IsWithinBounds(pos);
        }

        public bool IsWithinBounds(ObjectPosition pos)
        {
            return 
                pos.Layer >= 0 && pos.Layer < Layers.Count && 
                pos.X >= 0 && pos.X < Width && 
                pos.Y >= 0 && pos.Y < Height;
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

        public PositionedObject GetPositionedObject(ObjectPosition pos)
        {
            return new PositionedObject(this, GetObject(pos), pos);
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

        public PositionedObject FindObjectByProperty(string property)
        {
            List<PositionedObject> objs = FindObjectsByProperty(property);

            if (objs.Count > 1)
                throw new TileGameLibException($"Multiple ({objs.Count}) objects found with property {property}");

            return objs.Count == 1 ? objs[0] : null;
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

        public PositionedObject FindObjectByPropertyValue(string property, object value)
        {
            List<PositionedObject> objs = FindObjectsByPropertyValue(property, value);

            if (objs.Count > 1)
                throw new TileGameLibException($"Multiple ({objs.Count}) objects found with property {property} = {value}");

            return objs.Count == 1 ? objs[0] : null;
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

        public List<PositionedObject> FindObjectsPartiallyEqual(GameObject other, bool compareTileIndex, bool compareTileForeColor, bool compareTileBackColor, bool compareProperties)
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

                        if (o != null)
                        {
                            bool comparisonOk = false;

                            if (compareTileIndex && o.Tile.Index == other.Tile.Index)
                                comparisonOk = true;
                            if (compareTileForeColor && o.Tile.ForeColor == other.Tile.ForeColor)
                                comparisonOk = true;
                            if (compareTileBackColor && o.Tile.BackColor == other.Tile.BackColor)
                                comparisonOk = true;
                            if (compareProperties && o.Properties.Equals(other.Properties))
                                comparisonOk = true;

                            if (comparisonOk && (o.Visible == other.Visible))
                                layerPositions.Add(new PositionedObject(this, o, layerIndex, x, y));
                        }
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
    }
}
