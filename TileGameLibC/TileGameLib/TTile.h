/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	enum class TTileType { Indexed, PixelBlock };

	class TTile
	{
	public:
		TTileType Type;
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
