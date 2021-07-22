/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TObject.h"
#include "TTileSequence.h"
#include "TBoard.h"
#include "TUtil.h"
#include "TString.h"

constexpr int IdLength = 10;

namespace TileGameLib
{
	TObject::TObject()
	{
		Id = TUtil::RandomString(IdLength);
		X = -1;
		Y = -1;
		Layer = -1;
		Board = nullptr;
		Tiles = new TTileSequence();
	}

	TObject::TObject(TTile tile)
	{
		Id = TUtil::RandomString(IdLength);
		X = -1;
		Y = -1;
		Layer = -1;
		Board = nullptr;
		Tiles = new TTileSequence(tile);
	}

	TObject::TObject(TTileSequence tiles)
	{
		Id = TUtil::RandomString(IdLength);
		X = -1;
		Y = -1;
		Layer = -1;
		Board = nullptr;
		Tiles = new TTileSequence(tiles);
	}

	TObject::TObject(const TObject& other)
	{
		Id = TUtil::RandomString(IdLength);
		X = other.X;
		Y = other.Y;
		Layer = other.Layer;
		Board = other.Board;
		Tiles = new TTileSequence(*other.Tiles);
	}

	TObject::TObject(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc) :
		TObject(TTile(ch, fgc, bgc))
	{
	}

	TObject::~TObject()
	{
		delete Tiles;
	}

	std::string TObject::GetId()
	{
		return Id;
	}

	int TObject::GetX()
	{
		return X;
	}

	int TObject::GetY()
	{
		return Y;
	}

	int TObject::GetLayer()
	{
		return Layer;
	}

	void TObject::AddTile(TTile tile)
	{
		Tiles->Add(tile);
	}

	void TObject::AddTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc)
	{
		AddTile(TTile(ch, fgc, bgc));
	}

	void TObject::SetSingleTile(TTile tile)
	{
		Tiles->DeleteAll();
		Tiles->Add(tile);
	}

	void TObject::SetSingleTile(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc)
	{
		SetSingleTile(TTile(ch, fgc, bgc));
	}

	TTile* TObject::GetTile(int ix)
	{
		return Tiles->Get(ix);
	}

	TTile* TObject::GetSingleTile()
	{
		if (!Tiles->IsEmpty())
			return Tiles->Get(0);

		return nullptr;
	}

	bool TObject::HasTiles()
	{
		return !Tiles->IsEmpty();
	}

	void TObject::SetTilesEqual(TObject& other)
	{
		Tiles->SetEqual(*other.Tiles);
	}

	void TObject::DeleteTiles()
	{
		Tiles->DeleteAll();
	}

	void TObject::SetPropertiesEqual(TObject& other)
	{
		Properties.clear();
		for (auto& prop : other.Properties)
			Properties[prop.first] = prop.second;
	}

	bool TObject::IsVisible()
	{
		return Visible;
	}

	void TObject::SetVisible(bool visible)
	{
		Visible = visible;
	}

	void TObject::SetProperty(std::string prop, std::string value)
	{
		Properties[prop] = { value, TString::ToInt(value) };
	}

	void TObject::SetProperty(std::string prop, int value)
	{
		Properties[prop] = { TString::ToString(value), value };
	}

	std::string TObject::GetPropertyAsString(std::string prop)
	{
		if (HasProperty(prop))
			return Properties[prop].String;

		return "";
	}

	int TObject::GetPropertyAsNumber(std::string prop)
	{
		if (HasProperty(prop))
			return Properties[prop].Number;

		return 0;
	}

	bool TObject::HasProperty(std::string prop)
	{
		return Properties.find(prop) != Properties.end();
	}

	bool TObject::HasProperty(std::string prop, std::string value)
	{
		if (!HasProperty(prop))
			return false;

		return GetPropertyAsString(prop) == value;
	}

	bool TObject::HasProperty(std::string prop, int value)
	{
		if (!HasProperty(prop))
			return false;

		return GetPropertyAsNumber(prop) == value;
	}

	void TObject::Move(int dx, int dy)
	{
		Board->RemoveObject(X, Y, Layer);
		X += dx;
		Y += dy;
		Board->PutObject(this, X, Y, Layer);
	}

	void TObject::MoveTo(int x, int y)
	{
		MoveTo(x, y, Layer);
	}

	void TObject::MoveTo(int x, int y, int layer)
	{
		Board->RemoveObject(X, Y, Layer);
		X = x;
		Y = y;
		Layer = layer;
		Board->PutObject(this, X, Y, Layer);
	}
}
