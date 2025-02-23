#include "TGL_ImageTileMap.h"
#include "TGL_ImageTileset.h"
#include "TGL_Graphics.h"

namespace TGL
{
	ImageTileMap::ImageTileMap() : tileset(nullptr), 
		cellWidth(0), cellHeight(0), cols(0), rows(0), cellCount(0)
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
			cells.push_back(EmptyTileIndex);

		imageSize = Size(cellWidth * cols, cellHeight * rows);
	}

	void ImageTileMap::SetTile(const Point& pos, Index tileIndex)
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			cells[pos.GetY() * cols + pos.GetX()] = tileIndex;
	}

	Index ImageTileMap::CreateAnimatedTile(const List<Index>& frames)
	{
		Index nextIndex = animatedTiles.size() + 1;
		nextIndex = -nextIndex;
		animatedTiles[nextIndex] = frames;
		return nextIndex;
	}

	Index ImageTileMap::GetTile(const Point& pos) const
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < cols && pos.GetY() < rows)
			return cells[pos.GetY() * cols + pos.GetX()];

		return 0;
	}

	void ImageTileMap::SetAnimationDelay(int frameDelay)
	{
		animationCounterMax = frameDelay;
	}

	void ImageTileMap::Fill(Index tileIndex)
	{
		for (int i = 0; i < cellCount; i++)
			cells[i] = tileIndex;
	}

	void ImageTileMap::Draw(Graphics* gr, const Point& pos)
	{
		if (!visible || !tileset)
			return;

		Point currentPos = pos;

		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Index tileIndex = GetTile(Point(x, y));
				if (tileIndex == 0) {
					// Do not draw anything
				}
				else if (tileIndex > 0) {
					gr->DrawImage(tileset->GetTile(tileIndex - 1), currentPos);
				}
				else if (tileIndex < 0 && animatedTiles.contains(tileIndex)) {
					auto& animationFrames = animatedTiles.at(tileIndex);
					Index frameIndex = animationFrames[currentAnimationFrameIndex % animationFrames.size()];
					gr->DrawImage(tileset->GetTile(frameIndex - 1), currentPos);
				}

				currentPos = currentPos.Move(cellWidth, 0);
			}
			currentPos = Point(pos.GetX(), currentPos.GetY() + cellHeight);
		}
	}

	void ImageTileMap::AnimateTiles()
	{
		animationCounter++;
		if (animationCounter > animationCounterMax) {
			animationCounter = 0;
			currentAnimationFrameIndex++;
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
