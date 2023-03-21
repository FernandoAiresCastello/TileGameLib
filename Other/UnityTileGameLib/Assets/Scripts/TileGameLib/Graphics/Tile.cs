using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public struct Tile
    {
        public Rgb[] pixels;

        public static readonly int size = 8;
        public static readonly int pixelCount = size * size;
        public static readonly Rgb binaryForeColor = 0x000000;
        public static readonly Rgb binaryBackColor = 0xffffff;

        public static Tile Blank => new Tile(
            Enumerable.Repeat<Rgb>(0x000000, pixelCount).ToArray());

        public Tile(Rgb[] pixelColors)
        {
            pixels = pixelColors;
        }

        public Tile(Binary binaryString)
        {
            if (binaryString.Length != pixelCount)
                throw new ArgumentException("Binary string must contain exactly " + pixelCount + " characters");

            this.pixels = new Rgb[pixelCount];

            for (int i = 0; i < binaryString.Length; i++)
            {
                char bit = binaryString.Bits[i];
                if (bit == Binary.Bit0)
                    pixels[i] = binaryBackColor;
                else if (bit == Binary.Bit1)
                    pixels[i] = binaryForeColor;
                else
                    throw new ArgumentException("Binary string contains invalid characters");
            }
        }

        public string ToString()
        {
            string str = "";

            for (int i = 0; i < pixelCount; i++)
            {
                string color = pixels[i].ToString();
                str += color;
                if (i < pixelCount - 1)
                    str += ",";
            }

            return str;
        }

        public Binary ToBinary()
        {
            string str = "";

            for (int i = 0; i < pixelCount; i++)
            {
                Rgb color = pixels[i];
                if (color == binaryBackColor)
                    str += Binary.Bit0;
                else if (color == binaryForeColor)
                    str += Binary.Bit1;
                else
                    throw new ArgumentException("Binary string contains invalid characters");
            }

            return str;
        }
    }
}
