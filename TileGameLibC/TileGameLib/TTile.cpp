/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTile.h"

namespace TileGameLib
{
	TTile::TTile() : TTile(0, 0, 0)
	{
		Type = TTileType::Indexed;
	}

	TTile::TTile(const TTile& other) : TTile(other.Char, other.ForeColor, other.BackColor)
	{
		Type = other.Type;
	}

	TTile::TTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Type = TTileType::Indexed;
		Char = ch;
		ForeColor = fg;
		BackColor = bg;
	}

	bool TTile::operator==(const TTile& other)
	{
		return
			Type == other.Type &&
			Char == other.Char &&
			ForeColor == other.ForeColor &&
			BackColor == other.BackColor;
	}

	bool TTile::operator!=(const TTile& other)
	{
		return !operator==(other);
	}
}
