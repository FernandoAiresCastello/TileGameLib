#pragma once
#include "TGL_Globals.h"
#include "TGL_Size.h"
#include "TGL_Point.h"
#include "TGL_TiledImage.h"

namespace TGL
{
	class TGLAPI Sprite
	{
	public:
		Sprite();
		virtual ~Sprite();

		void SetSize(const Size& size);
		void SetPos(const Point& pos);
		void Move(int dx, int dy);
		Size GetSize() const;
		Point GetPos() const;
		void SetVisible(bool visible);
		bool IsVisible() const;

	protected:
		TiledImage img;
		Size size;
		Point pos;
		bool visible;
	};
}
