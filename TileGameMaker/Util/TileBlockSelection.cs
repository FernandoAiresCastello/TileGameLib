using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.Util
{
    public class TileBlockSelection
    {
        public Point? StartPoint { set; get; } = null;
        public Point? EndPoint { set; get; } = null;
        public Rectangle? Block => CalculateBlock();
        public List<Point> Points => BlockToPoints();

        public TileBlockSelection()
        {
        }

        public override string ToString()
        {
            return $"StartPoint: {StartPoint} EndPoint: {EndPoint} Block: {Block} Points: {Points.Count}";
        }

        private Rectangle? CalculateBlock()
        {
            if (StartPoint == null)
                return null;

            if (EndPoint == null)
                return new Rectangle(StartPoint.Value, new Size(1, 1));

            return new Rectangle(StartPoint.Value, new Size(
                EndPoint.Value.X - StartPoint.Value.X, EndPoint.Value.Y - StartPoint.Value.Y));
        }

        private List<Point> BlockToPoints()
        {
            List<Point> points = new List<Point>();

            if (Block.HasValue)
            {
                Rectangle rect = Block.Value;

                for (int x = rect.X; x < rect.X + rect.Width; x++)
                    for (int y = rect.Y; y < rect.Y + rect.Height; y++)
                        points.Add(new Point(x, y));
            }

            return points;
        }
    }
}
