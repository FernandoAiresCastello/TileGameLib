/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <string>
#include "TGlobal.h"
#include "TClass.h"
#include "TTile.h"
#include "TTileSequence.h"

namespace TileGameLib
{
	class TTileSequence;
	class TBoard;

	class TILEGAMELIB_API TObject : TClass
	{
	public:
		TObject(TTile tile);
		TObject(TTileSequence tiles);
		TObject(const TObject& other);
		TObject(TCharsetIndex ch, TPaletteIndex fgc, TPaletteIndex bgc);
		~TObject();

		std::string GetId();
		int GetX();
		int GetY();
		int GetLayer();
		void SetTilesEqual(TObject& other);
		void Move(int dx, int dy);
		void MoveTo(int x, int y);
		void MoveTo(int x, int y, int layer);

	private:
		std::string Id;
		int X;
		int Y;
		int Layer;
		TTileSequence* Tiles;
		TBoard* Board;

		friend TBoard;
	};
}
