using System;
using System.Collections;
using System.Collections.Generic;

public class Tileset
{
    private Dictionary<string, TileSeq> tiles;

    public TileSeq Get(string id)
    {
        if (tiles.ContainsKey(id))
        {
            return tiles[id];
        }
        else
        {
            return null;
        }
    }

    public void Add(string id, Rgb[] pixels)
    {
        Add(id, new Tile(pixels));
    }

    public void Add(string id, Binary pixels)
    {
        Add(id, new Tile(pixels));
    }

    private void Add(string id, Tile tile)
    {
        if (tiles.ContainsKey(id))
        {
            tiles[id].Add(tile);
        }
        else
        {
            tiles[id] = new TileSeq();
            tiles[id].Add(tile);
        }
    }
}
