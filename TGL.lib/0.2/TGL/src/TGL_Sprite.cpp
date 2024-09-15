#include "TGL_Sprite.h"

namespace TGL
{
	Sprite::Sprite() : size(0, 0), pos(0, 0), visible(true)
	{
	}

	Sprite::~Sprite()
	{
	}

	void Sprite::SetSize(const Size& size)
	{
		this->size = size;
	}

	void Sprite::SetPos(const Point& pos)
	{
		this->pos = pos;
	}

	void Sprite::Move(int dx, int dy)
	{
		pos = pos.Move(dx, dy);
	}

	Size Sprite::GetSize() const
	{
		return size;
	}

	Point Sprite::GetPos() const
	{
		return pos;
	}

	void Sprite::SetVisible(bool visible)
	{
		this->visible = visible;
	}

	bool Sprite::IsVisible() const
	{
		return visible;
	}
}
