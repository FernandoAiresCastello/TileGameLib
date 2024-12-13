#pragma once
#include "TGL_Global.h"
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
		void Set(int x1, int y1, int x2, int y2);
		void SetX1(int x);
		void SetY1(int y);
		void SetX2(int x);
		void SetY2(int y);
		bool Contains(const Point& point) const;
		bool Intersects(const Rect& rect) const;

	private:
		int x1 = 0;
		int y1 = 0;
		int x2 = 0;
		int y2 = 0;
	};
}
