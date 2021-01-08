/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	struct TBRLGPT_API Position
	{
		int X;
		int Y;
		int Z;

		Position();
		Position(int x, int y);
		Position(int x, int y, int z);

		bool IsPositive();
		void Translate(int dx, int dy, int dz);
	};
}
