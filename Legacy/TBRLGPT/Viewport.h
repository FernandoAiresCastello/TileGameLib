/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"
#include "Rect.h"

namespace TBRLGPT
{
	class TBRLGPT_API Viewport
	{
	public:
		Viewport();
		Viewport(int x, int y, int width, int height);
		Viewport(Rect rect);
		~Viewport();

		void SetX(int x);
		void SetY(int y);
		void SetWidth(int width);
		void SetHeight(int height);
		void Set(int x, int y, int width, int height);
		void Set(Rect rect);
		void SetScrollX(int x);
		void SetScrollY(int y);
		void ScrollTo(int x, int y);
		void Scroll(int dx, int dy);

		int GetX();
		int GetY();
		int GetWidth();
		int GetHeight();
		int GetScrollX();
		int GetScrollY();
		Rect GetRect();

	private:
		int X;
		int Y;
		int Width;
		int Height;
		int ScrollX;
		int ScrollY;
	};
}
