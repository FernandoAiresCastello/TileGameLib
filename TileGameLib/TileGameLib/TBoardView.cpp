/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoardView.h"
#include "TBoard.h"
#include "TGraphics.h"
#include "TWindow.h"
#include "TCharset.h"
#include "TPalette.h"
#include "TObject.h"
#include "TTile.h"
#include "TTileSequence.h"

namespace TileGameLib
{
	TBoardView::TBoardView(TGraphics* gr) :
		Gr(gr), Board(nullptr), 
		X(0), Y(0), Cols(0), Rows(0), ScrollX(0), ScrollY(0)
	{
	}

	TBoardView::~TBoardView()
	{
	}

	void TBoardView::Draw()
	{
	}

	void TBoardView::SetBoard(TBoard* board)
	{
		Board = board;
	}

	void TBoardView::SetPosition(int x, int y)
	{
		X = x;
		Y = y;
	}

	void TBoardView::SetSize(int cols, int rows)
	{
		Cols = cols;
		Rows = rows;
	}

	void TBoardView::SetScroll(int sx, int sy)
	{
		ScrollX = sx;
		ScrollY = sy;
	}

	void TBoardView::Scroll(int dx, int dy)
	{
		ScrollX += dx;
		ScrollY += dy;
	}
}
