/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TSprite.h"

namespace TileGameLib
{
	void TSprite::SetPos(int x, int y)
	{
		X = x;
		Y = y;
	}

	void TSprite::Move(int dx, int dy)
	{
		X += dx;
		Y += dy;
	}
}
