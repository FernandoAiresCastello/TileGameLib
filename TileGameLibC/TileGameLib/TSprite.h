/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include "TTileSeq.h"

namespace TileGameLib
{
	class TSprite
	{
	public:
		std::string Id;
		TTileSeq Tile;
		bool Visible = true;
		bool Transparent = false;
		int X = 0;
		int Y = 0;

		void SetPos(int x, int y);
		void Move(int dx, int dy);
	};
}
