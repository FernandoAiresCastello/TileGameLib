/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Position.h"

namespace TBRLGPT
{
	Position::Position()
	{
		X = 0;
		Y = 0;
		Z = 0;
	}

	Position::Position(int x, int y)
	{
		X = x;
		Y = y;
		Z = 0;
	}

	Position::Position(int x, int y, int z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	bool Position::IsPositive()
	{
		return X >= 0 && Y >= 0 && Z >= 0;
	}

	void Position::Translate(int dx, int dy, int dz)
	{
		X += dx;
		Y += dy;
		Z += dz;
	}
}
