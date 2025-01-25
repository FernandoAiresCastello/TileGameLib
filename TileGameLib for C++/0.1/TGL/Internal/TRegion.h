#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TGL_Internal
{
	class TRegion
	{
	public:
		int X1, Y1, X2, Y2;

		TRegion();
		TRegion(const TRegion& other);
		TRegion(int x1, int y1, int x2, int y2);

		bool operator==(const TRegion& other);
		bool operator!=(const TRegion& other);

		void Set(int x1, int y1, int x2, int y2);
	};
}
