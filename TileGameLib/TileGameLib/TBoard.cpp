/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoard.h"
#include "TBoardLayer.h"
#include "TTileSequence.h"
#include "TBoardCell.h"

namespace TileGameLib
{
	TBoard::TBoard(int cols, int rows, int layers) :
		Cols(cols), Rows(rows)
	{
		for (int i = 0; i < layers; i++)
			AddLayer();

		BackTiles = new TTileSequence();
	}

	TBoard::~TBoard()
	{
		for (int i = 0; i < Layers.size(); i++) {
			delete Layers[i];
			Layers[i] = nullptr;
		}
		Layers.clear();
		delete BackTiles;
	}

	void TBoard::Clear()
	{
		for (auto& layer : Layers)
			layer->Clear();
	}

	void TBoard::ClearLayer(int layer)
	{
		Layers[layer]->Clear();
	}

	void TBoard::AddLayer()
	{
		Layers.push_back(new TBoardLayer(Cols, Rows));
	}

	void TBoard::PutObject(TObject* o, int x, int y, int layer)
	{
		if (IsWithinBounds(x, y, layer)) {
			if (Layers[layer]->GetCell(x, y)->Obj != nullptr)
				DeleteObject(x, y, layer);

			o->Board = this;
			o->X = x;
			o->Y = y;
			o->Layer = layer;

			Layers[layer]->GetCell(x, y)->Obj = o;
		}
	}

	TObject* TBoard::GetObject(int x, int y, int layer)
	{
		if (IsWithinBounds(x, y, layer))
			return Layers[layer]->GetCell(x, y)->Obj;

		return nullptr;
	}

	void TBoard::DeleteObject(int x, int y, int layer)
	{
		if (IsWithinBounds(x, y, layer)) {
			delete Layers[layer]->GetCell(x, y)->Obj;
			Layers[layer]->GetCell(x, y)->Obj = nullptr;
		}
	}

	void TBoard::RemoveObject(int x, int y, int layer)
	{
		if (IsWithinBounds(x, y, layer)) {
			Layers[layer]->GetCell(x, y)->Obj = nullptr;
		}
	}

	bool TBoard::IsWithinBounds(int x, int y, int layer)
	{
		return 
			x >= 0 && y >= 0 && layer >= 0 &&
			x < Cols && y < Rows && layer < Layers.size();
	}

	bool TBoard::IsOutOfBounds(int x, int y, int layer)
	{
		return !IsWithinBounds(x, y, layer);
	}

	void TBoard::SetBackTile(TTile tile)
	{
		BackTiles->DeleteAll();
		BackTiles->Add(tile);
	}

	void TBoard::SetBackTiles(TTileSequence tiles)
	{
		BackTiles->SetEqual(tiles);
	}

	void TBoard::DeleteBackTiles()
	{
		BackTiles->DeleteAll();
	}

	TTileSequence* TBoard::GetBackTiles()
	{
		return BackTiles;
	}

	int TBoard::GetLayerCount()
	{
		return Layers.size();
	}

	bool TBoard::IsPositionEmpty(int x, int y, int layer)
	{
		return Layers[layer]->GetCell(x, y)->Obj == nullptr;
	}
}
