#include "TGL_Point.h"

namespace TGL
{
	Point::Point() : x(0), y(0)
	{
	}

	Point::Point(const Point& other) : x(other.x), y(other.y)
	{
	}

	Point::Point(int x, int y) : x(x), y(y)
	{
	}

	inline int Point::GetX() const
	{
		return x;
	}

	inline int Point::GetY() const
	{
		return y;
	}
}
