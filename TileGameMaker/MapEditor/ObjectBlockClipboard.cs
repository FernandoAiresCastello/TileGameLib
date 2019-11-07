using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameMaker.MapEditor
{
    public class ObjectBlockClipboard
    {
        public GameObject[,] Objects { get; private set; }
        public Rectangle Block { get; private set; }

        public ObjectBlockClipboard(Rectangle block)
        {
            Block = block;
            Clear();
        }

        public void Clear()
        {
            Objects = new GameObject[Block.Width, Block.Height];
        }

        public void SetObject(GameObject o, int col, int row)
        {
            Objects[col, row] = o?.Copy();
        }
    }
}
