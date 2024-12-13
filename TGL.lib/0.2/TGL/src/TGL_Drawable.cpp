#include "TGL_Drawable.h"

namespace TGL
{
	Drawable::Drawable() : pos(0, 0), visible(true)
	{
	}

	Drawable::~Drawable()
	{
	}

	void Drawable::SetPos(const Point& pos)
	{
		this->pos = pos;
	}

	void Drawable::Move(int dx, int dy)
	{
		pos = pos.Move(dx, dy);
	}

	Point Drawable::GetPos() const
	{
		return pos;
	}

	void Drawable::SetVisible(bool visible)
	{
		this->visible = visible;
	}

	bool Drawable::IsVisible() const
	{
		return visible;
	}
}
