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
	TBoardView::TBoardView(TGraphics* gr, int animationDelay) :
		Gr(gr), Board(nullptr), 
		X(0), Y(0), Cols(gr->Window->Cols), Rows(gr->Window->Rows), 
		ScrollX(0), ScrollY(0),
		Animating(true), AnimationFrame(0), AnimationDelay(animationDelay)
	{
		AnimationThread = std::thread(&TBoardView::AdvanceAnimationFrameThread, this);
	}

	TBoardView::~TBoardView()
	{
		Animating = false;
		if (AnimationThread.native_handle() != nullptr) {
			AnimationThread.join();
		}
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

	void TBoardView::AdvanceAnimationFrame()
	{
		AnimationFrame++;
	}

	void TBoardView::Draw()
	{
		for (int i = 0; i < Board->GetLayerCount(); i++)
			DrawLayer(i);
	}

	void TBoardView::DrawLayer(int layer)
	{
		int objX = ScrollX;
		int objY = ScrollY;

		for (int viewY = Y; viewY < Y + Rows; viewY++) {
			for (int viewX = X; viewX < X + Cols; viewX++) {
				TObject* o = Board->GetObject(objX, objY, layer);
				if (Board->HasBackTile() && layer == 0 && (o == nullptr || !o->HasTiles()))
					DrawBackTile(viewX, viewY);
				else if (o != nullptr)
					DrawObject(o, viewX, viewY);

				objX++;
			}
			objX = ScrollX;
			objY++;
		}
	}

	void TBoardView::DrawBackTile(int viewX, int viewY)
	{
		Gr->Window->DrawTile(Gr->Chars, Gr->Pal, Board->GetBackTile(AnimationFrame), viewX, viewY);
	}

	void TBoardView::DrawObject(TObject* o, int viewX, int viewY)
	{
		Gr->Window->DrawTile(Gr->Chars, Gr->Pal, o->GetTile(AnimationFrame), viewX, viewY);
	}

	void TBoardView::AdvanceAnimationFrameThread()
	{
		while (Animating) {
			AnimationFrame++;
			std::this_thread::sleep_for(std::chrono::milliseconds(AnimationDelay));
		}
	}
}
