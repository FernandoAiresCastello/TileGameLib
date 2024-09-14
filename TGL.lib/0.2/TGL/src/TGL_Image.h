#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_List.h"
#include "TGL_Color.h"
#include "TGL_Point.h"
#include "TGL_Size.h"

namespace TGL
{
	class TGLAPI Image
	{
	public:
		Image();
		~Image();

		bool Load(const String& filename);
		bool Load(const String& filename, const Color& transparency);
		Size GetSize() const;
		int GetPixelCount() const;
		bool IsTransparent() const;
		void SetTransparency(const Color& color);
		Color& GetTransparency();
		Color& GetPixel(int i);
		Color& GetPixel(const Point& point);
		List<Color>& GetPixels();

	private:
		Size size;
		int pixelCount;
		bool transparent;
		Color transparency;
		List<Color> pixels;
	};
}
