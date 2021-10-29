using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class MCTileset
    {
        private readonly List<MCTile> Tiles = new List<MCTile>();

        public MCTileset()
        {
        }

        public void Add(MCTile tile)
        {
            Tiles.Add(tile);
        }

        public void AddBlank()
        {
            Add(MCTile.MakeTransparent());
        }

        public void Set(int index, MCTile tile)
        {
            Tiles[index].SetEqual(tile);
        }

        public MCTile Get(int index)
        {
            return Tiles[index];
        }
    }
}
