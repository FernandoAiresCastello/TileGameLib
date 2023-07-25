#include "TSprite.h"

namespace TGL_Internal
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
