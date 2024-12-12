#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Dict.h"
#include "TGL_Point.h"
#include "TGL_Index.h"

namespace TGL
{
	class TiledImage;
	class Graphics;

	class TGLAPI TileMap
	{
	public:
		TileMap();
		~TileMap();

		void SetTileset(TiledImage* img);
		void SetPos(const Point& pos);
		void SetSize(const Size& size);
		void SetTile(const Point& pos, Index tileIndex);
		Index CreateAnimatedTile(const List<Index>& frames);
		Index GetTile(const Point& pos) const;
		void SetAnimationDelay(int frameDelay);
		void Fill(Index tileIndex);
		void Draw(Graphics* gr);

	private:
		static const int EmptyTileIndex = 0;

		TiledImage* tileset = nullptr;
		int cellWidth = 0;
		int cellHeight = 0;
		int cols = 0;
		int rows = 0;
		int cellCount = 0;
		Point pos;
		List<Index> cells;
		Dict<Index, List<Index>> animatedTiles;
		unsigned currentAnimationFrameIndex = 0;
		int animationCounter = 0;
		int animationCounterMax = 30;
	};
}
