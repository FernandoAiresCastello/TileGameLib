/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGBTileLayer.h"

namespace TileGameLib
{
	TGBTileLayer::TGBTileLayer(int cols, int rows) : 
		Cols(cols), Rows(rows), Length(cols * rows)
	{
		for (int i = 0; i < Length; i++) {
			Tiles.push_back(TGBTile());
		}
	}

	std::vector<TGBTile>& TGBTileLayer::GetTiles()
	{
		return Tiles;
	}

	void TGBTileLayer::Clear()
	{
		for (int i = 0; i < Length; i++) {
			Tiles[i].SetEmpty();
		}
	}

	void TGBTileLayer::SetTile(TGBTile tile, int x, int y)
	{
		const int pos = y * Cols + x;
		if (pos >= 0 && pos < Length) {
			Tiles[pos] = tile;
		}
	}

	void TGBTileLayer::EraseTile(int x, int y)
	{
		const int pos = y * Cols + x;
		if (pos >= 0 && pos < Length) {
			Tiles[pos].SetEmpty();
		}
	}

	TGBTile* TGBTileLayer::GetTile(int x, int y)
	{
		const int pos = y * Cols + x;
		if (pos >= 0 && pos < Length) {
			return &Tiles[pos];
		}
		return nullptr;
	}

	void TGBTileLayer::Fill(TGBTile tile)
	{
		for (int i = 0; i < Length; i++) {
			Tiles[i] = tile;
		}
	}
}
