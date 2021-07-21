/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGLTile.h"

namespace TileGameLib
{
	TGLTile::TGLTile() : 
		TGLTile(0, 0, 0)
	{
	}

	TGLTile::TGLTile(const TGLTile& other) : 
		Char(other.Char), ForeColor(other.ForeColor), BackColor(other.BackColor)
	{
	}

	TGLTile::TGLTile(TGLCharsetIndex ch, TGLPaletteIndex fgc, TGLPaletteIndex bgc) :
		Char(ch), ForeColor(fgc), BackColor(bgc)
	{
	}

	TGLTile::~TGLTile()
	{
	}

	bool TGLTile::Equals(TGLTile& other)
	{
		return 
			Char == other.Char &&
			ForeColor == other.ForeColor &&
			BackColor == other.BackColor;
	}

	void TGLTile::SetEqual(TGLTile& other)
	{
		Char = other.Char;
		ForeColor = other.ForeColor;
		BackColor = other.BackColor;
	}
}
