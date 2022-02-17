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
        public int Layer { get; private set; }
        public ObjectMap Map { get; private set; }
        public Rectangle Area { get; private set; }
        public PositionedCell[,] Cells => GetCells();
        public PositionedObject[,] Objects => GetObjects();

        public ObjectCellBlock(ObjectMap map, int layer, Rectangle area)
        {
            Map = map;
            Area = new Rectangle(area.X, area.Y, area.Width, area.Height);
            Layer = layer;
        }

        public ObjectCellBlock(ObjectCellBlock other)
        {
            Map = other.Map;
            Area = new Rectangle(other.Area.X, other.Area.Y, other.Area.Width, other.Area.Height);
            Layer = other.Layer;
        }

        public bool SizeEquals(ObjectCellBlock other)
        {
            return Area.Width == other.Area.Width && Area.Height == other.Area.Height;
        }

        public void CopyTo(ObjectCellBlock other)
        {
            if (!SizeEquals(other))
                throw new TGLException("The cell blocks must be the same width and height");

            PositionedCell[,] srcCells = Cells;
            PositionedCell[,] destCells = other.Cells;

            for (int y = 0; y < Area.Height; y++)
            {
                for (int x = 0; x < Area.Width; x++)
                {
                    PositionedCell srcPosCell = srcCells[x, y];
                    PositionedCell destPosCell = destCells[x, y];
                    GameObject copiedObject = srcPosCell.Cell.Object;

                    if (copiedObject != null)
                        destPosCell.Cell.SetObjectEqual(copiedObject);
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
            for (int y = Area.Y; y < Area.Bottom; y++)
                for (int x = Area.X; x < Area.Right; x++)
                    Map.DeleteObject(new ObjectPosition(Layer, x, y));
        }

        private PositionedCell[,] GetCells()
        {
            PositionedCell[,] cells = new PositionedCell[Area.Width, Area.Height];

            for (int y = 0; y < Area.Height; y++)
            {
                for (int x = 0; x < Area.Width; x++)
                {
                    ObjectPosition position = new ObjectPosition(Layer, x + Area.X, y + Area.Y);
                    cells[x, y] = new PositionedCell(Map, position);
                }
            }

            return cells;
        }

        private PositionedObject[,] GetObjects()
        {
            PositionedObject[,] objects = new PositionedObject[Area.Width, Area.Height];

            for (int y = 0; y < Area.Height; y++)
            {
                for (int x = 0; x < Area.Width; x++)
                {
                    ObjectPosition position = new ObjectPosition(Layer, x + Area.X, y + Area.Y);
                    GameObject obj = Map.GetObject(position);
                    objects[x, y] = new PositionedObject(Map, obj, position);
                }
            }

            return objects;
        }
    }
}
