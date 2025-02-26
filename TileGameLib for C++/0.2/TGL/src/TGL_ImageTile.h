#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Point.h"
#include "TGL_Index.h"
#include "TGL_Image.h"
#include "TGL_Properties.h"
#include "TGL_TileAnimation.h"

namespace TGL
{
	class Graphics;
	class ImageTileset;

	class TGLAPI ImageTile
	{
	public:
		Properties data;

		ImageTile();
		ImageTile(const ImageTile& other);
		ImageTile(Index singleImage);
		~ImageTile();

		ImageTile& operator=(const ImageTile& other);

		int FrameCount() const;
		Index GetFrame(int index);
		void AddFrame(Index imageIndex);
		void SetFrame(int frameIndex, Index imageIndex);
		void RemoveAllFrames();
		void SetEmpty();
		bool IsEmpty() const;
		bool HasAnyFrame() const;
		bool HasNoFrames() const;
		bool HasAnyData() const;
		bool HasNoData() const;
		void SetCurrentAnimFrame(int index);
		void SetAnimationDelay(int delay);
		void EnableAnimation(bool enable);
		void Draw(Graphics* g, ImageTileset* tileset, const Point& pos);
		void Draw(Graphics* g, ImageTileset* tileset, int x, int y);

	private:
		List<Index> frames;
		TileAnimation anim;

		Index& NextFrame();
	};
}
