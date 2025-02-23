#pragma once
#include "TGL_Global.h"
#include "TGL_SpriteBase.h"
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
	class ImageTileset;

	class TGLAPI Sprite : public SpriteBase
	{
	public:
		Properties Data;

		Sprite();
		~Sprite();

		void SetTileset(ImageTileset* img);
		void SetSingleImage(Image* img);
		Size GetSize() const;
		void SetFrameSequence(const List<Index>& frames);
		void SetFrame(Index index);
		void NextFrame();
		void PrevFrame();
		void EnableAutoAnimation(int frameLength);
		void DisableAutoAnimation();
		bool CollidesWith(Sprite* other);
		void Draw(Graphics* gr) override;

	private:
		ImageTileset* tileset;
		Image* singleImage;
		Size size;
		Rect collisionRect;
		List<Index> frames;
		int currentFrame;

		struct {
			bool enabled = false;
			int frameLength = 0;
			int frameCount = 0;
		} autoAnimation;
	};
}
