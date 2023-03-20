using System;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public struct Tile
    {
        public Rgb[] pixels;

        public static readonly int size = 8;
        public static readonly int width = size;
        public static readonly int height = size;
        public static readonly int pixelCount = width * height;
        public static readonly Rgb binaryForeColor = 0x000000;
        public static readonly Rgb binaryBackColor = 0xffffff;

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
                if (bit == '0')
                    pixels[i] = Tile.binaryBackColor;
                else if (bit == '1')
                    pixels[i] = Tile.binaryForeColor;
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
    }
}
