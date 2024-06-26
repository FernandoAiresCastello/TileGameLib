#include "TTile.h"

namespace TGL_Internal
{
	TTile::TTile() : TTile(0, 0, 0)
	{
	}

	TTile::TTile(const TTile& other) : TTile(other.Char, other.ForeColor, other.BackColor)
	{
	}

	TTile::TTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg)
	{
		Char = ch;
		ForeColor = fg;
		BackColor = bg;
	}

	bool TTile::operator==(const TTile& other)
	{
		return
			Char == other.Char &&
			ForeColor == other.ForeColor &&
			BackColor == other.BackColor;
	}

	bool TTile::operator!=(const TTile& other)
	{
		return !operator==(other);
	}
}
