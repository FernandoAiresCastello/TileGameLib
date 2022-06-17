/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TGBTileDef.h"

namespace TileGameLib
{
	class TGBTileset
	{
	public:
		TGBTileset();

		void Add(TGBTileDef& tile);
		TGBTileDef& Get(int index);
		void DeleteAll();
		int GetSize();

	private:
		std::vector<TGBTileDef> Tiles;
	};
}
