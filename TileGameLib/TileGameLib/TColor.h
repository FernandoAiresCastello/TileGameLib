/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <CppUtils.h>
#include "TGlobal.h"
#include "TClass.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TColor : TClass
	{
	public:
		byte R, G, B;

		TColor();
		TColor(const TColor& other);
		TColor(byte r, byte g, byte b);
		TColor(TColorRGB rgb);
		~TColor();

		static TColorRGB ToColorRGB(byte r, byte g, byte b);
		static TColor FromColorRGB(TColorRGB rgb);

		bool Equals(TColor& other);
		void SetEqual(TColor& other);
		TColorRGB ToColorRGB();
		void Set(TColorRGB rgb);
		void Set(byte r, byte g, byte b);
	};
}
