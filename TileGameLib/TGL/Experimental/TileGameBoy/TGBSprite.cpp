#include "TGBSprite.h"

namespace TGL_Internal
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
