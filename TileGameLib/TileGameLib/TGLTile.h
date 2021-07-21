/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGLGlobal.h"
#include "TGLClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLTile : TGLClass
	{
	public:
		TGLCharsetIndex Char;
		TGLPaletteIndex ForeColor;
		TGLPaletteIndex BackColor;

		TGLTile();
		TGLTile(const TGLTile& other);
		TGLTile(TGLCharsetIndex ch, TGLPaletteIndex fgc, TGLPaletteIndex bgc);
		~TGLTile();

		bool Equals(TGLTile& other);
		void SetEqual(TGLTile& other);
	};
}
