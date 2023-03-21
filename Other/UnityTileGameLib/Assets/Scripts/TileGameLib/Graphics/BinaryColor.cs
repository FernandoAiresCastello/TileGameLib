namespace TileGameLib
{
    public struct BinaryColor
    {
        public Rgb foreground;
        public Rgb background;
        public bool transparent;

        public BinaryColor(Rgb foreground, Rgb background, bool transparent)
        {
            this.foreground = foreground;
            this.background = background;
            this.transparent = transparent;
        }
    }
}
