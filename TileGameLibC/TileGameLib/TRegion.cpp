/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TRegion.h"

namespace TileGameLib
{
	TRegion::TRegion() : TRegion(0, 0, 0, 0)
	{
	}

	TRegion::TRegion(const TRegion& other) : 
		TRegion(other.X1, other.Y1, other.X2, other.Y2)
	{
	}

	TRegion::TRegion(int x1, int y1, int x2, int y2) : 
		X1(x1), Y1(y1),  X2(x2), Y2(y2)
	{
	}
}
