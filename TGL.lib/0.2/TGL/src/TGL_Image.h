#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_List.h"
#include "TGL_Color.h"

namespace TGL
{
	class TGLAPI Image
	{
	public:
		Image();
		~Image();

		bool Load(const String& filename);
		bool Load(const String& filename, const Color& transparency);
		int GetWidth() const;
		int GetHeight() const;
		int GetSize() const;
		bool IsTransparent() const;
		void SetTransparency(const Color& color);
		Color& GetTransparency();
		Color& GetPixel(int i);
		Color& GetPixel(int x, int y);
		List<Color>& GetPixels();

	private:
		int width;
		int height;
		int size;
		bool transparent;
		Color transparency;
		List<Color> pixels;
	};
}
