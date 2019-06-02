using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class TilePixels
    {
        public static readonly int RowCount = 8;
        public static readonly int RowLength = 8;
        public static readonly int PixelCount = 64;

        public byte[] PixelRows { set; get; } = new byte[RowCount];

        public TilePixels()
        {
            Clear();
        }

        public TilePixels(byte row1, byte row2, byte row3, byte row4,
            byte row5, byte row6, byte row7, byte row8)
        {
            Set(row1, row2, row3, row4, row5, row6, row7, row8);
        }

        public void Clear()
        {
            for (int i = 0; i < RowCount; i++)
                PixelRows[i] = 0;
        }

        public void Set(byte row1, byte row2, byte row3, byte row4,
            byte row5, byte row6, byte row7, byte row8)
        {
            PixelRows[0] = row1;
            PixelRows[1] = row2;
            PixelRows[2] = row3;
            PixelRows[3] = row4;
            PixelRows[4] = row5;
            PixelRows[5] = row6;
            PixelRows[6] = row7;
            PixelRows[7] = row8;
        }
    }
}
