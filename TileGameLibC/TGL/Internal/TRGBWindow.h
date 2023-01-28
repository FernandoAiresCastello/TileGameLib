#pragma once
#include <SDL.h>
#include "TGlobal.h"
#include "TWindowBase.h"
#include "TRegion.h"

namespace TGL_Internal
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

		TRGBWindow(int cols, int rows, int pixelWidth, int pixelHeight, RGB backColor);
		virtual ~TRGBWindow();
		virtual void Update();

		int GetFrame();
		void DrawPixelBlock8x8(std::string& pixels, RGB c0, RGB c1, RGB c2, RGB c3, bool ignoreC0, int x, int y);
		void SetClip(int x1, int y1, int x2, int y2, RGB clipBackColor);
		void SetClipBackColor(RGB rgb);
		void RemoveClip();
		bool HasClip();
		bool IsInsideClip(int x, int y);
		bool IsOutsideClip(int x, int y);
		TRegion& GetClip();
		void ClearBackgroundInsideClip();

	private:
		TRegion Clip;
		RGB ClipBackColor;

		virtual void SetPixel(int x, int y, RGB rgb);
	};
}
