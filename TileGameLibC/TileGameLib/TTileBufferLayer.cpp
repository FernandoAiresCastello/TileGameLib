/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include <CppUtils.h>
#include "TTileBufferLayer.h"

#define ERR_OUT_OF_BOUNDS "Invalid access out of tile buffer layer bounds"

using namespace CppUtils;

namespace TileGameLib
{
	TTileBufferLayer::TTileBufferLayer(int cols, int rows)
	{
		Cols = cols;
		Rows = rows;
		Size = cols * rows;
		Visible = true;

		for (int i = 0; i < Size; i++)
			Tiles.push_back(TRenderedTileSeq());
	}

	TTileBufferLayer::~TTileBufferLayer()
	{
	}

	void TTileBufferLayer::SetTile(TTileSeq tile, int x, int y, bool transparent)
	{
		if (x >= 0 && y >= 0 && x < Cols && y < Rows) {
			auto& rtile = Tiles[y * Cols + x];
			rtile.TileSeq = tile;
			rtile.Transparent = transparent;
		}
	}

	TTileSeq& TTileBufferLayer::GetTile(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < Cols && y < Rows)
			return Tiles[y * Cols + x].TileSeq;
		
		throw "Cannot get tile from a position out of bounds";
	}

	void TTileBufferLayer::EraseTile(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < Cols && y < Rows)
			Tiles[y * Cols + x].TileSeq.Clear();
	}

	void TTileBufferLayer::Clear()
	{
		for (int i = 0; i < Size; i++)
			Tiles[i].TileSeq.Clear();
	}

	void TTileBufferLayer::Fill(TTileSeq tile, bool transparent)
	{
		for (int i = 0; i < Size; i++) {
			Tiles[i].TileSeq = tile;
			Tiles[i].Transparent = transparent;
		}
	}

	void TTileBufferLayer::SetVisible(bool visible)
	{
		Visible = visible;
	}

	bool TTileBufferLayer::IsVisible()
	{
		return Visible;
	}

	bool TTileBufferLayer::IsTileTransparent(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < Cols && y < Rows)
			return Tiles[y * Cols + x].Transparent;
		else
			return false;
	}
}
