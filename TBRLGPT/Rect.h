/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	struct TBRLGPT_API Rect
	{
		int X;
		int Y;
		int Width;
		int Height;

		Rect();
		Rect(int x, int y, int w, int h);

		void Set(int x, int y, int w, int h);
		void Reset();
		bool IsValid();
		void Move(int dx, int dy);
		void Resize(int dx, int dy);
	};
}
