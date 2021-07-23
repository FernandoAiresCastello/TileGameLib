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

	void TBoard::SetBackColor(TPaletteIndex ix)
	{
		SetBackTile(TTile(0, ix, ix));
	}

	void TBoard::SetBackTile(TTile tile)
	{
		BackTiles->DeleteAll();
		BackTiles->Add(tile);
	}

	void TBoard::SetBackTiles(TTileSequence tiles)
	{
		BackTiles->SetEqual(&tiles);
	}

	void TBoard::AddBackTile(TTile tile)
	{
		BackTiles->Add(tile);
	}

	void TBoard::AddBackTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc)
	{
		BackTiles->Add(TTile(ch, fgc, bgc));
	}

	void TBoard::DeleteBackTiles()
	{
		BackTiles->DeleteAll();
	}

	bool TBoard::HasBackTile()
	{
		return !BackTiles->IsEmpty();
	}

	TPaletteIndex TBoard::GetBackColor()
	{
		return BackTiles->Get(0)->BackColor;
	}

	TTile* TBoard::GetBackTile(int ix)
	{
		return BackTiles->Get(ix);
	}

	TTileSequence* TBoard::GetBackTiles()
	{
		return BackTiles;
	}

	int TBoard::GetCols()
	{
		return Cols;
	}

	int TBoard::GetRows()
	{
		return Rows;
	}

	int TBoard::GetLayerCount()
	{
		return Layers.size();
	}

	bool TBoard::IsPositionEmpty(int x, int y, int layer)
	{
		return Layers[layer]->GetCell(x, y)->Obj == nullptr;
	}

	std::vector<TObject*> TBoard::FindObjectsByProperty(std::string& prop, std::string& value, TBoardRegion& region)
	{
		std::vector<TObject*> objs;
		for (int layerIx = 0; layerIx < Layers.size(); layerIx++) {
			for (int y = region.Y; y < region.Y + region.Height; y++) {
				for (int x = region.X; x < region.X + region.Width; x++) {
					TObject* o = GetObject(x, y, layerIx);
					if (o != nullptr && o->HasProperty(prop, value))
						objs.push_back(o);
				}
			}
		}
		return objs;
	}

	std::vector<TObject*> TBoard::FindObjectsByProperty(std::string& prop, int value, TBoardRegion& region)
	{
		std::vector<TObject*> objs;
		for (int layerIx = 0; layerIx < Layers.size(); layerIx++) {
			for (int y = region.Y; y < region.Y + region.Height; y++) {
				for (int x = region.X; x < region.X + region.Width; x++) {
					TObject* o = GetObject(x, y, layerIx);
					if (o != nullptr && o->HasProperty(prop, value))
						objs.push_back(o);
				}
			}
		}
		return objs;
	}
}
