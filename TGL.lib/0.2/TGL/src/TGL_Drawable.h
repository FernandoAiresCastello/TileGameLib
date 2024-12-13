#pragma once
#include "TGL_Global.h"
#include "TGL_Point.h"
#include "TGL_Size.h"

namespace TGL
{
	class Graphics;
	class Image;

	class TGLAPI Drawable
	{
	public:
		Drawable();
		virtual ~Drawable();

		virtual void Draw(Graphics* gr) = 0;

		void SetPos(const Point& pos);
		void Move(int dx, int dy);
		Point GetPos() const;
		void SetVisible(bool visible);
		bool IsVisible() const;

	protected:
		Point pos;
		bool visible = true;
	};
}
