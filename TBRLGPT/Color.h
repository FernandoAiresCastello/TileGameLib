/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Color
	{
	public:
		byte R, G, B;

		Color();
		Color(const Color& other);
		Color(byte r, byte g, byte b);
		Color(int rgb);
		~Color();

		static int ToInteger(byte r, byte g, byte b);
		static Color FromInteger(int rgb);

		int ToInteger();
		void SetRGB(int rgb);
		void SetRGB(byte r, byte g, byte b);
	};
}
