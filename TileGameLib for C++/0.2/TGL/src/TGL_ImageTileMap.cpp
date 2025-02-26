#include "TGL_ImageTileMap.h"
#include "TGL_ImageTileset.h"
#include "TGL_Graphics.h"

namespace TGL
{
	ImageTileMap::ImageTileMap() : 
		tileset(nullptr), cellWidth(0), cellHeight(0), cols(0), rows(0), cellCount(0)
	{
	}

	ImageTileMap::~ImageTileMap()
	{
	}

	void ImageTileMap::SetTileset(ImageTileset* img)
	{
		tileset = img;
		cellWidth = img->GetTileSize().GetWidth();
		cellHeight = img->GetTileSize().GetHeight();
	}

	void ImageTileMap::SetCellCount(const Size& size)
	{
		cells.clear();
		cols = size.GetWidth();
		rows = size.GetHeight();
		cellCount = cols * rows;

		for (int i = 0; i < cellCount; i++)
			cells.push_back(ImageTile());

		imageSize = Size(cellWidth * cols, cellHeight * rows);
	}

	void ImageTileMap::SetTile(const Point& pos, const ImageTile& tile)
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			cells[pos.GetY() * cols + pos.GetX()] = tile;
	}

	ImageTile& ImageTileMap::GetTile(const Point& pos)
	{
		return cells[pos.GetY() * cols + pos.GetX()];
	}

	void ImageTileMap::Fill(const ImageTile& tile)
	{
		for (int i = 0; i < cellCount; i++)
			cells[i] = tile;
	}

	void ImageTileMap::Draw(Graphics* gr, const Point& pos)
	{
		if (!visible || !tileset)
			return;

		Point currentPos = pos;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				ImageTile& tile = GetTile(Point(x, y));
				if (tile.HasAnyFrame())
					tile.Draw(gr, tileset, pos);

				currentPos = currentPos.Move(cellWidth, 0);
			}
			currentPos = Point(pos.GetX(), currentPos.GetY() + cellHeight);
		}
	}

	int ImageTileMap::GetImageWidth() const
	{
		return imageSize.GetWidth();
	}

	int ImageTileMap::GetImageHeight() const
	{
		return imageSize.GetHeight();
	}
}
