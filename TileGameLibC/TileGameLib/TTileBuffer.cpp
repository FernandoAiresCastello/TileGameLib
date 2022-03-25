/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTileBuffer.h"

namespace TileGameLib
{
	TTileBuffer::TTileBuffer(int layerCount, int cols, int rows) :
		LayerCount(layerCount), Cols(cols), Rows(rows), LastCol(cols - 1), LastRow(rows - 1)
	{
		for (int i = 0; i < layerCount; i++)
			Layers.push_back(TTileBufferLayer(cols, rows));
	}

	TTileBuffer::~TTileBuffer()
	{
	}

	void TTileBuffer::SetTile(TTileSeq tile, int layer, int x, int y, bool transparent)
	{
		Layers[layer].SetTile(tile, x, y, transparent);
	}

	TTileSeq& TTileBuffer::GetTile(int layer, int x, int y)
	{
		return Layers[layer].GetTile(x, y);
	}

	void TTileBuffer::EraseTile(int layer, int x, int y)
	{
		Layers[layer].EraseTile(x, y);
	}

	void TTileBuffer::ClearLayer(int layer)
	{
		Layers[layer].Clear();
	}

	void TTileBuffer::ClearAllLayers()
	{
		for (int i = 0; i < Layers.size(); i++)
			Layers[i].Clear();
	}

	void TTileBuffer::FillLayer(int layer, TTileSeq tile, bool transparent)
	{
		Layers[layer].Fill(tile, transparent);
	}
	
	void TTileBuffer::SetLayerVisible(int layer, bool visible)
	{
		Layers[layer].SetVisible(visible);
	}

	bool TTileBuffer::IsLayerVisible(int layer)
	{
		return Layers[layer].IsVisible();
	}

	bool TTileBuffer::IsTileTransparent(int layer, int x, int y)
	{
		return Layers[layer].IsTileTransparent(x, y);
	}
}
