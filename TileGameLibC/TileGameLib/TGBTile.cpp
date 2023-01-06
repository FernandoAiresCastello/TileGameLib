/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBTile.h"

namespace TileGameLib
{
	TGBTile::TGBTile()
	{
		SetEmpty();
	}

	TGBTile::TGBTile(const TGBTile& other) : 
		TGBTile(other.Index, other.Color0, other.Color1, other.Color2, other.Color3, other.Transparent)
	{
	}

	TGBTile::TGBTile(int index, PaletteIndex c0, PaletteIndex c1, PaletteIndex c2, PaletteIndex c3, bool transparent)
	{
		Index = index;
		Color0 = c0;
		Color1 = c1;
		Color2 = c2;
		Color3 = c3;
		Transparent = transparent;
	}

	void TGBTile::SetEmpty()
	{
		Index = -1;
		Color0 = 0;
		Color1 = 0;
		Color2 = 0;
		Color3 = 0;
		Transparent = false;
	}

	bool TGBTile::IsEmpty()
	{
		return Index == -1;
	}
}
