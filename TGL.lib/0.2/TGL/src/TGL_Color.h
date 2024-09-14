#pragma once
#include "TGL_Globals.h"
#include "TGL_RGB.h"

namespace TGL
{
	class TGLAPI Color
	{
	public:
		Color();
		Color(RGB rgb);
		Color(int r, int g, int b);
		Color(const Color& other);

		bool operator==(const Color& other) const;
		Color& operator=(const Color& other);

		inline RGB ToRGB() const;
		inline static RGB PackRGB(int r, int g, int b);
		inline static void UnpackRGB(RGB rgb, int* r, int* g, int* b);
		static Color GetRandom();

		void Set(RGB rgb);
		void Set(int r, int g, int b);
		void SetR(int r);
		void SetG(int g);
		void SetB(int b);
		int GetR() const;
		int GetG() const;
		int GetB() const;

	private:
		int r = 0;
		int g = 0;
		int b = 0;
	};
}
