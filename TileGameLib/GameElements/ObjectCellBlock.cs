using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.GameElements
{
    public class ObjectCellBlock
    {
        public int Layer { set; get; }
        public ObjectMap Map { set; get; }
        public Rectangle Area { set; get; }
        public PositionedCell[,] Cells => GetCells();
        public PositionedObject[,] Objects => GetObjects();

        public ObjectCellBlock(ObjectMap map, int layer, Rectangle area)
        {
            Map = map;
            Area = area;
            Layer = layer;
        }

        public bool SizeEquals(ObjectCellBlock other)
        {
            return Area.Width == other.Area.Width && Area.Height == other.Area.Height;
        }

        public void CopyTo(ObjectCellBlock other)
        {
            if (!SizeEquals(other))
                throw new TileGameLibException("The cell blocks must be the same width and height");

            int sourceLayer = Layer;
            int destLayer = other.Layer;
            int destX = other.Area.X;
            int destY = other.Area.Y;

            for (int sourceY = Area.Y; sourceY < Area.Y + Area.Height; sourceY++, destY++)
            {
                for (int sourceX = Area.X; sourceX < Area.X + Area.Width; sourceX++, destX++)
                {
                    ObjectPosition sourcePosition = new ObjectPosition(sourceLayer, sourceX, sourceY);
                    ObjectPosition destPosition = new ObjectPosition(destLayer, destX, destY);
                    GameObject sourceObject = Map.GetObject(sourcePosition);
                    Map.SetObject(sourceObject, destPosition);
                }
            }
        }

        public void MoveTo(ObjectCellBlock other)
        {
            CopyTo(other);
            DeleteObjects();
        }

        public void DeleteObjects()
        {
            for (int y = Area.Y; y < Area.Height; y++)
                for (int x = Area.X; x < Area.Width; x++)
                    Map.DeleteObject(new ObjectPosition(Layer, x, y));
        }

        private PositionedCell[,] GetCells()
        {
            PositionedCell[,] cells = new PositionedCell[Area.Width, Area.Height];

            for (int y = Area.Y; y < Area.Y + Area.Height; y++)
            {
                for (int x = Area.X; x < Area.X + Area.Width; x++)
                {
                    ObjectPosition position = new ObjectPosition(Layer, x, y);
                    ObjectCell cell = Map.GetCell(position);
                    cells[x, y] = new PositionedCell(cell, position);
                }
            }

            return cells;
        }

        private PositionedObject[,] GetObjects()
        {
            PositionedObject[,] objects = new PositionedObject[Area.Width, Area.Height];

            for (int y = Area.Y; y < Area.Y + Area.Height; y++)
            {
                for (int x = Area.X; x < Area.X + Area.Width; x++)
                {
                    ObjectPosition position = new ObjectPosition(Layer, x, y);
                    GameObject obj = Map.GetObject(position);
                    objects[x, y] = new PositionedObject(obj, position);
                }
            }

            return objects;
        }
    }
}
