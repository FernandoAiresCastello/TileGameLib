using System;
using System.Collections;
using System.Collections.Generic;

public struct Tile
{
    public Rgb[] pixels;

    public static readonly int size = 8;
    public static readonly Rgb binaryForeColor = 0x000000;
    public static readonly Rgb binaryBackColor = 0xffffff;

    private static readonly int width = size;
    private static readonly int height = size;
    private static readonly int pixelCount = width * height;

    public Tile(Rgb[] pixels)
    {
        this.pixels = pixels;
    }

    public Tile(Binary pixels)
    {
        if (pixels.Length != pixelCount)
            throw new ArgumentException("Binary string contains less than " + pixelCount + " characters");

        this.pixels = new Rgb[pixelCount];
        int index = 0;

        foreach (char bit in pixels.Bits)
        {
            if (bit == '0')
                this.pixels[index] = Tile.binaryBackColor;
            else if (bit == '1')
                this.pixels[index] = Tile.binaryForeColor;
            else
                throw new ArgumentException("Binary string contains invalid characters");
        }
    }
}
