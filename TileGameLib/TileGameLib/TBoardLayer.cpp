/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoardLayer.h"
#include "TBoardCell.h"
#include "TObject.h"

namespace TileGameLib
{
	TBoardLayer::TBoardLayer(int cols, int rows) :
		Cols(cols), Rows(rows)
	{
		Cells = new TBoardCell*[Rows];
		for (int i = 0; i < Rows; i++)
			Cells[i] = new TBoardCell[Cols];
	}

	TBoardLayer::~TBoardLayer()
	{
		delete Cells;
	}

	TBoardCell* TBoardLayer::GetCell(int x, int y)
	{
		return &Cells[y][x];
	}

	void TBoardLayer::Clear()
	{
		for (int y = 0; y < Rows; y++) {
			for (int x = 0; x < Cols; x++) {
				delete Cells[y][x].Obj;
				Cells[y][x].Obj = nullptr;
			}
		}
	}
}
