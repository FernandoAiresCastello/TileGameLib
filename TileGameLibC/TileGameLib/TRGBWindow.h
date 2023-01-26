/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"
#include "TWindowBase.h"

namespace TileGameLib
{
	class TRGBWindow : public TWindowBase
	{
	public:
		const int Cols;
		const int Rows;
		const int PixelWidth;
		const int PixelHeight;
		const int HorizontalResolution;
		const int VerticalResolution;

		TRGBWindow(int cols, int rows, int layerCount, int pixelWidth, int pixelHeight);
		virtual ~TRGBWindow();
		virtual void Update();

		int GetAnimationFrameIndex();
		void DrawPixels(std::string& pixels, RGB c0, RGB c1, RGB c2, RGB c3, bool ignoreC0, bool alignToGrid, int x, int y);

	private:
		virtual void SetPixel(int x, int y, RGB rgb);
	};
}
