/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <CppUtils.h>
#include "TGlobal.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TColor
	{
	public:
		byte R, G, B;

		TColor();
		TColor(const TColor& other);
		TColor(byte r, byte g, byte b);
		TColor(RGB rgb);
		~TColor();

		static RGB ToColorRGB(byte r, byte g, byte b);
		static TColor FromColorRGB(RGB rgb);

		bool Equals(TColor& other);
		void SetEqual(TColor& other);
		RGB ToColorRGB();
		void Set(RGB rgb);
		void Set(byte r, byte g, byte b);
	};
}
