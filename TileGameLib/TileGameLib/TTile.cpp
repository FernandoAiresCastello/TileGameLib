/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTile.h"

namespace TileGameLib
{
	TTile::TTile() : 
		TTile(0, 0, 0)
	{
	}

	TTile::TTile(const TTile& other) : 
		Char(other.Char), ForeColor(other.ForeColor), BackColor(other.BackColor)
	{
	}

	TTile::TTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc) :
		Char(ch), ForeColor(fgc), BackColor(bgc)
	{
	}

	TTile::~TTile()
	{
	}

	bool TTile::Equals(TTile& other)
	{
		return 
			Char == other.Char &&
			ForeColor == other.ForeColor &&
			BackColor == other.BackColor;
	}

	void TTile::SetEqual(TTile& other)
	{
		Char = other.Char;
		ForeColor = other.ForeColor;
		BackColor = other.BackColor;
	}
}
