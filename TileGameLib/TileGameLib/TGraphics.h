/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TWindow;
	class TCharset;
	class TPalette;

	class TILEGAMELIB_API TGraphics : TClass
	{
	public:
		TGraphics(TWindow* window, TCharset* chars, TPalette* pal);
		TGraphics(const TGraphics& other) = delete;
		~TGraphics();

		TWindow* Window;
		TCharset* Chars;
		TPalette* Pal;
	};
}
