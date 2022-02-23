/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TRegion
	{
	public:
		int X1, Y1, X2, Y2;

		TRegion();
		TRegion(const TRegion& other);
		TRegion(int x1, int y1, int x2, int y2);
	};
}
