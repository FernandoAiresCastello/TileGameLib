#pragma once
#include "TGL_Globals.h"
#include "TGL_Rgb.h"

namespace TGL
{
	class TGLAPI TGL_Color
	{
	public:
		TGL_Color();
		TGL_Color(TGL_Rgb rgb);
		TGL_Color(int r, int g, int b);
		TGL_Color(const TGL_Color& other);

		bool operator==(const TGL_Color& other) const;
		TGL_Color& operator=(const TGL_Color& other);

		static TGL_Rgb PackRgb(int r, int g, int b);
		static void UnpackRgb(TGL_Rgb rgb, int* r, int* g, int* b);
		static TGL_Color GetRandom();

		void Set(TGL_Rgb rgb);
		void Set(int r, int g, int b);
		void SetR(int r);
		void SetG(int g);
		void SetB(int b);
		int GetR() const;
		int GetG() const;
		int GetB() const;
		TGL_Rgb ToRgb() const;

	private:
		int r = 0;
		int g = 0;
		int b = 0;
	};
}
