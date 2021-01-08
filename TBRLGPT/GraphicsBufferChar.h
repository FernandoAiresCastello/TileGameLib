/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	struct TBRLGPT_API GraphicsBufferChar
	{
		ushort CharIx;
		byte ForeColorIx;
		byte BackColorIx;

		GraphicsBufferChar() : CharIx(0), ForeColorIx(0), BackColorIx(0) {}
		GraphicsBufferChar(int ix, int fgc, int bgc) : CharIx(ix), ForeColorIx(fgc), BackColorIx(bgc) {}
		~GraphicsBufferChar() {}
	};
}
