/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "Rect.h"

namespace TBRLGPT
{
	Rect::Rect() : Rect(0, 0, 0, 0)
	{
	}

	Rect::Rect(int x, int y, int w, int h) : X(x), Y(y), Width(w), Height(h)
	{
	}

	void Rect::Set(int x, int y, int w, int h)
	{
		X = x;
		Y = y;
		Width = w;
		Height = h;
	}

	void Rect::Reset()
	{
		Set(0, 0, 0, 0);
	}

	bool Rect::IsValid()
	{
		return Width != 0 && Height != 0;
	}

	void Rect::Move(int dx, int dy)
	{
		X += dx;
		Y += dy;
	}

	void Rect::Resize(int dx, int dy)
	{
		Width += dx;
		Height += dy;
	}
}
