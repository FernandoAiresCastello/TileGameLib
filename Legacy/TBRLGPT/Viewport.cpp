/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Viewport.h"

namespace TBRLGPT
{
	Viewport::Viewport() : Viewport(0, 0, 0, 0)
	{
	}

	Viewport::Viewport(int x, int y, int width, int height) : ScrollX(0), ScrollY(0)
	{
		Set(x, y, width, height);
	}

	Viewport::Viewport(Rect rect) : Viewport(rect.X, rect.Y, rect.Width, rect.Height)
	{

	}

	Viewport::~Viewport()
	{
	}

	void Viewport::SetX(int x)
	{
		X = x;
	}

	void Viewport::SetY(int y)
	{
		Y = y;
	}

	void Viewport::SetWidth(int width)
	{
		Width = width;
	}

	void Viewport::SetHeight(int height)
	{
		Height = height;
	}

	void Viewport::Set(int x, int y, int width, int height)
	{
		SetX(x);
		SetY(y);
		SetWidth(width);
		SetHeight(height);
	}

	void Viewport::Set(Rect rect)
	{
		Set(rect.X, rect.Y, rect.Width, rect.Height);
	}

	void Viewport::SetScrollX(int x)
	{
		ScrollX = x;
	}

	void Viewport::SetScrollY(int y)
	{
		ScrollY = y;
	}

	void Viewport::ScrollTo(int x, int y)
	{
		SetScrollX(x);
		SetScrollY(y);
	}

	void Viewport::Scroll(int dx, int dy)
	{
		SetScrollX(ScrollX + dx);
		SetScrollY(ScrollY + dy);
	}

	int Viewport::GetX()
	{
		return X;
	}

	int Viewport::GetY()
	{
		return Y;
	}

	int Viewport::GetWidth()
	{
		return Width;
	}

	int Viewport::GetHeight()
	{
		return Height;
	}

	int Viewport::GetScrollX()
	{
		return ScrollX;
	}

	int Viewport::GetScrollY()
	{
		return ScrollY;
	}

	Rect Viewport::GetRect()
	{
		return Rect(X, Y, Width, Height);
	}
}
