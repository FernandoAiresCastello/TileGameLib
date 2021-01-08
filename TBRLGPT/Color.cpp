/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include <climits>
#include "Color.h"

namespace TBRLGPT
{
	Color::Color()
	{
		SetRGB(0, 0, 0);
	}

	Color::Color(const Color& other)
	{
		R = other.R;
		G = other.G;
		B = other.B;
	}

	Color::Color(byte r, byte g, byte b)
	{
		SetRGB(r, g, b);
	}

	Color::Color(int rgb)
	{
		SetRGB(rgb);
	}

	Color::~Color()
	{
	}

	int Color::ToInteger(byte r, byte g, byte b)
	{
		return b | (g << CHAR_BIT) | (r << CHAR_BIT * 2);
	}

	Color Color::FromInteger(int rgb)
	{
		return Color(rgb);
	}

	int Color::ToInteger()
	{
		return B | (G << CHAR_BIT) | (R << CHAR_BIT * 2);
	}

	void Color::SetRGB(int rgb)
	{
		R = (rgb & 0xff0000) >> 16;
		G = (rgb & 0x00ff00) >> 8;
		B = (rgb & 0x0000ff);
	}

	void Color::SetRGB(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}
}
