/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"
#include "Object.h"

namespace TBRLGPT
{
	class Map;
	class UIContext;

	class TBRLGPT_API MapUtils
	{
	public:
		static void DrawFlatMap(UIContext* ctx, Map* map, int offsetX = 0, int offsetY = 0);
	};
}
