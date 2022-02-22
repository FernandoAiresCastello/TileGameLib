/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TTile
	{
	public:
		CharsetIndex Char;
		PaletteIndex ForeColor;
		PaletteIndex BackColor;

		TTile();
		TTile(const TTile& other);
		TTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg);

		bool operator==(const TTile& other);
		bool operator!=(const TTile& other);
	};
}
