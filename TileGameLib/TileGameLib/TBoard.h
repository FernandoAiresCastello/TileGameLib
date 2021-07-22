/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <vector>
#include "TGlobal.h"
#include "TClass.h"
#include "TObject.h"

namespace TileGameLib
{
	class TBoardLayer;
	class TTileSequence;

	class TILEGAMELIB_API TBoard : TClass
	{
	public:
		TBoard(int cols, int rows, int layers);
		TBoard(const TBoard& other) = delete;
		~TBoard();

		void Clear();
		void ClearLayer(int layer);
		void AddLayer();
		void PutObject(TObject* o, int x, int y, int layer);
		TObject* GetObject(int x, int y, int layer);
		void DeleteObject(int x, int y, int layer);
		void RemoveObject(int x, int y, int layer);
		bool IsWithinBounds(int x, int y, int layer);
		bool IsOutOfBounds(int x, int y, int layer);
		void SetBackColor(TPaletteIndex ix);
		void SetBackTile(TTile tile);
		void SetBackTiles(TTileSequence tiles);
		void AddBackTile(TTile tile);
		void AddBackTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		void DeleteBackTiles();
		bool HasBackTile();
		TPaletteIndex GetBackColor();
		TTile* GetBackTile(int ix);
		TTileSequence* GetBackTiles();
		int GetLayerCount();
		bool IsPositionEmpty(int x, int y, int layer);

	private:
		std::vector<TBoardLayer*> Layers;
		int Cols;
		int Rows;
		TTileSequence* BackTiles;

		friend TObject;
	};
}
