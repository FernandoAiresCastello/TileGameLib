#include "TGL_TileMap.h"
#include "TGL_TiledImage.h"
#include "TGL_Graphics.h"

namespace TGL
{
	TileMap::TileMap() : tileset(nullptr), cellWidth(0), cellHeight(0), cols(0), rows(0)
	{
	}

	TileMap::~TileMap()
	{
	}

	void TileMap::SetTileset(TiledImage* img)
	{
		tileset = img;
		cellWidth = img->GetTileSize().GetWidth();
		cellHeight = img->GetTileSize().GetHeight();
		cols = img->GetSize().GetWidth() / cellWidth;
		rows = img->GetSize().GetHeight() / cellHeight;
	}

	void TileMap::SetSize(const Size& size)
	{
		cells.clear();
		for (int i = 0; i < size.GetWidth() * size.GetHeight(); i++)
			cells.push_back(EmptyTileIndex);
	}

	void TileMap::SetTileIndex(const Point& pos, int tileIndex)
	{
		cells[pos.GetY() * cols + pos.GetX()] = tileIndex;
	}

	int TileMap::GetTileIndex(const Point& pos) const
	{
		return cells[pos.GetY() * cols + pos.GetX()];
	}

	void TileMap::Draw(Graphics* gr) const
	{
		Point currentPos = pos;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				int frameIndex = GetTileIndex(Point(x, y));
				if (frameIndex >= 0)
					gr->DrawImage(tileset->GetTile(frameIndex), currentPos);
				else
					; // draw animated tile

				currentPos = currentPos.Move(cellWidth, 0);
			}
			currentPos = Point(pos.GetX(), currentPos.GetY() + cellHeight);
		}
	}
}
