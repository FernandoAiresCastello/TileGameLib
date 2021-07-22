/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TObject;

	class TILEGAMELIB_API TBoardCell : TClass
	{
	public:
		TBoardCell();
		TBoardCell(const TBoardCell& other) = delete;
		~TBoardCell();

		TObject* Obj;
	};
}
