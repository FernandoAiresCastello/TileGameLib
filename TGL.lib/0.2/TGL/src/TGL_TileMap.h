#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_List.h"
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
		Index GetTile(const Point& pos) const;
		void Fill(Index tileIndex);
		void Draw(Graphics* gr) const;

	private:
		static const int EmptyTileIndex = 0;

		TiledImage* tileset;
		int cellWidth;
		int cellHeight;
		int cols;
		int rows;
		int cellCount;
		List<Index> cells;
		Point pos;
	};
}
