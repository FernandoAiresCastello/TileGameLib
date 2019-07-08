using System;

namespace TileGameLib.Util
{
    public static class ByteExtensions
    {
        public static bool IsBitSet(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (b & (1 << pos)) != 0;
        }

        public static byte SetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            char[] bits = b.ToBinaryString().ToCharArray();
            bits[pos] = '1';
            return Convert.ToByte(new string(bits), 2);
        }

        public static byte UnsetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            char[] bits = b.ToBinaryString().ToCharArray();
            bits[pos] = '0';
            return Convert.ToByte(new string(bits), 2);
        }

        public static byte ToggleBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (byte)(b ^ (1 << pos));
        }

        public static byte ReverseBits(this byte b)
        {
            byte result = 0x00;

            for (byte mask = 0x80; Convert.ToInt32(mask) > 0; mask >>= 1)
            {
                result = (byte)(result >> 1);

                if ((byte)(b & mask) != 0x00)
                    result = (byte)(result | 0x80);
            }

            return result;
        }

        public static byte InvertBits(this byte b)
        {
            return (byte)(b ^ 255);
        }

        public static string ToBinaryString(this byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        public static byte RotateLeft(this byte b)
        {
            const byte mask = 0xff;
            return (byte)(((b << 1) | (b >> 7)) & mask);
        }

        public static byte RotateRight(this byte b)
        {
            const byte mask = 0xff;
            return (byte)(((b >> 1) | (b << 7)) & mask);
        }
    }
}
