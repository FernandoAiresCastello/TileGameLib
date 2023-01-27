#pragma once
#include <SDL.h>
#include <vector>
#include "../../Internal/TGlobal.h"
#include "TGBTileDef.h"

namespace TGL_Internal
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
