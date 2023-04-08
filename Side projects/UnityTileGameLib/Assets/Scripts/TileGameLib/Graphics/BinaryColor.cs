namespace TileGameLib
{
    /// <summary>
    /// Color information to be used when drawing tiles in the binary <see cref="ColorMode"/>
    /// </summary>
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
