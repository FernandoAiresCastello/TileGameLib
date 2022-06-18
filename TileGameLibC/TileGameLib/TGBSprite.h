/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TGBTile.h"

namespace TileGameLib
{
	class TGBSprite
	{
	public:
		TGBSprite();
		TGBSprite(const TGBSprite& other);

		int X = 0;
		int Y = 0;
		TGBTile Tile;
		bool Visible = true;
		int Priority = 0;

		bool operator<(const TGBSprite& other) const;
	};
}
