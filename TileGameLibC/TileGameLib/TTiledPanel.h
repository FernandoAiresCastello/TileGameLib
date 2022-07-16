/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include "TGlobal.h"

namespace TileGameLib
{
	class TTiledPanel
	{
	public:
		TTiledPanel();

	private:
		int X;
		int Y;
		int Width;
		int Height;
		int BufWidth;
		int BufHeight;
		int ScrollX;
		int ScrollY;
	};
}
