/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "Char.h"

namespace TBRLGPT
{
	const int Char::Width = 8;
	const int Char::Height = 8;
	const int Char::Size = Width * Height;
	const int Char::NullIndex = 0;
	const int Char::NullForeColor = 0xffffff;
	const int Char::NullBackColor = 0x000000;

	Char::Char()
	{
		Clear();
	}

	Char::Char(int ix, int fgc, int bgc)
	{
		Index = ix;
		ForeColorRGB = fgc;
		BackColorRGB = bgc;
	}

	Char::Char(const Char& other) : 
		Char(other.Index, other.ForeColorRGB, other.BackColorRGB)
	{
	}

	void Char::Clear()
	{
		Index = NullIndex;
		ForeColorRGB = NullForeColor;
		BackColorRGB = NullBackColor;
	}
}
