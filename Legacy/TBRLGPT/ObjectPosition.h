/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	struct TBRLGPT_API ObjectPosition
	{
		class Object* Object;
		int X;
		int Y;
		int Layer;

		ObjectPosition();
		ObjectPosition(class Object* o);
		ObjectPosition(class Object* o, int x, int y, int layer);
		ObjectPosition(int x, int y, int layer);
		ObjectPosition(const ObjectPosition& other);

		bool IsValid();
		void Invalidate();
		ObjectPosition Move(int dx, int dy);
	};
}
