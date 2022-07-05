/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <map>
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TTile.h"
#include "TTileSeq.h"
#include "TTileBufferLayer.h"

namespace TileGameLib
{
	class TTileBuffer
	{
	public:
		const int LayerCount;
		const int Cols;
		const int Rows;
		const int LastCol;
		const int LastRow;

		TTileBuffer(int layerCount, int cols, int rows);
		~TTileBuffer();

		void SetTile(TTileSeq tile, int layer, int x, int y, bool transparent);
		void PutChar(int ch, int layer, int x, int y, int fgc, int bgc, bool transparent);
		void Print(std::string str, int layer, int x, int y, int fgc, int bgc, bool transparent);
		TTileSeq& GetTile(int layer, int x, int y);
		void EraseTile(int layer, int x, int y);
		void ClearLayer(int layer);
		void ClearAllLayers();
		void FillLayer(int layer, TTileSeq tile, bool transparent);
		void SetLayerVisible(int layer, bool visible);
		bool IsLayerVisible(int layer);
		bool IsTileTransparent(int layer, int x, int y);

	private:
		std::vector<TTileBufferLayer> Layers;
	};
}
