/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTileBuffer.h"

namespace TileGameLib
{
	TTileBuffer::TTileBuffer(int layerCount, int cols, int rows) :
		LayerCount(layerCount), Cols(cols), Rows(rows), LastCol(cols - 1), LastRow(rows - 1)
	{
		for (int i = 0; i < layerCount; i++)
			Layers.push_back(TTileBufferLayer(cols, rows));

		View.X = 0;
		View.Y = 0;
		View.Cols = cols;
		View.Rows = rows;
		View.ScrollX = 0;
		View.ScrollY = 0;
		View.Visible = true;
	}

	TTileBuffer::~TTileBuffer()
	{
	}

	void TTileBuffer::SetTile(TTileSeq tile, int layer, int x, int y, bool transparent)
	{
		Layers[layer].SetTile(tile, x, y, transparent);
	}

	void TTileBuffer::PutChar(int ch, int layer, int x, int y, int fgc, int bgc, bool transparent)
	{
		Layers[layer].SetTile(TTileSeq(ch, fgc, bgc), x, y, transparent);
	}

	void TTileBuffer::Print(std::string str, int layer, int x, int y, int fgc, int bgc, bool transparent)
	{
		const int px = x;

		for (auto& ch : str)
		{
			if (ch == '\n')
			{
				x = px;
				y++;
				if (y >= Rows)
					break;
			}
			else
			{
				Layers[layer].SetTile(TTileSeq(ch, fgc, bgc), x++, y, transparent);
				if (x >= Cols)
					break;
			}
		}
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

	void TTileBuffer::ClearLayerRect(int layer, int x, int y, int w, int h)
	{
		Layers[layer].ClearRect(x, y, w, h);
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
	
	void TTileBuffer::SetView(int x, int y, int cols, int rows)
	{
		View.X = x;
		View.Y = y;
		View.Cols = cols;
		View.Rows = rows;
	}
}
