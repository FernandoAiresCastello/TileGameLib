/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

namespace TBRLGPT
{
	class ObjectChar;
	class Palette;

	struct TBRLGPT_API CharInstance
	{
		ObjectChar* Char;
		Palette* Pal;
		int X;
		int Y;
	};
}
