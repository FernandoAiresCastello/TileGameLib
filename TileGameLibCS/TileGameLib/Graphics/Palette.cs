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
        public int White => GetWhite();
        public int Black => GetBlack();

        private const Default DefaultPalette = Default.Classic1;
        private const int DefaultSize = 256;

        public enum Default
        {
            Classic1,
            Classic2,
            ROYGBIV,
            NES,
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
            for (int i = 0; i < Size; i++)
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
                case Default.Classic1: InitDefaultClassic1(); break;
                case Default.Classic2: InitDefaultClassic2(); break;
                case Default.MSX: InitDefaultMSX(); break;
                case Default.NES: InitDefaultNES(); break;
                case Default.ROYGBIV: InitDefaultROYGBIV(); break;

                default:
                    throw new TGLException("Invalid palette default: " + defaultPalette);
            }
        }

        public void InitDefaultClassic1()
        {
            Clear();
            int i = 0;

            Set(i++, 0x000000);
            Set(i++, 0x381400);
            Set(i++, 0x441804);
            Set(i++, 0x481404);
            Set(i++, 0x040468);
            Set(i++, 0x280478);
            Set(i++, 0x340888);
            Set(i++, 0x041C80);
            Set(i++, 0x0C0488);
            Set(i++, 0x1C2858);
            Set(i++, 0x2C4000);
            Set(i++, 0x084008);
            Set(i++, 0x044008);
            Set(i++, 0x00340C);
            Set(i++, 0x243000);
            Set(i++, 0x401800);
            Set(i++, 0x383838);
            Set(i++, 0x803008);
            Set(i++, 0x9C241C);
            Set(i++, 0xB01C14);
            Set(i++, 0x702070);
            Set(i++, 0x580C90);
            Set(i++, 0x500CD0);
            Set(i++, 0x082CC8);
            Set(i++, 0x382CB4);
            Set(i++, 0x1C4890);
            Set(i++, 0x446000);
            Set(i++, 0x10680C);
            Set(i++, 0x046410);
            Set(i++, 0x0C481C);
            Set(i++, 0x204004);
            Set(i++, 0x702408);
            Set(i++, 0x787878);
            Set(i++, 0xC85C24);
            Set(i++, 0xC85020);
            Set(i++, 0xDC241C);
            Set(i++, 0xA430A4);
            Set(i++, 0x8838A8);
            Set(i++, 0x7844D0);
            Set(i++, 0x444CDC);
            Set(i++, 0x584CD8);
            Set(i++, 0x1C70C4);
            Set(i++, 0x3C9420);
            Set(i++, 0x149010);
            Set(i++, 0x088814);
            Set(i++, 0x4C7420);
            Set(i++, 0x806830);
            Set(i++, 0xA8501C);
            Set(i++, 0xA8A8A8);
            Set(i++, 0xFC901C);
            Set(i++, 0xFC801C);
            Set(i++, 0xF85054);
            Set(i++, 0xCC3CCC);
            Set(i++, 0xC048DC);
            Set(i++, 0xA050D8);
            Set(i++, 0x5868FC);
            Set(i++, 0x6864FC);
            Set(i++, 0x4898D8);
            Set(i++, 0x54A838);
            Set(i++, 0x1CB814);
            Set(i++, 0x08AC1C);
            Set(i++, 0x649028);
            Set(i++, 0xAC9838);
            Set(i++, 0xBC7430);
            Set(i++, 0xCCCCCC);
            Set(i++, 0xFCC41C);
            Set(i++, 0xFC982C);
            Set(i++, 0xFC706C);
            Set(i++, 0xE850E8);
            Set(i++, 0xE05CFC);
            Set(i++, 0xBC60FC);
            Set(i++, 0x7080FC);
            Set(i++, 0x8884FC);
            Set(i++, 0x54B4FC);
            Set(i++, 0x60D070);
            Set(i++, 0x20D818);
            Set(i++, 0x84D820);
            Set(i++, 0xA0B034);
            Set(i++, 0xD4B440);
            Set(i++, 0xE09044);
            Set(i++, 0xE4E4E4);
            Set(i++, 0xFCD84C);
            Set(i++, 0xFCC444);
            Set(i++, 0xFC8C8C);
            Set(i++, 0xFC6CFC);
            Set(i++, 0xF07CFC);
            Set(i++, 0xCC74FC);
            Set(i++, 0x90A0FC);
            Set(i++, 0x9898FC);
            Set(i++, 0x8CD8FC);
            Set(i++, 0x70F484);
            Set(i++, 0x6CF040);
            Set(i++, 0x98F824);
            Set(i++, 0xB0D040);
            Set(i++, 0xE0C838);
            Set(i++, 0xF8AC58);
            Set(i++, 0xF0F0F0);
            Set(i++, 0xFCF454);
            Set(i++, 0xFCC46C);
            Set(i++, 0xFCA8AC);
            Set(i++, 0xFC84F8);
            Set(i++, 0xFC98FC);
            Set(i++, 0xD490FC);
            Set(i++, 0x9CB0FC);
            Set(i++, 0xB0ACFC);
            Set(i++, 0x98DCFC);
            Set(i++, 0x84FC94);
            Set(i++, 0x80FC58);
            Set(i++, 0xB4FC58);
            Set(i++, 0xD4E048);
            Set(i++, 0xE0E434);
            Set(i++, 0xFCC060);
            Set(i++, 0xFCFCFC);
            Set(i++, 0xFCFC98);
            Set(i++, 0xFCE4A0);
            Set(i++, 0xFCC4CC);
            Set(i++, 0xFCA4FC);
            Set(i++, 0xFCA8FC);
            Set(i++, 0xDCA8FC);
            Set(i++, 0xC0C8FC);
            Set(i++, 0xC0C0FC);
            Set(i++, 0xC0E8FC);
            Set(i++, 0xACFCB4);
            Set(i++, 0xB0FC98);
            Set(i++, 0xDCFC80);
            Set(i++, 0xF0FC50);
            Set(i++, 0xF8FC7C);
            Set(i++, 0xFCFCFC);
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
