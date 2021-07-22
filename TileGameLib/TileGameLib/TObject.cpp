/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TObject.h"
#include "TTileSequence.h"
#include "TBoard.h"
#include "TUtil.h"

constexpr int IdLength = 10;

namespace TileGameLib
{
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

	void TObject::SetTilesEqual(TObject& other)
	{
		Tiles->SetEqual(*other.Tiles);
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
