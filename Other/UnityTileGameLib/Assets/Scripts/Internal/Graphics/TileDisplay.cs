using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TileGameLib
{
    public class TileDisplay
    {
        private GameObject gameObject;
        private PixelBuffer buf;
        private RawImage img;
        private Rgb backColor;
        private ColorMode colorMode;
        private BinaryColor binaryColor;

        public TileDisplay()
        {
            gameObject = new GameObject(this.GetType().Name);

            img = gameObject.AddComponent<RawImage>();
            buf = new PixelBuffer(img, 256, 192);

            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;

            backColor = 0xffffff;
            binaryColor = new BinaryColor(0x000000, 0xffffff);

            ColorNormal();
            Clear();
            Update();
        }

        public void Update()
        {
            buf.Update();
        }

        public void Clear()
        {
            buf.Clear(backColor);
        }

        public void DrawTestFrame()
        {
            for (int y = 0; y < buf.Height; y++)
                for (int x = 0; x < buf.Width; x++)
                    buf.SetPixel(x, y, Random.Range(0x000000, 0xffffff));
        }

        public void ColorNormal()
        {
            colorMode = ColorMode.Normal;
        }

        public void ColorBinary(Rgb foreColor, Rgb backColor)
        {
            colorMode = ColorMode.Binary;
            binaryColor.foreground = foreColor;
            binaryColor.background = backColor;
        }

        public void DrawTileFree(Tile tile, int x, int y)
        {
            int px = x;

            foreach (Rgb color in tile.pixels)
            {
                if (colorMode == ColorMode.Normal)
                {
                    buf.SetPixel(x, y, color);
                }
                else if (colorMode == ColorMode.Binary)
                {
                    if (color == Tile.binaryForeColor)
                        buf.SetPixel(x, y, binaryColor.foreground);
                    else if (color == Tile.binaryBackColor)
                        buf.SetPixel(x, y, binaryColor.background);
                }

                x++;
                if (x >= px + Tile.width) {
                    x = px;
                    y++;
                }
            }
        }
    }
}
