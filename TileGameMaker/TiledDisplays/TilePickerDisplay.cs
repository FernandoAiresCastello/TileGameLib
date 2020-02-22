using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameMaker.TiledDisplays
{
    public class TilePickerDisplay : TiledDisplay
    {
        public static readonly int InvalidIndex = -1;

        public int TileIndex { set; get; }

        private const int TilePickerZoom = 3;
        private readonly int TilesPerRow;
        private bool RearrangeMode = false;
        private int RearrangeTileSrc = 0;
        private int RearrangeTileDst = 0;

        private enum IndicatorColor
        {
            Invalid, Fore, Back,
            ForeSelected, BackSelected,
            ForeRearrangeSrc, BackRearrangeSrc,
            ForeRearrangeDst, BackRearrangeDst
        }

        public TilePickerDisplay(Control parent, Tileset tileset, int tilesPerRow)
            : base(parent, 1, 1, TilePickerZoom)
        {
            Graphics.Tileset = tileset;
            TilesPerRow = tilesPerRow;
            TileIndex = 0;

            UpdateSize();

            SetIndicatorColor(IndicatorColor.Invalid, Color.LightGray);
            SetIndicatorColor(IndicatorColor.Fore, Color.Black);
            SetIndicatorColor(IndicatorColor.Back, Color.White);
            SetIndicatorColor(IndicatorColor.ForeSelected, Color.White);
            SetIndicatorColor(IndicatorColor.BackSelected, SystemColors.Highlight);
            SetIndicatorColor(IndicatorColor.ForeRearrangeSrc, Color.White);
            SetIndicatorColor(IndicatorColor.BackRearrangeSrc, Color.Red);
            SetIndicatorColor(IndicatorColor.ForeRearrangeDst, Color.Black);
            SetIndicatorColor(IndicatorColor.BackRearrangeDst, Color.Red);
        }

        private void SetIndicatorColor(IndicatorColor indicatorColor, Color color)
        {
            Graphics.Palette.Set((int)indicatorColor, color);
        }

        public void UpdateSize()
        {
            ResizeGraphicsByTileCount(Graphics.Tileset.Size, TilesPerRow);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTiles(true);
            base.OnPaint(e);
        }

        public void DrawTiles(bool drawCursor)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < TileCount; i++)
            {
                int fgc;
                int bgc;
                bool valid = i < Graphics.Tileset.Size;

                if (valid)
                {
                    if (i == TileIndex && drawCursor)
                    {
                        fgc = (int)IndicatorColor.ForeSelected;
                        bgc = (int)IndicatorColor.BackSelected;
                    }
                    else
                    {
                        fgc = (int)IndicatorColor.Fore;
                        bgc = (int)IndicatorColor.Back;
                    }

                    if (RearrangeMode)
                    {
                        if (i == RearrangeTileSrc)
                        {
                            fgc = (int)IndicatorColor.ForeRearrangeSrc;
                            bgc = (int)IndicatorColor.BackRearrangeSrc;
                        }
                        else if (i == RearrangeTileDst)
                        {
                            fgc = (int)IndicatorColor.ForeRearrangeDst;
                            bgc = (int)IndicatorColor.BackRearrangeDst;
                        }
                    }
                }
                else
                {
                    fgc = (int)IndicatorColor.Invalid;
                    bgc = (int)IndicatorColor.Invalid;
                }

                Graphics.PutTile(x, y, valid ? i : 0, fgc, bgc);
                x++;

                if (x >= Graphics.Cols)
                {
                    x = 0;
                    y++;
                }

                if (x >= Graphics.Cols || y >= Graphics.Rows)
                    break;
            }
        }

        public void SelectTileIndex(int tileIx)
        {
            TileIndex = tileIx;
            Refresh();
        }

        public int GetTileIndexAtMousePos(Point mousePos)
        {
            Point p = GetMouseToCellPos(mousePos);

            try
            {
                Tile tile = Graphics.GetTile(p.X, p.Y);

                if (p.Y * Cols + p.X >= Graphics.Tileset.Size)
                    return InvalidIndex;

                return tile.Index;
            }
            catch
            {
                return InvalidIndex;
            }
        }

        public void Clear()
        {
            Graphics.Tileset.Clear();
            TileIndex = 0;
            Refresh();
        }

        public void ClearRange(int first, int last)
        {
            Graphics.Tileset.ClearRange(first, last);
            Refresh();
        }

        public void ResetToDefault()
        {
            Graphics.Tileset.InitDefault();
            TileIndex = 0;
            Refresh();
        }

        public void Add8Tiles()
        {
            Graphics.Tileset.AddBlank(8);
            UpdateSize();
            Refresh();
        }

        public void StartRearrange(int src)
        {
            RearrangeMode = true;
            RearrangeTileSrc = src;
            Refresh();
        }

        public void UpdateRearrange(int index)
        {
            RearrangeTileDst = index;
            Refresh();
        }

        public void EndRearrange(int dst)
        {
            RearrangeMode = false;
            RearrangeTileDst = dst;
            Graphics.Tileset.Swap(RearrangeTileSrc, RearrangeTileDst);
            Refresh();
        }
    }
}
