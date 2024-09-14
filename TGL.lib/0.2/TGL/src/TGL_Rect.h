#pragma once
#include "TGL_Globals.h"
#include "TGL_Point.h"

namespace TGL
{
	class TGLAPI Rect
	{
	public:
		Rect();
		Rect(const Rect& other);
		Rect(const Point& topLeft, const Point& btmRight);
		Rect(int x1, int y1, int x2, int y2);

		inline Point GetTopLeft() const;
		inline Point GetBtmRight() const;
		inline int GetX1() const;
		inline int GetY1() const;
		inline int GetX2() const;
		inline int GetY2() const;

	private:
		int x1 = 0;
		int y1 = 0;
		int x2 = 0;
		int y2 = 0;
	};
}
