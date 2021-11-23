/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <vector>
#include <string>
#include "TGlobal.h"
#include "TClass.h"
#include "TObject.h"
#include "TBoardRegion.h"

namespace TileGameLib
{
	class TBoardLayer;
	class TTileSequence;

	class TBoard : TClass
	{
	public:
		TBoard(int cols, int rows, int layers);
		TBoard(const TBoard& other) = delete;
		~TBoard();

		void Clear();
		void ClearLayer(int layer);
		void AddLayer();
		void SetName(std::string name);
		std::string GetName();
		void PutObject(TObject* o, int x, int y, int layer);
		TObject* GetObjectAt(int x, int y, int layer);
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
		int GetCols();
		int GetRows();
		int GetLayerCount();
		bool IsPositionEmpty(int x, int y, int layer);
		std::vector<TObject*> FindObjectsByProperty(std::string& prop, std::string& value, TBoardRegion& region);
		std::vector<TObject*> FindObjectsByProperty(std::string& prop, int value, TBoardRegion& region);

	private:
		std::string Name;
		std::vector<TBoardLayer*> Layers;
		int Cols;
		int Rows;
		TTileSequence* BackTiles;

		friend TObject;
	};
}
