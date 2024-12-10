#pragma once
#include "TGL_Global.h"
#include "TGL_Index.h"
#include "TGL_Size.h"
#include "TGL_Point.h"
#include "TGL_Rect.h"
#include "TGL_List.h"
#include "TGL_Properties.h"

namespace TGL
{
	class Graphics;
	class Image;
	class TiledImage;

	class TGLAPI Sprite
	{
	public:
		Properties Data;

		Sprite();
		~Sprite();

		void SetTileset(TiledImage* img);
		void SetSingleImage(Image* img);
		void SetPos(const Point& pos);
		void Move(int dx, int dy);
		Size GetSize() const;
		Point GetPos() const;
		void SetVisible(bool visible);
		bool IsVisible() const;
		void SetFrameSequence(const List<Index>& frames);
		void SetFrame(Index index);
		void NextFrame();
		void PrevFrame();
		void EnableAutoAnimation(int frameLength);
		void DisableAutoAnimation();
		bool CollidesWith(Sprite* other);
		void Draw(Graphics* gr);

	private:
		TiledImage* tileset;
		Image* singleImage;
		Size size;
		Rect collisionRect;
		Point pos;
		bool visible;
		List<Index> frames;
		int currentFrame;

		struct {
			bool enabled = false;
			int frameLength = 0;
			int frameCount = 0;
		} autoAnimation;
	};
}
