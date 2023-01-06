/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBTileset.h"

namespace TileGameLib
{
	TGBTileset::TGBTileset()
	{
	}
	
	void TGBTileset::Add(TGBTileDef& tile)
	{
		Tiles.push_back(tile);
	}

	TGBTileDef& TGBTileset::Get(int index)
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
