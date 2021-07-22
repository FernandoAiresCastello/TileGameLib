/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include "TBoardCell.h"
#include "TObject.h"

namespace TileGameLib
{
	TBoardCell::TBoardCell()
	{
		Obj = nullptr;
	}

	TBoardCell::~TBoardCell()
	{
		delete Obj;
	}
}
