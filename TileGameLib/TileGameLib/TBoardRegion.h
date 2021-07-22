/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TBoard;

	class TILEGAMELIB_API TBoardRegion : TClass
	{
	public:
		TBoardRegion(TBoard* board);
		TBoardRegion(TBoard* board, int x, int y, int w, int h);
		TBoardRegion(const TBoardRegion& other);
		~TBoardRegion();

		TBoard* Board;
		int X;
		int Y;
		int Width;
		int Height;

		bool IsValid();
	};
}
