using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Graphics;

namespace TileGameMaker.Component
{
    public class AnimationStrip : TiledDisplay
    {
        public ObjectAnim Animation { set; get; } = new ObjectAnim(false);

        public AnimationStrip(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            ShowGrid = true;
            for (int i = 0; i < Graphics.Cols; i++)
                Animation.AddFrame(new Tile(0, 0, Graphics.Palette.Size - 1));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < Graphics.Cols; i++)
                Graphics.PutTile(i, 0, 0, 0, Graphics.Palette.Size - 1);

            int x = 0;
            foreach (Tile tile in Animation.Frames)
                Graphics.PutTile(x++, 0, tile.TileIx, tile.ForeColorIx, tile.BackColorIx);

            base.OnPaint(e);
        }

        public void Clear()
        {
            Animation.Clear(false);
            for (int i = 0; i < Graphics.Cols; i++)
                Animation.AddFrame(new Tile(0, 0, Graphics.Palette.Size - 1));
        }
    }
}
