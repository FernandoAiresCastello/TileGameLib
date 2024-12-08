#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_Point.h"
#include "TGL_Rect.h"
#include "TGL_List.h"

namespace TGL
{
	class Graphics;
	class Image;
	class TiledImage;

	class TGLAPI Sprite
	{
	public:
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
		void SetFrameSequence(const List<int>& frames);
		void SetFrame(int index);
		void NextFrame();
		void PrevFrame();
		void EnableAutoAnimation(int frameLength);
		void DisableAutoAnimation();
		bool CollidesWith(Sprite* other);
		void Draw(Graphics* gr);

	protected:
		TiledImage* tileset;
		Image* singleImage;
		Size size;
		Rect collisionRect;
		Point pos;
		bool visible;
		List<int> frames;
		int currentFrame;

		struct {
			bool enabled = false;
			int frameLength = 0;
			int frameCount = 0;
		} autoAnimation;
	};
}
