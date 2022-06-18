/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <vector>
#include "TGlobal.h"
#include "TGBTile.h"

namespace TileGameLib
{
	class TGBTileLayer
	{
	public:
		const int Cols;
		const int Rows;
		const int Length;

		TGBTileLayer(int cols, int rows);
		
		std::vector<TGBTile>& GetTiles();
		void Clear();
		void SetTile(TGBTile tile, int x, int y);
		void EraseTile(int x, int y);
		TGBTile* GetTile(int x, int y);
		void Fill(TGBTile tile);

	private:
		std::vector<TGBTile> Tiles;
	};
}
