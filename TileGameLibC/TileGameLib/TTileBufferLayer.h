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

namespace TileGameLib
{
	class TTileBufferLayer
	{
	public:
		TTileBufferLayer(int cols, int rows);
		~TTileBufferLayer();

		void SetTile(TTileSeq tile, int x, int y, bool transparent);
		TTileSeq& GetTile(int x, int y);
		void EraseTile(int x, int y);
		void Clear();
		void ClearRect(int x, int y, int w, int h);
		void Fill(TTileSeq tile, bool transparent);
		void SetVisible(bool visible);
		bool IsVisible();
		bool IsTileTransparent(int x, int y);

	private:
		int Cols;
		int Rows;
		int Size;
		bool Visible;

		class TRenderedTileSeq
		{
		public:
			TTileSeq TileSeq;
			bool Transparent = false;
		};
		std::vector<TRenderedTileSeq> Tiles;
	};
}
