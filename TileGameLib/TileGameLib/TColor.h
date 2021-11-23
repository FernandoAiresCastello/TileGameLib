/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

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
		TColor(int rgb);
		~TColor();

		static int ToColorRGB(byte r, byte g, byte b);
		static TColor FromColorRGB(int rgb);

		bool Equals(TColor& other);
		void SetEqual(TColor& other);
		int ToColorRGB();
		void Set(int rgb);
		void Set(byte r, byte g, byte b);
	};
}
