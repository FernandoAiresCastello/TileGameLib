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

            throw new TGLException("Black color (0x000000) not found");
        }

        private int GetWhite()
        {
            for (int index = 0; index < Colors.Count; index++)
            {
                Color color = GetColorObject(index);
                if (color.R == 255 && color.G == 255 && color.B == 255)
                    return index;
            }

            throw new TGLException("White color (0xffffff) not found");
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

            Set(i++, 0xFF000000);
            Set(i++, 0xFF381400);
            Set(i++, 0xFF441804);
            Set(i++, 0xFF481404);
            Set(i++, 0xFF040468);
            Set(i++, 0xFF280478);
            Set(i++, 0xFF340888);
            Set(i++, 0xFF041C80);
            Set(i++, 0xFF0C0488);
            Set(i++, 0xFF1C2858);
            Set(i++, 0xFF2C4000);
            Set(i++, 0xFF084008);
            Set(i++, 0xFF044008);
            Set(i++, 0xFF00340C);
            Set(i++, 0xFF243000);
            Set(i++, 0xFF401800);
            Set(i++, 0xFF383838);
            Set(i++, 0xFF803008);
            Set(i++, 0xFF9C241C);
            Set(i++, 0xFFB01C14);
            Set(i++, 0xFF702070);
            Set(i++, 0xFF580C90);
            Set(i++, 0xFF500CD0);
            Set(i++, 0xFF082CC8);
            Set(i++, 0xFF382CB4);
            Set(i++, 0xFF1C4890);
            Set(i++, 0xFF446000);
            Set(i++, 0xFF10680C);
            Set(i++, 0xFF046410);
            Set(i++, 0xFF0C481C);
            Set(i++, 0xFF204004);
            Set(i++, 0xFF702408);
            Set(i++, 0xFF787878);
            Set(i++, 0xFFC85C24);
            Set(i++, 0xFFC85020);
            Set(i++, 0xFFDC241C);
            Set(i++, 0xFFA430A4);
            Set(i++, 0xFF8838A8);
            Set(i++, 0xFF7844D0);
            Set(i++, 0xFF444CDC);
            Set(i++, 0xFF584CD8);
            Set(i++, 0xFF1C70C4);
            Set(i++, 0xFF3C9420);
            Set(i++, 0xFF149010);
            Set(i++, 0xFF088814);
            Set(i++, 0xFF4C7420);
            Set(i++, 0xFF806830);
            Set(i++, 0xFFA8501C);
            Set(i++, 0xFFA8A8A8);
            Set(i++, 0xFFFC901C);
            Set(i++, 0xFFFC801C);
            Set(i++, 0xFFF85054);
            Set(i++, 0xFFCC3CCC);
            Set(i++, 0xFFC048DC);
            Set(i++, 0xFFA050D8);
            Set(i++, 0xFF5868FC);
            Set(i++, 0xFF6864FC);
            Set(i++, 0xFF4898D8);
            Set(i++, 0xFF54A838);
            Set(i++, 0xFF1CB814);
            Set(i++, 0xFF08AC1C);
            Set(i++, 0xFF649028);
            Set(i++, 0xFFAC9838);
            Set(i++, 0xFFBC7430);
            Set(i++, 0xFFCCCCCC);
            Set(i++, 0xFFFCC41C);
            Set(i++, 0xFFFC982C);
            Set(i++, 0xFFFC706C);
            Set(i++, 0xFFE850E8);
            Set(i++, 0xFFE05CFC);
            Set(i++, 0xFFBC60FC);
            Set(i++, 0xFF7080FC);
            Set(i++, 0xFF8884FC);
            Set(i++, 0xFF54B4FC);
            Set(i++, 0xFF60D070);
            Set(i++, 0xFF20D818);
            Set(i++, 0xFF84D820);
            Set(i++, 0xFFA0B034);
            Set(i++, 0xFFD4B440);
            Set(i++, 0xFFE09044);
            Set(i++, 0xFFE4E4E4);
            Set(i++, 0xFFFCD84C);
            Set(i++, 0xFFFCC444);
            Set(i++, 0xFFFC8C8C);
            Set(i++, 0xFFFC6CFC);
            Set(i++, 0xFFF07CFC);
            Set(i++, 0xFFCC74FC);
            Set(i++, 0xFF90A0FC);
            Set(i++, 0xFF9898FC);
            Set(i++, 0xFF8CD8FC);
            Set(i++, 0xFF70F484);
            Set(i++, 0xFF6CF040);
            Set(i++, 0xFF98F824);
            Set(i++, 0xFFB0D040);
            Set(i++, 0xFFE0C838);
            Set(i++, 0xFFF8AC58);
            Set(i++, 0xFFF0F0F0);
            Set(i++, 0xFFFCF454);
            Set(i++, 0xFFFCC46C);
            Set(i++, 0xFFFCA8AC);
            Set(i++, 0xFFFC84F8);
            Set(i++, 0xFFFC98FC);
            Set(i++, 0xFFD490FC);
            Set(i++, 0xFF9CB0FC);
            Set(i++, 0xFFB0ACFC);
            Set(i++, 0xFF98DCFC);
            Set(i++, 0xFF84FC94);
            Set(i++, 0xFF80FC58);
            Set(i++, 0xFFB4FC58);
            Set(i++, 0xFFD4E048);
            Set(i++, 0xFFE0E434);
            Set(i++, 0xFFFCC060);
            Set(i++, 0xFFFCFCFC);
            Set(i++, 0xFFFCFC98);
            Set(i++, 0xFFFCE4A0);
            Set(i++, 0xFFFCC4CC);
            Set(i++, 0xFFFCA4FC);
            Set(i++, 0xFFFCA8FC);
            Set(i++, 0xFFDCA8FC);
            Set(i++, 0xFFC0C8FC);
            Set(i++, 0xFFC0C0FC);
            Set(i++, 0xFFC0E8FC);
            Set(i++, 0xFFACFCB4);
            Set(i++, 0xFFB0FC98);
            Set(i++, 0xFFDCFC80);
            Set(i++, 0xFFF0FC50);
            Set(i++, 0xFFF8FC7C);
            Set(i++, 0xFFFCFCFC);
        }

        public void InitDefaultClassic2()
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

        public void InitDefaultNES()
        {
            Clear();
            int i = 0;

            Set(i++, 0xFF7C7C7C);
            Set(i++, 0xFF0000FC);
            Set(i++, 0xFF0000BC);
            Set(i++, 0xFF4428BC);
            Set(i++, 0xFF940084);
            Set(i++, 0xFFA80020);
            Set(i++, 0xFFA81000);
            Set(i++, 0xFF881400);
            Set(i++, 0xFF503000);
            Set(i++, 0xFF007800);
            Set(i++, 0xFF006800);
            Set(i++, 0xFF005800);
            Set(i++, 0xFF004058);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
            Set(i++, 0xFFBCBCBC);
            Set(i++, 0xFF0078F8);
            Set(i++, 0xFF0058F8);
            Set(i++, 0xFF6844FC);
            Set(i++, 0xFFD800CC);
            Set(i++, 0xFFE40058);
            Set(i++, 0xFFF83800);
            Set(i++, 0xFFE45C10);
            Set(i++, 0xFFAC7C00);
            Set(i++, 0xFF00B800);
            Set(i++, 0xFF00A800);
            Set(i++, 0xFF00A844);
            Set(i++, 0xFF008888);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
            Set(i++, 0xFFF8F8F8);
            Set(i++, 0xFF3CBCFC);
            Set(i++, 0xFF6888FC);
            Set(i++, 0xFF9878F8);
            Set(i++, 0xFFF878F8);
            Set(i++, 0xFFF85898);
            Set(i++, 0xFFF87858);
            Set(i++, 0xFFFCA044);
            Set(i++, 0xFFF8B800);
            Set(i++, 0xFFB8F818);
            Set(i++, 0xFF58D854);
            Set(i++, 0xFF58F898);
            Set(i++, 0xFF00E8D8);
            Set(i++, 0xFF787878);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
            Set(i++, 0xFFFCFCFC);
            Set(i++, 0xFFA4E4FC);
            Set(i++, 0xFFB8B8F8);
            Set(i++, 0xFFD8B8F8);
            Set(i++, 0xFFF8B8F8);
            Set(i++, 0xFFF8A4C0);
            Set(i++, 0xFFF0D0B0);
            Set(i++, 0xFFFCE0A8);
            Set(i++, 0xFFF8D878);
            Set(i++, 0xFFD8F878);
            Set(i++, 0xFFB8F8B8);
            Set(i++, 0xFFB8F8D8);
            Set(i++, 0xFF00FCFC);
            Set(i++, 0xFFF8D8F8);
            Set(i++, 0xFF000000);
            Set(i++, 0xFF000000);
        }

        public void InitDefaultROYGBIV()
        {
            Clear();
            int i = 0;

            Set(i++, 0xFF000000);
            Set(i++, 0xFFffffff);
            Set(i++, 0xFFff0000);
            Set(i++, 0xFFff8000);
            Set(i++, 0xFFffff00);
            Set(i++, 0xFF00ff00);
            Set(i++, 0xFF00ffff);
            Set(i++, 0xFF0000ff);
            Set(i++, 0xFF8000ff);
            Set(i++, 0xFFff00ff);
            Set(i++, 0xFF808080);
        }
    }
}
