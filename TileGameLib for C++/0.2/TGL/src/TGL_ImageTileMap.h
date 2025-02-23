#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Dict.h"
#include "TGL_Point.h"
#include "TGL_Index.h"

namespace TGL
{
	class ImageTileset;
	class Graphics;

	class TGLAPI ImageTileMap
	{
	public:
		ImageTileMap();
		~ImageTileMap();

		void SetTileset(ImageTileset* img);
		void SetCellCount(const Size& size);
		void SetTile(const Point& pos, Index tileIndex);
		Index CreateAnimatedTile(const List<Index>& frames);
		Index GetTile(const Point& pos) const;
		void SetAnimationDelay(int frameDelay);
		void Fill(Index tileIndex);
		void Draw(Graphics* gr, const Point& pos);
		void AnimateTiles();
		int GetImageWidth() const;
		int GetImageHeight() const;

	private:
		static const int EmptyTileIndex = 0;

		ImageTileset* tileset = nullptr;
		Size imageSize;
		int cellWidth = 0;
		int cellHeight = 0;
		int cols = 0;
		int rows = 0;
		int cellCount = 0;
		bool visible = true;
		List<Index> cells;
		Dict<Index, List<Index>> animatedTiles;
		unsigned currentAnimationFrameIndex = 0;
		int animationCounter = 0;
		int animationCounterMax = 30;
	};
}
