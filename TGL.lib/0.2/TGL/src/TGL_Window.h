#pragma once
#include "TGL_Globals.h"
#include "TGL_Rgb.h"

namespace TGL
{
	class TGLAPI TGL_Window
	{
	public:
		TGL_Window();
		~TGL_Window();

		void Create(int width, int height, TGL_Rgb backColor);
		void Show();
		void ClearBackground();
		void ClearToRgb(TGL_Rgb rgb);
		void Update();
		bool IsOpen();
	};
}
