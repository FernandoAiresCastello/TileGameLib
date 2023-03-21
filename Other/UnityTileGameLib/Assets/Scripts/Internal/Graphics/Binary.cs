namespace TileGameLib
{
    public struct Binary
    {
        public static readonly char Bit0 = '0';
        public static readonly char Bit1 = '1';

        public string Bits => _value;
        public int Length => _value.Length;

        private string _value;

        public static implicit operator Binary(string value)
        {
            return new Binary { _value = value };
        }

        public static implicit operator string(Binary value)
        {
            return value._value;
        }
    }
}
