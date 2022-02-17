using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.Util;

namespace TileGameMaker.TiledDisplays
{
    public class TileEditor16x16Display : TiledDisplay
    {
        private Tileset Tileset;
        private int TileIndexTL;
        private int TileIndexTR;
        private int TileIndexBL;
        private int TileIndexBR;

        private readonly int PixelIndicator = Config.ReadInt("TileEditorPixelIndicator");
        private readonly char PixelOn = Config.ReadChar("TileEditorPixelOnValue");
        private readonly char PixelOff = Config.ReadChar("TileEditorPixelOffValue");

        public enum Section
        {
            Invalid, TopLeft, TopRight, BottomLeft, BottomRight
        }

        public TileEditor16x16Display(Control parent, int zoom) : this(parent, 16, 16, zoom)
        {
        }

        private TileEditor16x16Display(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            Graphics.Palette.Set(0, Config.ReadInt("TileEditorPixelOnColor"));
            Graphics.Palette.Set(1, Config.ReadInt("TileEditorPixelOffColor"));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Tileset == null ||
                TileIndexTL < 0 || TileIndexTL >= Tileset.Size ||
                TileIndexBL < 0 || TileIndexBL >= Tileset.Size ||
                TileIndexTR < 0 || TileIndexTR >= Tileset.Size ||
                TileIndexBR < 0 || TileIndexBR >= Tileset.Size)
            {
                base.OnPaint(e);
                return;
            }

            PaintTL();
            PaintTR();
            PaintBL();
            PaintBR();

            base.OnPaint(e);
        }

        private void PaintTL()
        {
            int pix = 0;
            string pixelsTL = Tileset.Get(TileIndexTL).ToBinaryString();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pixelsTL[pix] == PixelOff)
                        Graphics.PutTile(x, y, PixelIndicator, 0, 1);
                    else if (pixelsTL[pix] == PixelOn)
                        Graphics.PutTile(x, y, PixelIndicator, 1, 0);

                    pix++;
                }
            }
        }

        private void PaintTR()
        {
            int pix = 0;
            string pixelsTR = Tileset.Get(TileIndexTR).ToBinaryString();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pixelsTR[pix] == PixelOff)
                        Graphics.PutTile(x + 8, y, PixelIndicator, 0, 1);
                    else if (pixelsTR[pix] == PixelOn)
                        Graphics.PutTile(x + 8, y, PixelIndicator, 1, 0);

                    pix++;
                }
            }
        }

        private void PaintBL()
        {
            int pix = 0;
            string pixelsBL = Tileset.Get(TileIndexBL).ToBinaryString();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pixelsBL[pix] == PixelOff)
                        Graphics.PutTile(x, y + 8, PixelIndicator, 0, 1);
                    else if (pixelsBL[pix] == PixelOn)
                        Graphics.PutTile(x, y + 8, PixelIndicator, 1, 0);

                    pix++;
                }
            }
        }

        private void PaintBR()
        {
            int pix = 0;
            string pixelsBR = Tileset.Get(TileIndexBR).ToBinaryString();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (pixelsBR[pix] == PixelOff)
                        Graphics.PutTile(x + 8, y + 8, PixelIndicator, 0, 1);
                    else if (pixelsBR[pix] == PixelOn)
                        Graphics.PutTile(x + 8, y + 8, PixelIndicator, 1, 0);

                    pix++;
                }
            }
        }

        public void SetTiles(Tileset tileset, int indexTL, int indexTR, int indexBL, int indexBR)
        {
            Tileset = tileset;
            TileIndexTL = indexTL;
            TileIndexBL = indexBL;
            TileIndexTR = indexTR;
            TileIndexBR = indexBR;
        }

        public void SetTilePixel(int x, int y, int pixel)
        {
            Section section = Section.Invalid;

            if (x < 8 && y < 8)
                section = Section.TopLeft;
            else if (x >= 8 && y < 8)
                section = Section.TopRight;
            else if (x < 8 && y >= 8)
                section = Section.BottomLeft;
            else if (x >= 8 && y >= 8)
                section = Section.BottomRight;

            SetTilePixel(section, x, y, pixel);
        }

        public void SetTilePixel(Section section, int x, int y, int pixel)
        {
            x %= 8;
            y %= 8;

            if (section == Section.Invalid || x < 0 || y < 0 || x >= 8 || y >= 8)
                return;

            int tileIndex = -1;

            if (section == Section.TopLeft)
                tileIndex = TileIndexTL;
            else if (section == Section.TopRight)
                tileIndex = TileIndexTR;
            else if (section == Section.BottomLeft)
                tileIndex = TileIndexBL;
            else if (section == Section.BottomRight)
                tileIndex = TileIndexBR;

            byte row = Tileset.Get(tileIndex).PixelRows[y];

            if (pixel > 0)
                row = row.SetBit(x);
            else
                row = row.UnsetBit(x);

            Tileset.Get(tileIndex).PixelRows[y] = row;

            Refresh();
        }

        public void SetTilePixels(TilePixels topLeft, TilePixels topRight, TilePixels bottomLeft, TilePixels bottomRight)
        {
            Tileset.Get(TileIndexTL).SetEqual(topLeft);
            Tileset.Get(TileIndexTR).SetEqual(topRight);
            Tileset.Get(TileIndexBL).SetEqual(bottomLeft);
            Tileset.Get(TileIndexBR).SetEqual(bottomRight);
            Refresh();
        }

        public void ClearTiles()
        {
            Tileset.Get(TileIndexTL).Clear();
            Tileset.Get(TileIndexTR).Clear();
            Tileset.Get(TileIndexBL).Clear();
            Tileset.Get(TileIndexBR).Clear();
            Refresh();
        }

        public void InvertTiles()
        {
            Tileset.Get(TileIndexTL).Invert();
            Tileset.Get(TileIndexTR).Invert();
            Tileset.Get(TileIndexBL).Invert();
            Tileset.Get(TileIndexBR).Invert();
            Refresh();
        }
    }
}
