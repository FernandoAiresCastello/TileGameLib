using System;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public class Tileset
    {
        private readonly Dictionary<string, TileSeq> tiles = new Dictionary<string, TileSeq>();

        public TileSeq Get(string id)
        {
            return tiles.ContainsKey(id) ? tiles[id] : null;
        }

        public void Add(string id, Rgb[] pixels)
        {
            Add(id, Tile.Rgb(pixels));
        }

        public void Add(string id, BinaryString pixels)
        {
            Add(id, Tile.Binary(pixels));
        }

        private void Add(string id, Tile tile)
        {
            if (tiles.ContainsKey(id))
            {
                tiles[id].Add(tile);
            }
            else
            {
                tiles[id] = new TileSeq(tile);
            }
        }
    }
}
