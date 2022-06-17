/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TGBTile.h"

namespace TileGameLib
{
	class TGBTileset
	{
	public:
		TGBTileset();

		void Add(TGBTile& tile);
		TGBTile& Get(int index);
		void DeleteAll();
		int GetSize();

	private:
		std::vector<TGBTile> Tiles;
	};
}
