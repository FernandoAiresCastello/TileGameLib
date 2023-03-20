using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelBuffer
{
    public int Width => width;
    public int Height => height;

    private int width;
    private int height;
    private Texture2D tex;
    private Color32[] pixels;
    private RawImage image;

    public PixelBuffer(RawImage targetImage, int width, int height)
    {
        this.width = width;
        this.height = height;

        tex = new Texture2D(width, height, TextureFormat.RGBA32, -1, false);
        tex.filterMode = FilterMode.Point;
        pixels = tex.GetPixels32(0);

        image = targetImage;
        image.texture = tex;
        image.uvRect = new Rect(0, 0, 1, -1);

        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = new Color32(0, 0, 0, 255);
    }

    public void Update()
    {
        tex.SetPixels32(pixels, 0);
        tex.Apply();
    }

    public void Clear(Rgb color)
    {
        for (int i = 0; i < pixels.Length; i++)
            SetPixel(i, color);
    }

    public void SetPixel(int x, int y, Rgb color)
    {
        SetPixel(y * tex.width + x, color);
    }

    private void SetPixel(int index, Rgb color)
    {
        byte r = (byte)((color & 0xff0000) >> 16);
        byte g = (byte)((color & 0x00ff00) >> 8);
        byte b = (byte)((color & 0x0000ff));

        pixels[index] = new Color32(r, g, b, 255);
    }
}
