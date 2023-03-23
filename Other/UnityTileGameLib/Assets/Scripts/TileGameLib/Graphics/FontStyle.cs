namespace TileGameLib
{
    /// <summary>
    /// Styling information for the text font, such as colors and shadow.
    /// </summary>
    public class FontStyle
    {
        public BinaryColor color;
        public bool shadow;
        public Rgb shadowColor;

        public FontStyle(Rgb foreColor, Rgb backColor, bool transparent, bool shadow, Rgb shadowColor)
        {
            color.foreground = foreColor;
            color.background = backColor;
            color.transparent = transparent;
            this.shadow = shadow;
            this.shadowColor = shadowColor;
        }
    }
}
