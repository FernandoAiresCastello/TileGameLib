/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <string>
#include "TGLGlobal.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLClass
	{
	public:
		TGLClass();
		virtual ~TGLClass();

		virtual std::string ToString();
	};
}
