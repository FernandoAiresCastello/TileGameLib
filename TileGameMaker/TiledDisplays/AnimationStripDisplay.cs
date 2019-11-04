using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameMaker.Util;

namespace TileGameMaker.TiledDisplays
{
    public class AnimationStripDisplay : TiledDisplay
    {
        public ObjectAnim Animation { set; get; } = new ObjectAnim(false);

        private readonly Tile BlankTile;

        public AnimationStripDisplay(Control parent, int cols, int rows, int zoom, Tile blankTile)
            : base(parent, cols, rows, zoom)
        {
            BlankTile = blankTile;
            ShowGrid = true;
            Clear();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < Graphics.Cols; i++)
                Graphics.PutTile(i, 0, BlankTile.Copy());

            int x = 0;
            foreach (Tile tile in Animation.Frames)
                Graphics.PutTile(x++, 0, tile.TileIx, tile.ForeColorIx, tile.BackColorIx);

            base.OnPaint(e);
        }

        public void Clear()
        {
            Animation.Clear();

            for (int i = 0; i < Graphics.Cols; i++)
            {
                Animation.AddFrame(new Tile(
                    Config.ReadInt("DefaultTileIndex"),
                    Config.ReadInt("DefaultTileForeColor"),
                    Config.ReadInt("DefaultTileBackColor")));
            }
        }
    }
}
