using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Graphics
{
    public class Palette
    {
        public static readonly int DefaultSize = 256;
        public List<int> Colors { get; private set; } = new List<int>();
        public int Size => Colors.Count;
        public int White => GetWhite();
        public int Black => GetBlack();

        public Palette()
        {
            InitDefault();
        }

        public void Add(uint color)
        {
            Colors.Add((int)color);
        }

        public void Add(int color)
        {
            Colors.Add(color);
        }

        public void Add(Color color)
        {
            Colors.Add(color.ToArgb());
        }

        public void Set(int index, uint color)
        {
            Set(index, (int)color);
        }

        public void Set(int index, Color color)
        {
            Set(index, color.ToArgb());
        }

        public void Set(int index, int r, int g, int b)
        {
            Set(index, Color.FromArgb(r, g, b));
        }

        public void Set(int index, int color)
        {
            Colors[index] = color;
        }

        public int Get(int index)
        {
            return Colors[index];
        }

        public Color GetColorObject(int index)
        {
            return Color.FromArgb(Colors[index]);
        }

        public void Clear()
        {
            Clear(DefaultSize, 0xFFffffff);
            Set(0, Color.Black);
        }

        public void Clear(int count, uint color)
        {
            Clear(count, (int)color);
        }

        public void Clear(int count, int color)
        {
            Colors.Clear();
            for (int i = 0; i < count; i++)
                Add(color);
        }

        public void Clear(int count, Color color)
        {
            Clear(count, color.ToArgb());
        }

        public void SetEmpty()
        {
            Colors.Clear();
        }

        public void SetEqual(Palette other)
        {
            Clear(other.Size, Color.White);
            for (int i = 0; i < Size; i++)
                Colors[i] = other.Colors[i];
        }

        private int GetBlack()
        {
            for (int index = 0; index < Colors.Count; index++)
            {
                Color color = GetColorObject(index);
                if (color.R == 0 && color.G == 0 && color.B == 0)
                    return index;
            }

            throw new TileGameLibException("Black color (0x000000) not found");
        }

        private int GetWhite()
        {
            for (int index = 0; index < Colors.Count; index++)
            {
                Color color = GetColorObject(index);
                if (color.R == 255 && color.G == 255 && color.B == 255)
                    return index;
            }

            throw new TileGameLibException("White color (0xffffff) not found");
        }

        public float GetBrightness(int index)
        {
            return GetBrightness(GetColorObject(index));
        }

        public static float GetBrightness(Color color)
        {
            float num = ((float)color.R) / 255f;
            float num2 = ((float)color.G) / 255f;
            float num3 = ((float)color.B) / 255f;
            float num4 = num;
            float num5 = num;
            if (num2 > num4)
                num4 = num2;
            if (num3 > num4)
                num4 = num3;
            if (num2 < num5)
                num5 = num2;
            if (num3 < num5)
                num5 = num3;
            return ((num4 + num5) / 2f);
        }

        public float GetHue(int index)
        {
            return GetHue(GetColorObject(index));
        }

        public static float GetHue(Color color)
        {
            if ((color.R == color.G) && (color.G == color.B))
                return 0f;
            float num = ((float)color.R) / 255f;
            float num2 = ((float)color.G) / 255f;
            float num3 = ((float)color.B) / 255f;
            float num7 = 0f;
            float num4 = num;
            float num5 = num;
            if (num2 > num4)
                num4 = num2;
            if (num3 > num4)
                num4 = num3;
            if (num2 < num5)
                num5 = num2;
            if (num3 < num5)
                num5 = num3;
            float num6 = num4 - num5;
            if (num == num4)
                num7 = (num2 - num3) / num6;
            else if (num2 == num4)
                num7 = 2f + ((num3 - num) / num6);
            else if (num3 == num4)
                num7 = 4f + ((num - num2) / num6);
            num7 *= 60f;
            if (num7 < 0f)
                num7 += 360f;
            return num7;
        }

        public float GetSaturation(int index)
        {
            return GetSaturation(GetColorObject(index));
        }

        public static float GetSaturation(Color color)
        {
            float num = ((float)color.R) / 255f;
            float num2 = ((float)color.G) / 255f;
            float num3 = ((float)color.B) / 255f;
            float num7 = 0f;
            float num4 = num;
            float num5 = num;
            if (num2 > num4)
                num4 = num2;
            if (num3 > num4)
                num4 = num3;
            if (num2 < num5)
                num5 = num2;
            if (num3 < num5)
                num5 = num3;
            if (num4 == num5)
                return num7;
            float num6 = (num4 + num5) / 2f;
            if (num6 <= 0.5)
                return ((num4 - num5) / (num4 + num5));
            return ((num4 - num5) / ((2f - num4) - num5));
        }

        public void InitDefault()
        {
            Clear();

            int i = 0;

            Set(i++, 0xFF000000);
            Set(i++, 0xFF000055);
            Set(i++, 0xFF0000aa);
            Set(i++, 0xFF0000ff);
            Set(i++, 0xFF550000);
            Set(i++, 0xFF550055);
            Set(i++, 0xFF5500aa);
            Set(i++, 0xFF5500ff);
            Set(i++, 0xFFaa0000);
            Set(i++, 0xFFaa0055);
            Set(i++, 0xFFaa00aa);
            Set(i++, 0xFFaa00ff);
            Set(i++, 0xFFff0000);
            Set(i++, 0xFFff0055);
            Set(i++, 0xFFff00aa);
            Set(i++, 0xFFff00ff);
            Set(i++, 0xFF005500);
            Set(i++, 0xFF005555);
            Set(i++, 0xFF0055aa);
            Set(i++, 0xFF0055ff);
            Set(i++, 0xFF555500);
            Set(i++, 0xFF555555);
            Set(i++, 0xFF5555aa);
            Set(i++, 0xFF5555ff);
            Set(i++, 0xFFaa5500);
            Set(i++, 0xFFaa5555);
            Set(i++, 0xFFaa55aa);
            Set(i++, 0xFFaa55ff);
            Set(i++, 0xFFff5500);
            Set(i++, 0xFFff5555);
            Set(i++, 0xFFff55aa);
            Set(i++, 0xFFff55ff);
            Set(i++, 0xFF00aa00);
            Set(i++, 0xFF00aa55);
            Set(i++, 0xFF00aaaa);
            Set(i++, 0xFF00aaff);
            Set(i++, 0xFF55aa00);
            Set(i++, 0xFF55aa55);
            Set(i++, 0xFF55aaaa);
            Set(i++, 0xFF55aaff);
            Set(i++, 0xFFaaaa00);
            Set(i++, 0xFFaaaa55);
            Set(i++, 0xFFaaaaaa);
            Set(i++, 0xFFaaaaff);
            Set(i++, 0xFFffaa00);
            Set(i++, 0xFFffaa55);
            Set(i++, 0xFFffaaaa);
            Set(i++, 0xFFffaaff);
            Set(i++, 0xFF00ff00);
            Set(i++, 0xFF00ff55);
            Set(i++, 0xFF00ffaa);
            Set(i++, 0xFF00ffff);
            Set(i++, 0xFF55ff00);
            Set(i++, 0xFF55ff55);
            Set(i++, 0xFF55ffaa);
            Set(i++, 0xFF55ffff);
            Set(i++, 0xFFaaff00);
            Set(i++, 0xFFaaff55);
            Set(i++, 0xFFaaffaa);
            Set(i++, 0xFFaaffff);
            Set(i++, 0xFFffff00);
            Set(i++, 0xFFffff55);
            Set(i++, 0xFFffffaa);
            Set(i++, 0xFFffffff);
        }
    }
}
