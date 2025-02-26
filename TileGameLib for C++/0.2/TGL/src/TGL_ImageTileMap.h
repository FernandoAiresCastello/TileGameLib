#pragma once
#include "TGL_Global.h"
#include "TGL_Size.h"
#include "TGL_List.h"
#include "TGL_Dict.h"
#include "TGL_Point.h"
#include "TGL_Index.h"
#include "TGL_ImageTile.h"

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
		void SetTile(const Point& pos, const ImageTile& tile);
		ImageTile& GetTile(const Point& pos);
		void Fill(const ImageTile& tile);
		void Draw(Graphics* gr, const Point& pos);
		int GetImageWidth() const;
		int GetImageHeight() const;

	private:
		ImageTileset* tileset = nullptr;
		Size imageSize;
		int cellWidth = 0;
		int cellHeight = 0;
		int cols = 0;
		int rows = 0;
		int cellCount = 0;
		bool visible = true;
		List<ImageTile> cells;
	};
}
