#pragma once
#include "TGL_Global.h"
#include "TGL_PointerTypes.h"
#include "TGL_Rgb.h"
#include "TGL_Color.h"
#include "TGL_String.h"
#include "TGL_Rect.h"
#include "TGL_Point.h"
#include "TGL_Size.h"
#include "TGL_Index.h"

namespace TGL
{
	class Image;
	class BitPattern;
	class Charset;

	class TGLAPI Graphics
	{
	public:
		Graphics(const Size& size, const Color& backColor);
		~Graphics();

		void SetBackColor(const Color& backColor);
		Color GetBackColor();
		void Clear();
		Size GetSize() const;
		Rect GetRect() const;
		void SetPixel(const Point& pos, const Color& color);
		Color GetPixel(int x, int y);
		void FillRect(const Rect& rect, const Color& color);
		void SetClip(const Rect& rect);
		void ResetClip();
		void DrawImage(Image* img, const Point& pos);
		void DrawImageTile(Image* img, const Rect& imgRect, const Point& dest);
		void DrawBitPattern(const BitPattern* pattern, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0);
		void DrawChar(const Charset* chars, Index index, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0);
		void DrawString(const Charset* chars, const String& str, const Point& pos, const Color& color1, const Color& color0, bool grid, bool hideColor0);

	private:
		friend class Window;

		UPtr<RGB[]> buffer = nullptr;
		int bufferLength = 0;
		Size size = { 0, 0 };
		Rect clip = { 0, 0, 0, 0 };
		Color backColor = 0x000000;
	};
}
