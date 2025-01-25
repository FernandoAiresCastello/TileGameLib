#include "TGL_Size.h"

namespace TGL
{
	Size::Size() : width(0), height(0)
	{
	}

	Size::Size(const Size& other) : width(other.width), height(other.height)
	{
	}

	Size::Size(int width, int height) : width(width), height(height)
	{
	}
	
	inline int Size::GetWidth() const
	{
		return width;
	}

	inline int Size::GetHeight() const
	{
		return height;
	}

	inline Rect Size::GetRect() const
	{
		return Rect(0, 0, width - 1, height - 1);
	}
}
