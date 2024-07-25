#pragma once
#include <map>
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TTile.h"
#include "TTileSeq.h"
#include "TTileBufferLayer.h"

namespace TGL_Internal
{
	class TTileBuffer
	{
	public:
		const int LayerCount;
		const int Cols;
		const int Rows;
		const int LastCol;
		const int LastRow;

		struct
		{
			int X;
			int Y;
			int Cols;
			int Rows;
			int ScrollX;
			int ScrollY;
			bool Visible;
		}
		View;

		TTileBuffer(int layerCount, int cols, int rows);
		~TTileBuffer();

		void SetTile(TTileSeq tile, int layer, int x, int y, bool transparent);
		void PutChar(int ch, int layer, int x, int y, int fgc, int bgc, bool transparent);
		void Print(std::string str, int layer, int x, int y, int fgc, int bgc, bool transparent);
		TTileSeq& GetTile(int layer, int x, int y);
		void EraseTile(int layer, int x, int y);
		void ClearLayer(int layer);
		void ClearLayerRect(int layer, int x, int y, int w, int h);
		void ClearAllLayers();
		void FillLayer(int layer, TTileSeq tile, bool transparent);
		void SetLayerVisible(int layer, bool visible);
		bool IsLayerVisible(int layer);
		bool IsTileTransparent(int layer, int x, int y);
		void SetView(int x, int y, int cols, int rows);

	private:
		std::vector<TTileBufferLayer> Layers;
	};
}
