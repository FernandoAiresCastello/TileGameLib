#pragma once
#include "TGL_Globals.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Point.h"

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
		void SetSize(const Size& size);
		void SetTileIndex(const Point& pos, int tileIndex);
		int GetTileIndex(const Point& pos) const;
		void Draw(Graphics* gr) const;

	private:
		static const int EmptyTileIndex = 0;

		TiledImage* tileset;
		int cellWidth;
		int cellHeight;
		int cols;
		int rows;
		List<int> cells;
		Point pos;
	};
}
