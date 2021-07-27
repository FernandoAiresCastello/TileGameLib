/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <thread>
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TBoard;
	class TObject;
	class TCharset;
	class TPalette;
	class TWindow;

	class TILEGAMELIB_API TBoardView : TClass
	{
	public:
		TBoardView(TBoard* board, TWindow* window, TCharset* chars, TPalette* pal, 
			int x, int y, int cols, int rows, int animationDelay);

		TBoardView(const TBoardView& other) = delete;
		~TBoardView();

		void Draw();
		void SetBoard(TBoard* board);
		void SetPosition(int x, int y);
		void SetSize(int cols, int rows);
		void SetScroll(int sx, int sy);
		void Scroll(int dx, int dy);
		int GetX();
		int GetY();
		int GetCols();
		int GetRows();
		int GetScrollX();
		int GetScrollY();
		void AdvanceAnimationFrame();

	private:
		TBoard* Board;
		TWindow* Window;
		TCharset* Charset;
		TPalette* Palette;
		int X;
		int Y;
		int Cols;
		int Rows;
		int ScrollX;
		int ScrollY;
		bool Animating;
		int AnimationFrame;
		int AnimationDelay;
		std::thread AnimationThread;

		void DrawLayer(int layer);
		void DrawBackTile(int viewX, int viewY);
		void DrawObject(TObject* o, int viewX, int viewY);
		
		void AdvanceAnimationFrameThread();
	};
}
