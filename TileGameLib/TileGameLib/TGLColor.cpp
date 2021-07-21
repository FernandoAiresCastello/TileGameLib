/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <climits>
#include "TGLColor.h"

namespace TileGameLib
{
	TGLColor::TGLColor() : 
		TGLColor(0, 0, 0)
	{
	}

	TGLColor::TGLColor(const TGLColor& other) : 
		TGLColor(other.R, other.G, other.B)
	{
	}

	TGLColor::TGLColor(byte r, byte g, byte b) : 
		R(r), G(g), B(b)
	{
	}

	TGLColor::TGLColor(TGLColorRGB rgb)
	{
		Set(rgb);
	}

	TGLColor::~TGLColor()
	{
	}

	TGLColorRGB TGLColor::ToColorRGB(byte r, byte g, byte b)
	{
		return b | (g << CHAR_BIT) | (r << CHAR_BIT * 2);
	}

	TGLColor TGLColor::FromColorRGB(TGLColorRGB rgb)
	{
		return TGLColor(rgb);
	}

	bool TGLColor::Equals(TGLColor& other)
	{
		return R == other.R && G == other.G && B == other.B;
	}

	void TGLColor::SetEqual(TGLColor& other)
	{
		R = other.R;
		G = other.G;
		B = other.B;
	}

	TGLColorRGB TGLColor::ToColorRGB()
	{
		return B | (G << CHAR_BIT) | (R << CHAR_BIT * 2);
	}

	void TGLColor::Set(TGLColorRGB rgb)
	{
		R = (rgb & 0xff0000) >> 16;
		G = (rgb & 0x00ff00) >> 8;
		B = (rgb & 0x0000ff);
	}

	void TGLColor::Set(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}
}
