/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <string>
#include "TGlobal.h"

namespace TileGameLib
{
	class TClass
	{
	public:
		TClass();
		virtual ~TClass();

		virtual std::string ToString();
	};
}
