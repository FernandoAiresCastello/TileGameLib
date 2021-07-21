/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#include "TGLGlobal.h"
#include "TGLClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLColor : TGLClass
	{
	public:
		byte R, G, B;

		TGLColor();
		TGLColor(const TGLColor& other);
		TGLColor(byte r, byte g, byte b);
		TGLColor(TGLColorRGB rgb);
		~TGLColor();

		static TGLColorRGB ToColorRGB(byte r, byte g, byte b);
		static TGLColor FromColorRGB(TGLColorRGB rgb);

		bool Equals(TGLColor& other);
		void SetEqual(TGLColor& other);
		TGLColorRGB ToColorRGB();
		void Set(TGLColorRGB rgb);
		void Set(byte r, byte g, byte b);
	};
}
