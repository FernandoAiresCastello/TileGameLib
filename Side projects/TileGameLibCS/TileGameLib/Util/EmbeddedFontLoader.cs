using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Util
{
    public static class EmbeddedFontLoader
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection PrivateFonts = new PrivateFontCollection();

        public static Font Load(byte[] fontResourceData, float size, FontStyle style = FontStyle.Regular)
        {
            using (Stream fontStream = new MemoryStream(fontResourceData))
            {
                IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);
                Marshal.Copy(fontData, 0, data, (int)fontStream.Length);

                uint cFonts = 0;
                AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

                PrivateFonts.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }

            return new Font(PrivateFonts.Families[0], size, style);
        }
    }
}
