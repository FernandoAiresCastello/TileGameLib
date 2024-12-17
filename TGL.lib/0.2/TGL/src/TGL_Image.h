#pragma once
#include "TGL_Global.h"
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
		Image(const Size& size);
		Image(const String& filename);
		virtual ~Image();

		bool Load(const String& filename);
		bool Load(const String& filename, const Color& transparency);
		Size GetSize() const;
		int GetPixelCount() const;
		bool IsTransparent() const;
		void SetTransparency(const Color& color);
		const Color& GetTransparency() const;
		const Color& GetPixel(int i) const;
		const Color& GetPixel(const Point& point) const;
		List<Color>& GetPixels();
		void SetPixel(const Color& color, int i);
		void SetPixel(const Color& color, const Point& point);

	protected:
		Size size;
		int pixelCount;
		bool transparent;
		Color transparency;
		List<Color> pixels;
	};
}
