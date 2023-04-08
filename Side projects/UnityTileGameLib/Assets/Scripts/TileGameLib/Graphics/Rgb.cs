namespace TileGameLib
{
    /// <summary>
    /// Represents a color in 24-bit RGB format (0x000000 to 0xffffff).
    /// </summary>
    public struct Rgb
    {
        private int _value;

        public static implicit operator Rgb(int value)
        {
            return new Rgb { _value = value };
        }

        public static implicit operator int(Rgb value)
        {
            return value._value;
        }

        public override string ToString()
        {
            return "0x" + _value.ToString("X6");
        }
    }
}
