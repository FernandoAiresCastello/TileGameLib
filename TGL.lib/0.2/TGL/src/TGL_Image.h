#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"
#include "TGL_List.h"
#include "TGL_Color.h"

namespace TGL
{
	class TGLAPI TGL_Image
	{
	public:
		TGL_Image();
		~TGL_Image();

		bool Load(TGL_String filename);
		bool Load(TGL_String filename, TGL_Color transparency);
		int GetWidth() const;
		int GetHeight() const;
		int GetSize() const;
		bool IsTransparent() const;
		void SetTransparency(TGL_Color color);
		TGL_Color& GetTransparency();
		TGL_Color& GetPixel(int i);
		TGL_Color& GetPixel(int x, int y);
		TGL_List<TGL_Color>& GetPixels();

	private:
		int Width;
		int Height;
		int Size;
		bool Transparent;
		TGL_Color Transparency;
		TGL_List<TGL_Color> Pixels;
	};
}
