using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TileGameLib
{
    public class PixelBuffer
    {
        public int Width => width;
        public int Height => height;

        private readonly int width;
        private readonly int height;
        private readonly Texture2D tex;
        private readonly Color32[] pixels;
        private readonly RawImage image;

        public PixelBuffer(RawImage targetImage, int width, int height)
        {
            this.width = width;
            this.height = height;

            tex = new Texture2D(width, height, TextureFormat.RGBA32, -1, false);
            tex.filterMode = FilterMode.Point;
            pixels = tex.GetPixels32(0);

            image = targetImage;
            image.texture = tex;
            image.uvRect = new UnityEngine.Rect(0, 0, 1, -1);

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

        public void ClearRect(Rect rect, Rgb color)
        {
            for (int y = rect.y1; y <= rect.y2; y++)
                for (int x = rect.x1; x <= rect.x2; x++)
                    SetPixel(x, y, color);
        }

        public void SetPixel(int x, int y, Rgb color)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
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
}
