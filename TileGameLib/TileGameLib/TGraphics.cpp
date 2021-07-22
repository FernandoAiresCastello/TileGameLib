/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGraphics.h"
#include "TWindow.h"
#include "TCharset.h"
#include "TPalette.h"

namespace TileGameLib
{
	TGraphics::TGraphics(TWindow* window, TCharset* chars, TPalette* pal) :
		Window(window), Chars(chars), Pal(pal)
	{
	}
	
	TGraphics::~TGraphics()
	{
	}
}
