namespace TileGameLib
{
    public struct BinaryString
    {
        public static readonly char Bit0 = '0';
        public static readonly char Bit1 = '1';

        public string Bits => _value;
        public int Length => _value.Length;

        private string _value;

        public static implicit operator BinaryString(string value)
        {
            return new BinaryString { _value = value };
        }

        public static implicit operator string(BinaryString value)
        {
            return value._value;
        }
    }
}
