#pragma once
#include <SDL.h>
#include "../../Internal/TGlobal.h"

namespace TGL_Internal
{
	class TGBTile
	{
	public:
		int Index;
		PaletteIndex Color0;
		PaletteIndex Color1;
		PaletteIndex Color2;
		PaletteIndex Color3;
		bool Transparent;

		TGBTile();
		TGBTile(const TGBTile& other);
		TGBTile(int index, PaletteIndex c0, PaletteIndex c1, PaletteIndex c2, PaletteIndex c3, bool transparent);

		void SetEmpty();
		bool IsEmpty();
	};
}
