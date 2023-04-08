namespace TileGameLib
{
    /// <summary>
    /// Represents any rectangular area
    /// </summary>
    public struct Rect
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public Rect(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public bool Contains(int x, int y)
        {
            return x >= x1 && x <= x2 && y >= y1 && y <= y2;
        }
    }
}
