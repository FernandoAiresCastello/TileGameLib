#pragma once
#include "TGL_Global.h"

namespace TGL
{
	class TGLAPI Point
	{
	public:
		Point();
		Point(const Point& other);
		Point(int x, int y);

		inline int GetX() const;
		inline int GetY() const;

		Point Move(int dx, int dy) const;

	private:
		int x = 0;
		int y = 0;
	};
}
