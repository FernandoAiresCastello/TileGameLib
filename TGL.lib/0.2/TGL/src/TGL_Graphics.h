#pragma once
#include "TGL_Globals.h"
#include "TGL_Rgb.h"
#include "TGL_Color.h"
#include "TGL_String.h"
#include "TGL_Rect.h"
#include "TGL_Point.h"
#include "TGL_Size.h"
#include "TGL_PixelBlock.h"
#include "TGL_Image.h"

namespace TGL
{
	class TGLAPI Graphics
	{
	public:
		Graphics(const Size& size);
		~Graphics();

		RGB* GetBuffer();
		int GetBufferLength() const;
		void ClearToColor(const Color& color);
		void SaveScreenshot(const String& file) const;
		Size GetSize() const;
		Rect GetRect() const;
		void SetPixel(const Point& pos, const Color& color);
		Color GetPixel(int x, int y);
		void FillRect(const Rect& rect, const Color& color);
		void SetClip(const Rect& rect);
		void ResetClip();
		void DrawPixelBlock(PixelBlock* block, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0);
		void DrawImage(Image* img, const Point& pos);
		void DrawImageTile(Image* img, const Rect& imgRect, const Point& dest);

	private:
		RGB* buffer = nullptr;
		int bufferLength = 0;
		Size size = { 0, 0 };
		Rect clip = { 0, 0, 0, 0 };
	};
}
