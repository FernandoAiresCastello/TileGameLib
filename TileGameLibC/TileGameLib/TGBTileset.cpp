/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBTileset.h"

namespace TileGameLib
{
	TGBTileset::TGBTileset()
	{
	}
	
	void TGBTileset::Add(TGBTile& tile)
	{
		Tiles.push_back(tile);
	}

	TGBTile& TGBTileset::Get(int index)
	{
		return Tiles[index];
	}

	void TGBTileset::DeleteAll()
	{
		Tiles.clear();
	}

	int TGBTileset::GetSize()
	{
		return Tiles.size();
	}
}
