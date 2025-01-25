#include "TGL_SpriteBase.h"

namespace TGL
{
	SpriteBase::SpriteBase() : pos(0, 0), visible(true)
	{
	}

	SpriteBase::~SpriteBase()
	{
	}

	void SpriteBase::SetPos(const Point& pos)
	{
		this->pos = pos;
	}

	void SpriteBase::Move(int dx, int dy)
	{
		pos = pos.Move(dx, dy);
	}

	Point SpriteBase::GetPos() const
	{
		return pos;
	}

	void SpriteBase::SetVisible(bool visible)
	{
		this->visible = visible;
	}

	bool SpriteBase::IsVisible() const
	{
		return visible;
	}
}
