/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TBoardCell;

	class TILEGAMELIB_API TBoardLayer : TClass
	{
	public:
		TBoardLayer(int cols, int rows);
		TBoardLayer(const TBoardLayer& other) = delete;
		~TBoardLayer();

		TBoardCell* GetCell(int x, int y);
		void Clear();

	private:
		TBoardCell** Cells;
		int Cols;
		int Rows;
	};
}
