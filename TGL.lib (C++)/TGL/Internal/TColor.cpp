#include <climits>
#include "TColor.h"

namespace TGL_Internal
{
	TColor::TColor() : 
		TColor(0, 0, 0)
	{
	}

	TColor::TColor(const TColor& other) : 
		TColor(other.R, other.G, other.B)
	{
	}

	TColor::TColor(byte r, byte g, byte b) : 
		R(r), G(g), B(b)
	{
	}

	TColor::TColor(RGB rgb)
	{
		Set(rgb);
	}

	TColor::~TColor()
	{
	}

	RGB TColor::ToColorRGB(byte r, byte g, byte b)
	{
		return b | (g << CHAR_BIT) | (r << CHAR_BIT * 2);
	}

	TColor TColor::FromColorRGB(RGB rgb)
	{
		return TColor(rgb);
	}

	bool TColor::Equals(TColor& other)
	{
		return R == other.R && G == other.G && B == other.B;
	}

	void TColor::SetEqual(TColor& other)
	{
		R = other.R;
		G = other.G;
		B = other.B;
	}

	RGB TColor::ToColorRGB()
	{
		return B | (G << CHAR_BIT) | (R << CHAR_BIT * 2);
	}

	void TColor::Set(RGB rgb)
	{
		R = (rgb & 0xff0000) >> 16;
		G = (rgb & 0x00ff00) >> 8;
		B = (rgb & 0x0000ff);
	}

	void TColor::Set(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}
}
