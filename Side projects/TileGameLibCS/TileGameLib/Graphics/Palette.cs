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
        public static readonly int EmptyColor = 0x000000;

        public List<int> Colors { get; private set; } = new List<int>();
        public int Size => Colors.Count;

        private const Default DefaultPalette = Default.PTM;
        private const int DefaultSize = 256;

        public enum Default
        {
            PTM
        }

        public Palette(Default defaultPalette = DefaultPalette)
        {
            InitDefault(defaultPalette);
        }

        public static string[] GetDefaultPaletteNames()
        {
            return Enum.GetNames(typeof(Default));
        }

        public void Add(int color)
        {
            Colors.Add(color);
        }

        public void Set(int index, int color)
        {
            Colors[index] = color;
        }

        public void Set(int index, int r, int g, int b)
        {
            Colors[index] = Color.FromArgb(255, r, g, b).ToArgb();
        }

        public void Set(int index, Color color)
        {
            Colors[index] = Color.FromArgb(255, color.R, color.G, color.B).ToArgb();
        }

        public int Get(int index)
        {
            return Colors[index];
        }

        public Color GetColorObject(int index)
        {
            return Color.FromArgb(255, Color.FromArgb(Colors[index]));
        }

        public void Clear()
        {
            Clear(DefaultSize, EmptyColor);
        }

        public void Clear(int count)
        {
            Clear(count, EmptyColor);
        }

        public void Clear(int count, int color)
        {
            Colors.Clear();
            for (int i = 0; i < count; i++)
                Add(color);

            Colors[0] = Color.Black.ToArgb();
            Colors[1] = Color.White.ToArgb();
        }

        public void SetEmpty()
        {
            Colors.Clear();
        }

        public void SetEqual(Palette other)
        {
            Colors.Clear();
            for (int i = 0; i < other.Size; i++)
                Colors.Add(other.Colors[i]);
        }

        private int GetBlack()
        {
            float darkest = 0.0f;
            int ixDarkest = -1;

            for (int index = 0; index < Colors.Count; index++)
            {
                Color color = GetColorObject(index);
                float bright = GetBrightness(color);

                if (bright < darkest)
                {
                    darkest = bright;
                    ixDarkest = index;
                }

                if (color.R == 0 && color.G == 0 && color.B == 0)
                    return index;
            }

            if (ixDarkest >= 0)
                return ixDarkest;

            throw new TGLException("Black or dark color not found");
        }

        private int GetWhite()
        {
            float brightest = 0.0f;
            int ixBrightest = -1;

            for (int index = 0; index < Colors.Count; index++)
            {
                Color color = GetColorObject(index);
                float bright = GetBrightness(color);
                
                if (bright > brightest)
                {
                    brightest = bright;
                    ixBrightest = index;
                }

                if (color.R == 255 && color.G == 255 && color.B == 255)
                    return index;
            }

            if (ixBrightest >= 0)
                return ixBrightest;

            throw new TGLException("White or bright color not found");
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

        public void Swap(int first, int second)
        {
            int temp = Get(first);
            Set(first, Get(second));
            Set(second, temp);
        }

        public float GetSaturation(int index)
        {
            return GetSaturation(GetColorObject(index));
        }

        public static float GetSaturation(Color color)
        {
            float num = color.R / 255f;
            float num2 = color.G / 255f;
            float num3 = color.B / 255f;
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
                case Default.PTM: InitDefaultPTM(); break;

                default:
                    throw new TGLException("Invalid palette default: " + defaultPalette);
            }
        }

        public void InitDefaultPTM()
        {
            Clear();
            Set(0, 0x101010);
            Set(1, 0xf0f0f0);
        }

        public void InitDefaultClassic2()
        {
            Clear();
            int i = 0;

            Set(i++, 0x000000);
            Set(i++, 0xffffff);
            Set(i++, 0xe0e0e0);
            Set(i++, 0xc0c0c0);
            Set(i++, 0x808080);
            Set(i++, 0x505050);
            Set(i++, 0x303030);
            Set(i++, 0x101010);
            Set(i++, 0x500000);
            Set(i++, 0x800000);
            Set(i++, 0xc00000);
            Set(i++, 0xff0000);
            Set(i++, 0xff5050);
            Set(i++, 0xff8080);
            Set(i++, 0xffc0c0);
            Set(i++, 0xffe0e0);
            Set(i++, 0xc02000);
            Set(i++, 0xff5000);
            Set(i++, 0xff8000);
            Set(i++, 0xffc000);
            Set(i++, 0xffc050);
            Set(i++, 0xffc080);
            Set(i++, 0xffa050);
            Set(i++, 0x808050);
            Set(i++, 0x505000);
            Set(i++, 0x808000);
            Set(i++, 0xc0c000);
            Set(i++, 0xffff00);
            Set(i++, 0xffff50);
            Set(i++, 0xffff80);
            Set(i++, 0xffffc0);
            Set(i++, 0xc0c080);
            Set(i++, 0x005000);
            Set(i++, 0x008000);
            Set(i++, 0x00c000);
            Set(i++, 0x00ff00);
            Set(i++, 0x80ff00);
            Set(i++, 0x80ff80);
            Set(i++, 0xc0ff00);
            Set(i++, 0xc0ff80);
            Set(i++, 0x005050);
            Set(i++, 0x008080);
            Set(i++, 0x00c0c0);
            Set(i++, 0x00ffff);
            Set(i++, 0x80e0ff);
            Set(i++, 0x00ffc0);
            Set(i++, 0x00ff80);
            Set(i++, 0x00ff50);
            Set(i++, 0x000050);
            Set(i++, 0x000080);
            Set(i++, 0x0000c0);
            Set(i++, 0x0000ff);
            Set(i++, 0x0050ff);
            Set(i++, 0x0080ff);
            Set(i++, 0x00a0ff);
            Set(i++, 0x00c0ff);
            Set(i++, 0x200050);
            Set(i++, 0x300050);
            Set(i++, 0x500080);
            Set(i++, 0x8000ff);
            Set(i++, 0x8050ff);
            Set(i++, 0xc080ff);
            Set(i++, 0xc0a0ff);
            Set(i++, 0xc0c0ff);
            Set(i++, 0x500050);
            Set(i++, 0x800080);
            Set(i++, 0xc000c0);
            Set(i++, 0xff00ff);
            Set(i++, 0xff50ff);
            Set(i++, 0xff80ff);
            Set(i++, 0xffc0ff);
            Set(i++, 0xffe0ff);
        }

        public void InitDefaultMSX()
        {
            Clear();
            int i = 0;

            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0x40b64a);
            Set(i++, 0x73ce7c);
            Set(i++, 0x5955df);
            Set(i++, 0x7e75f0);
            Set(i++, 0xb75e51);
            Set(i++, 0x64daee);
            Set(i++, 0xd96459);
            Set(i++, 0xfe877c);
            Set(i++, 0xcac15e);
            Set(i++, 0xddce85);
            Set(i++, 0x3ca042);
            Set(i++, 0xb565b3);
            Set(i++, 0xcacaca);
            Set(i++, 0xffffff);
        }

        public void InitDefaultNES()
        {
            Clear();
            int i = 0;

            Set(i++, 0x7C7C7C);
            Set(i++, 0x0000FC);
            Set(i++, 0x0000BC);
            Set(i++, 0x4428BC);
            Set(i++, 0x940084);
            Set(i++, 0xA80020);
            Set(i++, 0xA81000);
            Set(i++, 0x881400);
            Set(i++, 0x503000);
            Set(i++, 0x007800);
            Set(i++, 0x006800);
            Set(i++, 0x005800);
            Set(i++, 0x004058);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0xBCBCBC);
            Set(i++, 0x0078F8);
            Set(i++, 0x0058F8);
            Set(i++, 0x6844FC);
            Set(i++, 0xD800CC);
            Set(i++, 0xE40058);
            Set(i++, 0xF83800);
            Set(i++, 0xE45C10);
            Set(i++, 0xAC7C00);
            Set(i++, 0x00B800);
            Set(i++, 0x00A800);
            Set(i++, 0x00A844);
            Set(i++, 0x008888);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0xF8F8F8);
            Set(i++, 0x3CBCFC);
            Set(i++, 0x6888FC);
            Set(i++, 0x9878F8);
            Set(i++, 0xF878F8);
            Set(i++, 0xF85898);
            Set(i++, 0xF87858);
            Set(i++, 0xFCA044);
            Set(i++, 0xF8B800);
            Set(i++, 0xB8F818);
            Set(i++, 0x58D854);
            Set(i++, 0x58F898);
            Set(i++, 0x00E8D8);
            Set(i++, 0x787878);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
            Set(i++, 0xFCFCFC);
            Set(i++, 0xA4E4FC);
            Set(i++, 0xB8B8F8);
            Set(i++, 0xD8B8F8);
            Set(i++, 0xF8B8F8);
            Set(i++, 0xF8A4C0);
            Set(i++, 0xF0D0B0);
            Set(i++, 0xFCE0A8);
            Set(i++, 0xF8D878);
            Set(i++, 0xD8F878);
            Set(i++, 0xB8F8B8);
            Set(i++, 0xB8F8D8);
            Set(i++, 0x00FCFC);
            Set(i++, 0xF8D8F8);
            Set(i++, 0x000000);
            Set(i++, 0x000000);
        }

        public void InitDefaultROYGBIV()
        {
            Clear();
            int i = 0;

            Set(i++, 0x000000);
            Set(i++, 0xffffff);
            Set(i++, 0xff0000);
            Set(i++, 0xff8000);
            Set(i++, 0xffff00);
            Set(i++, 0x00ff00);
            Set(i++, 0x00ffff);
            Set(i++, 0x0000ff);
            Set(i++, 0x8000ff);
            Set(i++, 0xff00ff);
            Set(i++, 0x808080);
        }
    }
}
