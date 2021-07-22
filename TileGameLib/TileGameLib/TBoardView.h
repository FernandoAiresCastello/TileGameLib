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
	class TGraphics;

	class TILEGAMELIB_API TBoardView : TClass
	{
	public:
		TBoardView(TGraphics* gr);
		TBoardView(const TBoardView& other) = delete;
		~TBoardView();

		void Draw();
		void SetBoard(TBoard* board);
		void SetPosition(int x, int y);
		void SetSize(int cols, int rows);
		void SetScroll(int sx, int sy);
		void Scroll(int dx, int dy);

	private:
		TGraphics* Gr;
		TBoard* Board;
		int X;
		int Y;
		int Cols;
		int Rows;
		int ScrollX;
		int ScrollY;
	};
}
