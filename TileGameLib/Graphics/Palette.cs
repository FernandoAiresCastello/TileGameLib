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
        public List<int> Colors { get; private set; } = new List<int>();
        public int Size => Colors.Count;
        public int White => GetWhite();
        public int Black => GetBlack();

        private const Default DefaultPalette = Default.Classic;
        private const int DefaultSize = 256;

        public enum Default
        {
            Classic,
            MSX
        }

        public Palette(Default defaultPalette = DefaultPalette)
        {
            InitDefault(defaultPalette);
        }

        public static string[] GetDefaultPaletteNames()
        {
            return Enum.GetNames(typeof(Default));
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

        public void InitDefault(Default defaultPalette = DefaultPalette)
        {
            switch (defaultPalette)
            {
                case Default.Classic: InitDefaultClassic(); break;
                case Default.MSX: InitDefaultMSX(); break;

                default:
                    throw new TileGameLibException("Invalid palette default: " + defaultPalette);
            }
        }

        public void InitDefaultClassic()
        {
            Clear();
            int i = 0;

            Set(i++, 0xff000000);
            Set(i++, 0xffffffff);
            Set(i++, 0xffe0e0e0);
            Set(i++, 0xffc0c0c0);
            Set(i++, 0xff808080);
            Set(i++, 0xff505050);
            Set(i++, 0xff303030);
            Set(i++, 0xff101010);
            Set(i++, 0xff500000);
            Set(i++, 0xff800000);
            Set(i++, 0xffc00000);
            Set(i++, 0xffff0000);
            Set(i++, 0xffff5050);
            Set(i++, 0xffff8080);
            Set(i++, 0xffffc0c0);
            Set(i++, 0xffffe0e0);
            Set(i++, 0xffc02000);
            Set(i++, 0xffff5000);
            Set(i++, 0xffff8000);
            Set(i++, 0xffffc000);
            Set(i++, 0xffffc050);
            Set(i++, 0xffffc080);
            Set(i++, 0xffffa050);
            Set(i++, 0xff808050);
            Set(i++, 0xff505000);
            Set(i++, 0xff808000);
            Set(i++, 0xffc0c000);
            Set(i++, 0xffffff00);
            Set(i++, 0xffffff50);
            Set(i++, 0xffffff80);
            Set(i++, 0xffffffc0);
            Set(i++, 0xffc0c080);
            Set(i++, 0xff005000);
            Set(i++, 0xff008000);
            Set(i++, 0xff00c000);
            Set(i++, 0xff00ff00);
            Set(i++, 0xff80ff00);
            Set(i++, 0xff80ff80);
            Set(i++, 0xffc0ff00);
            Set(i++, 0xffc0ff80);
            Set(i++, 0xff005050);
            Set(i++, 0xff008080);
            Set(i++, 0xff00c0c0);
            Set(i++, 0xff00ffff);
            Set(i++, 0xff80e0ff);
            Set(i++, 0xff00ffc0);
            Set(i++, 0xff00ff80);
            Set(i++, 0xff00ff50);
            Set(i++, 0xff000050);
            Set(i++, 0xff000080);
            Set(i++, 0xff0000c0);
            Set(i++, 0xff0000ff);
            Set(i++, 0xff0050ff);
            Set(i++, 0xff0080ff);
            Set(i++, 0xff00a0ff);
            Set(i++, 0xff00c0ff);
            Set(i++, 0xff200050);
            Set(i++, 0xff300050);
            Set(i++, 0xff500080);
            Set(i++, 0xff8000ff);
            Set(i++, 0xff8050ff);
            Set(i++, 0xffc080ff);
            Set(i++, 0xffc0a0ff);
            Set(i++, 0xffc0c0ff);
            Set(i++, 0xff500050);
            Set(i++, 0xff800080);
            Set(i++, 0xffc000c0);
            Set(i++, 0xffff00ff);
            Set(i++, 0xffff50ff);
            Set(i++, 0xffff80ff);
            Set(i++, 0xffffc0ff);
            Set(i++, 0xffffe0ff);
        }

        public void InitDefaultMSX()
        {
            Clear();
            int i = 0;

            Set(i++, 0xff000000);
            Set(i++, 0xff000000);
            Set(i++, 0xff40b64a);
            Set(i++, 0xff73ce7c);
            Set(i++, 0xff5955df);
            Set(i++, 0xff7e75f0);
            Set(i++, 0xffb75e51);
            Set(i++, 0xff64daee);
            Set(i++, 0xffd96459);
            Set(i++, 0xfffe877c);
            Set(i++, 0xffcac15e);
            Set(i++, 0xffddce85);
            Set(i++, 0xff3ca042);
            Set(i++, 0xffb565b3);
            Set(i++, 0xffcacaca);
            Set(i++, 0xffffffff);
        }
    }
}
