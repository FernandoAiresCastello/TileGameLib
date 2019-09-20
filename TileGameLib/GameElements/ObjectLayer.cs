using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class ObjectLayer
    {
        public ObjectCell[,] Cells { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObjectLayer(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new ObjectCell[width, height];

            for (int row = 0; row < height; row++)
                for (int col = 0; col < width; col++)
                    Cells[col, row] = new ObjectCell();
        }

        public void SetEqual(ObjectLayer other)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    GameObject o = other.GetObjectRef(col, row);

                    if (o != null)
                        Cells[col, row].SetObjectEqual(o);
                    else
                        Cells[col, row].DeleteObject();
                }
            }
        }

        public void Clear()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Cells[col, row].DeleteObject();
        }

        public void Fill(GameObject o)
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Cells[col, row].SetObjectEqual(o);
        }

        public void SetObject(GameObject o, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                Cells[x, y].SetObjectEqual(o);
            else
                throw new TileGameLibException(GetExceptionMessage(x, y));
        }

        public void DeleteObject(int x, int y)
        {
            Cells[x, y].DeleteObject();
        }

        public ref ObjectCell GetCell(int x, int y)
        {
            return ref Cells[x, y];
        }

        public ref GameObject GetObjectRef(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return ref Cells[x, y].GetObjectRef();

            throw new TileGameLibException(GetExceptionMessage(x, y));
        }

        public GameObject GetObjectCopy(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Cells[x, y].GetObjectCopy();

            throw new TileGameLibException(GetExceptionMessage(x, y));
        }

        private string GetExceptionMessage(int x, int y)
        {
            return string.Format("Invalid object layer index. X:{0} Y:{1} Layer size:{2}x{3}", x, y, Width, Height);
        }

        public void Resize(int width, int height)
        {
            ObjectCell[,] newCells = new ObjectCell[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col < Width && row < Height)
                        newCells[col, row] = new ObjectCell(Cells[col, row]);
                    else
                        newCells[col, row] = new ObjectCell();
                }
            }

            Cells = newCells;
            Width = width;
            Height = height;
        }

        public List<GameObject> FindObjectsEqual(GameObject other)
        {
            List<GameObject> objects = new List<GameObject>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    ObjectCell cell = Cells[col, row];
                    if (!cell.IsEmpty && cell.GetObjectRef().Equals(other))
                        objects.Add(cell.GetObjectRef());
                }
            }

            return objects;
        }

        public List<GameObject> FindObjectsByTag(string tag)
        {
            List<GameObject> objects = new List<GameObject>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    ObjectCell cell = Cells[col, row];
                    if (!cell.IsEmpty && cell.GetObjectRef().HasTag && cell.GetObjectRef().Tag.Equals(tag))
                        objects.Add(cell.GetObjectRef());
                }
            }

            return objects;
        }

        public List<GameObject> FindObjectsByProperty(string property)
        {
            List<GameObject> objects = new List<GameObject>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    ObjectCell cell = Cells[col, row];
                    if (!cell.IsEmpty && cell.GetObjectRef().Properties.HasProperty(property))
                        objects.Add(cell.GetObjectRef());
                }
            }

            return objects;
        }

        public List<GameObject> FindObjectsByPropertyValue(string property, object value)
        {
            List<GameObject> objects = new List<GameObject>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    ObjectCell cell = Cells[col, row];
                    if (!cell.IsEmpty && cell.GetObjectRef().Properties.HasPropertyValue(property, value.ToString()))
                        objects.Add(cell.GetObjectRef());
                }
            }

            return objects;
        }

        public List<Point> FindObjectPositionsByTag(string tag)
        {
            List<Point> positions = new List<Point>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    ObjectCell cell = Cells[col, row];
                    if (!cell.IsEmpty && cell.GetObjectRef().HasTag && cell.GetObjectRef().Tag.Equals(tag))
                        positions.Add(new Point(col, row));
                }
            }

            return positions;
        }

        public GameObject FindObjectByTag(string tag)
        {
            List<GameObject> objects = FindObjectsByTag(tag);

            if (objects.Count >= 1)
                return objects[0];

            return null;
        }

        public Point? FindObjectPositionByTag(string tag)
        {
            List<Point> positions = FindObjectPositionsByTag(tag);

            if (positions.Count >= 1)
                return positions[0];

            return null;
        }
    }
}
