/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Char
	{
	public:
		static const int Width;
		static const int Height;
		static const int Size;
		static const int NullIndex;
		static const int NullForeColor;
		static const int NullBackColor;

		int Index;
		int ForeColorRGB;
		int BackColorRGB;

		Char();
		Char(int ix, int fgc, int bgc);
		Char(const Char& other);

		void Clear();
	};
}
