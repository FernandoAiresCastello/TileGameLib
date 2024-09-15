#include "TGL_Rect.h"

namespace TGL
{
	Rect::Rect() : x1(0), y1(0), x2(0), y2(0)
	{
	}

	Rect::Rect(const Rect& other) : x1(other.x1), y1(other.y1), x2(other.x2), y2(other.y2)
	{
	}

	Rect::Rect(const Point& topLeft, const Point& btmRight) : x1(topLeft.GetX()), y1(topLeft.GetY()), x2(btmRight.GetX()), y2(btmRight.GetY())
	{
	}

	Rect::Rect(int x1, int y1, int x2, int y2) : x1(x1), y1(y1), x2(x2), y2(y2)
	{
	}

	inline Point Rect::GetTopLeft() const
	{
		return Point(x1, y1);
	}
	
	inline Point Rect::GetBtmRight() const
	{
		return Point(x2, y2);
	}

	inline int Rect::GetX1() const
	{
		return x1;
	}

	inline int Rect::GetY1() const
	{
		return y1;
	}

	inline int Rect::GetX2() const
	{
		return x2;
	}

	inline int Rect::GetY2() const
	{
		return y2;
	}

	bool Rect::Contains(const Point& point) const
	{
		return
			point.GetX() >= x1 && point.GetX() <= x2 &&
			point.GetY() >= y1 && point.GetY() <= y2;
	}

	bool Rect::Intersects(const Rect& rect) const
	{
		if (rect.x2 <= x1 || x2 <= rect.x1)
			return false;

		if (rect.y2 <= y1 || y2 <= rect.y1)
			return false;

		return true;
	}
}
