/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBSprite.h"

namespace TileGameLib
{
	TGBSprite::TGBSprite()
	{
	}

	TGBSprite::TGBSprite(const TGBSprite& other)
	{
		X = other.X;
		Y = other.Y;
		Tile = other.Tile;
		Visible = other.Visible;
		Priority = other.Priority;
	}

	bool TGBSprite::operator<(const TGBSprite& other) const
	{
		return Priority < other.Priority;
	}
}
