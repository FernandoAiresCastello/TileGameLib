/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TTile : TClass
	{
	public:
		TCharsetIndex Char;
		TPaletteIndex ForeColor;
		TPaletteIndex BackColor;

		TTile();
		TTile(const TTile& other);
		TTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		~TTile();

		bool Equals(TTile& other);
		void SetEqual(TTile& other);
	};
}
