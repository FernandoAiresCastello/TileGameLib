using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TileGameLib
{
    /// <summary>
    /// Used for drawing graphical tiles on the screen.
    /// </summary>
    public class TileDisplay
    {
        public int Width => buf.Width;
        public int Height => buf.Height;
        public int Cols => buf.Width / Tile.size;
        public int Rows => buf.Height / Tile.size;

        private Rgb backColor;
        private ColorMode colorMode;
        private BinaryColor binaryColor;
        private readonly GameObject gameObject;
        private readonly PixelBuffer buf;
        private readonly RawImage img;
        private readonly Font font;
        private readonly FontStyle fontStyle;
        private readonly TileAnimation animation;
        private readonly Viewset views;

        public TileDisplay(int width, int height, Rgb backColor)
        {
            if (Camera.main == null)
                throw new NullReferenceException("Main camera not found");

            gameObject = new GameObject("TileGameLib Display");

            img = gameObject.AddComponent<RawImage>();
            buf = new PixelBuffer(img, width, height);

            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;

            this.backColor = backColor;
            binaryColor = new BinaryColor(0x000000, 0xffffff, false);
            font = new Font();
            fontStyle = new FontStyle(0x000000, 0xffffff, false, true, 0xd0d0d0);
            animation = new TileAnimation();

            views = new Viewset();
            views.AddDefault(0, 0, width, height, backColor);
            views.SelectDefault();

            ColorNormal();
            Clear();
            Update();
        }

        public void ResizeWindow(int width, int height)
        {
            Screen.SetResolution(width, height, false);
        }

        public void Fullscreen(bool full)
        {
            Screen.fullScreen = full;
        }

        public void Update()
        {
            buf.Update();
            animation.NextFrame();
        }

        public void Clear()
        {
            buf.Clear(backColor);
        }

        private void ClearViewRect(View view)
        {
            buf.ClearRect(view.Rect, view.backColor);
        }

        public void DrawTestFrame()
        {
            for (int y = 0; y < buf.Height; y++)
                for (int x = 0; x < buf.Width; x++)
                    buf.SetPixel(x, y, Random.Range(0x000000, 0xffffff));
        }

        public void AddView(string id, int x1, int y1, int x2, int y2, Rgb backColor)
        {
            views.Add(id, x1, y1, x2, y2, backColor);
        }

        public void View(string id)
        {
            views.Select(id);
            ClearViewRect(views.Selected);
        }

        public void Scroll(string viewId, int dx, int dy)
        {
            views.Get(viewId).Scroll(dx, dy);
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

        public void FontColor(Rgb foreColor)
        {
            fontStyle.color.foreground = foreColor;
        }

        public void FontColor(Rgb foreColor, Rgb backColor)
        {
            fontStyle.color.foreground = foreColor;
            fontStyle.color.background = backColor;
        }

        public void FontColor(Rgb foreColor, Rgb backColor, Rgb shadowColor)
        {
            fontStyle.color.foreground = foreColor;
            fontStyle.color.background = backColor;
            fontStyle.shadowColor = shadowColor;
        }

        public void FontTransparent(bool transparent)
        {
            fontStyle.color.transparent = transparent;
        }

        public void FontShadow(bool enable)
        {
            fontStyle.shadow = enable;
        }

        public void FontShadow(Rgb color)
        {
            fontStyle.shadow = true;
            fontStyle.shadowColor = color;
        }

        public void AnimationSpeed(int speed)
        {
            animation.Speed(speed);
        }

        public void DrawTiled(TileSeq tileSeq, int x, int y)
        {
            DrawFree(tileSeq, x * Tile.size, y * Tile.size);
        }

        public void DrawFree(TileSeq tileSeq, int x, int y)
        {
            Rect rect = views.Selected.Rect;
            x += rect.x1 - views.Selected.scrollX;
            y += rect.y1 - views.Selected.scrollY;

            int initialX = x;

            foreach (Rgb color in tileSeq.Get(animation.Frame).pixels)
            {
                if (rect.Contains(x, y))
                {
                    if (colorMode == ColorMode.Normal)
                    {
                        buf.SetPixel(x, y, color);
                    }
                    else if (colorMode == ColorMode.Binary)
                    {
                        if (color == Tile.binaryForeColor)
                            buf.SetPixel(x, y, binaryColor.foreground);
                        else if (color == Tile.binaryBackColor && !binaryColor.transparent)
                            buf.SetPixel(x, y, binaryColor.background);
                    }
                    else if (colorMode == ColorMode.Text)
                    {
                        if (color == Tile.binaryForeColor)
                            buf.SetPixel(x, y, fontStyle.color.foreground);
                        else if (color == Tile.binaryBackColor && !fontStyle.color.transparent)
                            buf.SetPixel(x, y, fontStyle.color.background);
                    }
                }

                x++;
                if (x >= initialX + Tile.size) {
                    x = initialX;
                    y++;
                }
            }
        }

        public void PrintTiled(string text, int x, int y)
        {
            PrintFree(text, x * Tile.size, y * Tile.size);
        }

        public void PrintFree(string text, int x, int y)
        {
            ColorMode prevMode = colorMode;
            BinaryColor prevColor = fontStyle.color;

            colorMode = ColorMode.Text;

            int px = x;

            if (fontStyle.shadow && fontStyle.color.transparent)
            {
                fontStyle.color.foreground = fontStyle.shadowColor;

                foreach (char ch in text)
                {
                    DrawFree(font.GetTile(ch), x + 1, y + 1);
                    x += Tile.size;
                }
            }

            x = px;
            fontStyle.color = prevColor;

            foreach (char ch in text)
            {
                DrawFree(font.GetTile(ch), x, y);
                x += Tile.size;
            }

            colorMode = prevMode;
        }
    }
}
