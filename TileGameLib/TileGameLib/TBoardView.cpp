/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoardView.h"
#include "TBoard.h"
#include "TWindow.h"
#include "TCharset.h"
#include "TPalette.h"
#include "TObject.h"
#include "TTile.h"
#include "TTileSequence.h"

namespace TileGameLib
{
	TBoardView::TBoardView(TBoard* board, TWindow* window, TCharset* chars, TPalette* pal, 
		int x, int y, int cols, int rows, int animationDelay) :

		Board(board), Window(window), Charset(chars), Palette(pal), Enabled(true),
		X(x), Y(y), Cols(cols), Rows(rows), ScrollX(0), ScrollY(0),
		Animating(true), AnimationFrame(0), AnimationDelay(animationDelay)
	{
		if (animationDelay > 0)
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

	int TBoardView::GetX()
	{
		return X;
	}

	int TBoardView::GetY()
	{
		return Y;
	}

	int TBoardView::GetCols()
	{
		return Cols;
	}

	int TBoardView::GetRows()
	{
		return Rows;
	}

	int TBoardView::GetScrollX()
	{
		return ScrollX;
	}

	int TBoardView::GetScrollY()
	{
		return ScrollY;
	}

	void TBoardView::AdvanceAnimationFrame()
	{
		AnimationFrame++;
	}

	void TBoardView::SetEnabled(bool enabled)
	{
		Enabled = enabled;
	}

	bool TBoardView::IsEnabled()
	{
		return Enabled;
	}

	void TBoardView::Draw()
	{
		if (Enabled) {
			for (int i = 0; i < Board->GetLayerCount(); i++)
				DrawLayer(i);
		}
	}

	void TBoardView::DrawLayer(int layer)
	{
		int objX = ScrollX;
		int objY = ScrollY;

		for (int viewY = Y; viewY < Y + Rows; viewY++) {
			for (int viewX = X; viewX < X + Cols; viewX++) {
				TObject* o = Board->GetObjectAt(objX, objY, layer);
				if (Board->HasBackTile() && layer == 0 && (o == nullptr || !o->HasTiles() || !o->IsVisible()))
					DrawBackTile(viewX, viewY);
				else if (o != nullptr && o->IsVisible())
					DrawObject(o, viewX, viewY);

				objX++;
			}
			objX = ScrollX;
			objY++;
		}
	}

	void TBoardView::DrawBackTile(int viewX, int viewY)
	{
		Window->DrawTile(Charset, Palette, Board->GetBackTile(AnimationFrame), viewX, viewY);
	}

	void TBoardView::DrawObject(TObject* o, int viewX, int viewY)
	{
		Window->DrawTile(Charset, Palette, o->GetTile(AnimationFrame), viewX, viewY);
	}

	void TBoardView::AdvanceAnimationFrameThread()
	{
		while (Animating) {
			AnimationFrame++;
			std::this_thread::sleep_for(std::chrono::milliseconds(AnimationDelay));
		}
	}
}
