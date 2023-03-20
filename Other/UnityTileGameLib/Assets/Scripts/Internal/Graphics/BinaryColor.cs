namespace TileGameLib
{
    public struct BinaryColor
    {
        public Rgb foreground;
        public Rgb background;

        public BinaryColor(Rgb foreground, Rgb background)
        {
            this.foreground = foreground;
            this.background = background;
        }
    }
}
