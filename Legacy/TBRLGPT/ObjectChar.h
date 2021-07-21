/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API ObjectChar
	{
	public:
		static const int NullIndex;
		static const int NullForeColorIx;
		static const int NullBackColorIx;

		ushort Index;
		byte ForeColorIx;
		byte BackColorIx;

		ObjectChar();
		ObjectChar(ushort ix, byte fgc, byte bgc);
		ObjectChar(const ObjectChar& other);

		void SetNull();
		bool IsNull();
		bool Equals(ObjectChar& other);
		void InvertColors();
	};
}
