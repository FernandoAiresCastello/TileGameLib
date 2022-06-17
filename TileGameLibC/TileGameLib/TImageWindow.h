/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"
#include "TWindowBase.h"

namespace TileGameLib
{
	class TTiledImage;

	class TImageWindow : public TWindowBase
	{
	public:
		TImageWindow(int width, int height);
		virtual ~TImageWindow();

		void DrawImageTile(TTiledImage* timg, int tix, int x, int y);
	};
}
