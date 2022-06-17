/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "TColor.h"

namespace TileGameLib
{
	class TImage;

	class TTiledImage
	{
	public:
		const int TileWidth;
		const int TileHeight;

		TTiledImage(std::string filename, int tileWidth, int tileHeight, TColor transparency);
		~TTiledImage();

		TImage* GetImage();
		TImage* GetTile(int index);
		int GetTileCount();

	private:
		struct TTiledPosition;

		TImage* Img;
		std::vector<TImage*> Tiles;
		int Cols;
		int Rows;
		std::vector<TTiledPosition> TiledPositions;

		void CalculateTiledPositions();
		int GetTileXFromIndex(int index);
		int GetTileYFromIndex(int index);
	};
}
