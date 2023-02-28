#include "TGBTileset.h"

namespace TGL_Internal
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
