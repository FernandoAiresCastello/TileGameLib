/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTiledImage.h"
#include "TImage.h"

namespace TileGameLib
{
	struct TTiledImage::TTiledPosition
	{
		int X;
		int Y;
	};

	TTiledImage::TTiledImage(std::string filename, int tileWidth, int tileHeight, TColor transparency)
		: TileWidth(tileWidth), TileHeight(tileHeight)
	{
		Cols = 0;
		Rows = 0;

		Img = new TImage();
		if (!Img->Load(filename, transparency)) {
			delete Img;
			return;
		}

		Cols = Img->GetWidth() / TileWidth;
		Rows = Img->GetHeight() / TileHeight;
		
		CalculateTiledPositions();

		int i = 0;
		while (true) {
			int tx = GetTileXFromIndex(i);
			int ty = GetTileYFromIndex(i);
			i++;
			if (tx < 0 || ty < 0)
				break;

			TImage* tile = new TImage();
			tile->Width = TileWidth;
			tile->Height = TileHeight;
			tile->SetTransparency(transparency);

			for (int px = tx; px < tx + TileWidth; px++) {
				for (int py = ty; py < ty + TileHeight; py++) {
					TColor& color = Img->GetPixel(px, py);
					tile->Pixels.push_back(color);
				}
			}

			Tiles.push_back(tile);
		}
	}

	TTiledImage::~TTiledImage()
	{
		delete Img;

		for (int i = 0; i < Tiles.size(); i++)
			delete Tiles[i];

		Tiles.clear();
	}

	TImage* TTiledImage::GetImage()
	{
		return Img;
	}

	TImage* TTiledImage::GetTile(int index)
	{
		return Tiles[index];
	}

	int TTiledImage::GetTileCount()
	{
		return Tiles.size();
	}

	int TTiledImage::GetTileXFromIndex(int index)
	{
		if (index >= 0 && index < TiledPositions.size())
			return TiledPositions[index].X;

		return -1;
	}

	int TTiledImage::GetTileYFromIndex(int index)
	{
		if (index >= 0 && index < TiledPositions.size())
			return TiledPositions[index].Y;

		return -1;
	}

	void TTiledImage::CalculateTiledPositions()
	{
		TiledPositions.clear();

		for (int y = 0; y < Rows; y++) {
			for (int x = 0; x < Cols; x++) {
				TTiledPosition pos;
				pos.X = x * TileWidth;
				pos.Y = y * TileHeight;
				TiledPositions.push_back(pos);
			}
		}
	}
}
