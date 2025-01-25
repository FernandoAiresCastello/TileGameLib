#pragma once
#include "TGL_Global.h"
#include "TGL_Rect.h"

namespace TGL
{
	class TGLAPI Size
	{
	public:
		Size();
		Size(const Size& other);
		Size(int width, int height);

		inline int GetWidth() const;
		inline int GetHeight() const;
		inline Rect GetRect() const;

	private:
		int width = 0;
		int height = 0;
	};
}
