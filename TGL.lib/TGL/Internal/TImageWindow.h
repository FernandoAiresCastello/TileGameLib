#pragma once
#include <SDL.h>
#include "TGlobal.h"
#include "TWindowBase.h"

namespace TGL_Internal
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
