/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoardRegion.h"
#include "TBoard.h"

namespace TileGameLib
{
	TBoardRegion::TBoardRegion(TBoard* board) :
		TBoardRegion(board, 0, 0, 0, 0)
	{
	}

	TBoardRegion::TBoardRegion(TBoard* board, int x, int y, int w, int h) :
		Board(board), X(x), Y(y), Width(w), Height(h)
	{
	}
	
	TBoardRegion::TBoardRegion(const TBoardRegion& other) :
		Board(other.Board), X(other.X), Y(other.Y), Width(other.Width), Height(other.Height)
	{
	}

	TBoardRegion::~TBoardRegion()
	{
	}

	bool TBoardRegion::IsValid()
	{
		return
			Board != nullptr &&
			Width > 0 && Height > 0 &&
			X >= 0 && Y >= 0 &&
			X + Width >= 0 && Y + Height >= 0 &&
			X + Width < Board->GetCols() &&
			Y + Height < Board->GetRows();
	}
}
