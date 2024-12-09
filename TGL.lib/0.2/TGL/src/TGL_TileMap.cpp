#include "TGL_TileMap.h"
#include "TGL_TiledImage.h"
#include "TGL_Graphics.h"

namespace TGL
{
	TileMap::TileMap() : tileset(nullptr), cellWidth(0), cellHeight(0), cols(0), rows(0), cellCount(0), pos(0, 0)
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
	}

	void TileMap::SetPos(const Point& pos)
	{
		this->pos = pos;
	}

	void TileMap::SetSize(const Size& size)
	{
		cells.clear();
		cols = size.GetWidth();
		rows = size.GetHeight();
		cellCount = cols * rows;

		for (int i = 0; i < cellCount; i++)
			cells.push_back(EmptyTileIndex);
	}

	void TileMap::SetTile(const Point& pos, Index tileIndex)
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			cells[pos.GetY() * cols + pos.GetX()] = tileIndex;
	}

	Index TileMap::GetTile(const Point& pos) const
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			return cells[pos.GetY() * cols + pos.GetX()];

		return 0;
	}

	void TileMap::Fill(Index tileIndex)
	{
		for (int i = 0; i < cellCount; i++)
			cells[i] = tileIndex;
	}

	void TileMap::Draw(Graphics* gr) const
	{
		Point currentPos = pos;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Index frameIndex = GetTile(Point(x, y));
				if (frameIndex > 0)
					gr->DrawImage(tileset->GetTile(frameIndex), currentPos);
				else if (frameIndex < 0)
					; // TODO: draw animated tile

				currentPos = currentPos.Move(cellWidth, 0);
			}
			currentPos = Point(pos.GetX(), currentPos.GetY() + cellHeight);
		}
	}
}
